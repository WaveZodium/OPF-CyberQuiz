using CyberQuiz.Application.Interfaces;
using CyberQuiz.Infrastructure.Repositories;
using CyberQuiz.Shared.DTOs.AICoach;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Http;

namespace CyberQuiz.Application.Services;

public class AICoachService : IAICoachService
{

    private readonly IUserResultRepository _userResultRepository;
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly HttpClient _httpClient;

    public AICoachService(
        IUserResultRepository userResultRepository,
        ISubCategoryRepository subCategoryRepository,
        ICategoryRepository categoryRepository,
        IQuestionRepository questionRepository,
        IHttpClientFactory httpClientFactory)
    {
        _userResultRepository = userResultRepository;
        _subCategoryRepository = subCategoryRepository;
        _categoryRepository = categoryRepository;
        _questionRepository = questionRepository;
        _httpClient = httpClientFactory.CreateClient("Ollama");
    }

    public async Task<UserQuizSummaryDto> GetUserQuizSummaryAsync(string userId)
    {
        //Get all quiz results for the user
        var userResults = await _userResultRepository.GetByUserAsync(userId);

        if (!userResults.Any())
        {
            return new UserQuizSummaryDto
            {
                UserId = userId,
                TotalQuestionsAnswered = 0,
                TotalCorrectAnswers = 0,
                OverallAccuracy = 0,
                SubCategoryPerformances = new()
            };
        }

        var subCategoryGroups = userResults.GroupBy(r => r.SubCategoryId);
        var subCategoryPerformances = new List<SubCategoryPerformanceDto>();

        foreach (var group in subCategoryGroups)
        {
            var subCategoryId = group.Key;
            // Get sub-category and category details
            var subCategory = await _subCategoryRepository.GetByIdAsync(subCategoryId);
            var category = subCategory != null ? await _categoryRepository.GetByIdAsync(subCategory.CategoryId) : null;

            // Calculate performance metrics
            var totalQuestions = await _questionRepository.CountQuestionsInSubCategoryAsync(subCategoryId);
            // Ensure we only count distinct questions attempted, not total attempts
            var distinctQuestions = group.Select(r => r.QuestionId).Distinct().Count();
            // Count correct answers based on distinct questions, not total attempts
            var correctAnswers = group.Count(r => r.IsCorrect);
            // Calculate accuracy based on distinct questions attempted
            var lastAttempt = group.Max(r => r.AnsweredAtUtc);

            var accuracy = group.Count() > 0
                    ? (double)correctAnswers / group.Count() * 100
                    : 0;

            subCategoryPerformances.Add(new SubCategoryPerformanceDto
            {
                SubCategoryId = subCategoryId,
                SubCategoryName = subCategory?.Name ?? "Unkown",
                CategoryName = category?.Name ?? "Unkown",
                QuestionsAttempted = distinctQuestions,
                CorrectAnswers = correctAnswers,
                AccuracyPercentage = Math.Round(accuracy, 2),
                TotalAvailableQuestions = totalQuestions,
                LastAttemptDate = lastAttempt
            });

        }

        return new UserQuizSummaryDto
        {
            UserId = userId,
            TotalQuestionsAnswered = userResults.Select(r => r.QuestionId).Distinct().Count(),
            TotalCorrectAnswers = userResults.Count(r => r.IsCorrect),
            OverallAccuracy = Math.Round(
                (double)userResults.Count(r => r.IsCorrect) / userResults.Count * 100, 2),
            SubCategoryPerformances = subCategoryPerformances
                .OrderByDescending(p => p.LastAttemptDate)
                .ToList()
        };


    }

    public async Task<AICoachFeedbackDto> GenerateCoachFeedbackAsync(string userId)
    {
        // Get the user's quiz summary
        var summary = await GetUserQuizSummaryAsync(userId);

        if(summary.TotalQuestionsAnswered == 0)
        {
            return new AICoachFeedbackDto
            {
                OverallAssessment = "No quiz attempts yet",
                Strengths = new List<string>(),
                Weaknesses = new List<string>(),
                Recommendations = new List<RecommendationDto>(),
                MotivationalMessage = "Start taking quizzes to get personalized feedback and improve your cybersecurity knowledge!",
                GeneratedAt = DateTime.UtcNow
            };
        }

        // Build the prompt for the AI model based on the user's quiz summary
        var prompt = BuildAIPrompt(summary);
        // Send the prompt to the AI model and get the response
        var aiResponse = await SendToAIModelAsync(prompt);

        var feedback = ParseAIResponse(aiResponse, summary);

        return feedback;
    }

    private string BuildAIPrompt(UserQuizSummaryDto summary)
    {
        // Build a detailed prompt for the AI model using the user's quiz summary
        var sb = new StringBuilder();
        // Provide context and instructions to the AI model
        sb.AppendLine("You are an AI coach for cybersecurity. Analyze the following user data and provide personalized feedback:");
        sb.AppendLine();
        sb.AppendLine("**Overall Statistics:**");
        sb.AppendLine($"- Total questions answered: {summary.TotalQuestionsAnswered}");
        sb.AppendLine($"- Correct answers: {summary.TotalCorrectAnswers}");
        sb.AppendLine($"- Overall accuracy: {summary.OverallAccuracy}%");
        sb.AppendLine();
        sb.AppendLine("**Performance per category:**");

        // Add details for each subcategory
        foreach (var perf in summary.SubCategoryPerformances)
        {
            sb.AppendLine($"- {perf.CategoryName} > {perf.SubCategoryName}:");
            sb.AppendLine($"  * Attempted: {perf.QuestionsAttempted}/{perf.TotalAvailableQuestions} questions");
            sb.AppendLine($"  * Accuracy: {perf.AccuracyPercentage}%");
            sb.AppendLine($"  * Last attempt: {perf.LastAttemptDate:yyyy-MM-dd}");
        }
        // Instructions for the AI model on how to structure the feedback
        sb.AppendLine();
        sb.AppendLine("Provide feedback in the following JSON format:");
        sb.AppendLine("{");
        sb.AppendLine("  \"overallAssessment\": \"Brief overall assessment (2-3 sentences)\",");
        sb.AppendLine("  \"strengths\": [\"Strength 1\", \"Strength 2\"],");
        sb.AppendLine("  \"weaknesses\": [\"Weakness 1\", \"Weakness 2\"],");
        sb.AppendLine("  \"recommendations\": [");
        sb.AppendLine("    {\"subCategoryName\": \"Name\", \"reason\": \"Why\", \"priority\": 1}");
        sb.AppendLine("  ],");
        sb.AppendLine("  \"motivationalMessage\": \"Encouraging message\"");
        sb.AppendLine("}");

        return sb.ToString();
    }

    private async Task<string> SendToAIModelAsync(string prompt)
    {
        // Prepare the request body for the AI model
        var requestBody = new
        {
            model = "phi3",
            prompt = prompt,
            stream = false
        };
        // Serialize the request body to JSON
        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        // Send the request to the AI model and handle potential errors
        try
        {
            var response = await _httpClient.PostAsync("/api/generate", content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<OllamaResponse>(responseJson);

            return result?.Response ?? string.Empty;
        }
        catch (Exception)
        {
            // If AI is not available, use fallback
            return GenerateFallbackResponse();
        }
    }

    private AICoachFeedbackDto ParseAIResponse(string aiResponse, UserQuizSummaryDto summary)
    {
        try
        {
            // Try to find JSON in the AI response
            var jsonStart = aiResponse.IndexOf('{');
            var jsonEnd = aiResponse.LastIndexOf('}') + 1;

            if (jsonStart >= 0 && jsonEnd > jsonStart)
            {
                var jsonString = aiResponse.Substring(jsonStart, jsonEnd - jsonStart);
                var parsed = JsonSerializer.Deserialize<AICoachResponse>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (parsed != null)
                {
                    return new AICoachFeedbackDto
                    {
                        OverallAssessment = parsed.OverallAssessment,
                        Strengths = parsed.Strengths,
                        Weaknesses = parsed.Weaknesses,
                        Recommendations = parsed.Recommendations.Select((r, index) => new RecommendationDto
                        {
                            SubCategoryId = FindSubCategoryId(r.SubCategoryName, summary),
                            SubCategoryName = r.SubCategoryName,
                            CategoryName = FindCategoryName(r.SubCategoryName, summary),
                            Reason = r.Reason,
                            Priority = r.Priority > 0 ? r.Priority : index + 1
                        }).ToList(),
                        MotivationalMessage = parsed.MotivationalMessage,
                        GeneratedAt = DateTime.UtcNow
                    };
                }
            }
        }
        catch
        {
            // If parsing fails, use rule-based feedback
        }

        // Fallback: use rule-based feedback
        return GenerateRuleBasedFeedback(summary);
    }

    private string GenerateFallbackResponse()
    {
        return @"{
            ""overallAssessment"": ""Good progress so far! You're making strides in your cybersecurity education."",
            ""strengths"": [""You show dedication by practicing regularly""],
            ""weaknesses"": [""Continue practicing to improve your accuracy""],
            ""recommendations"": [],
            ""motivationalMessage"": ""Keep practicing and you'll become even better!""
        }";
    }

    private AICoachFeedbackDto GenerateRuleBasedFeedback(UserQuizSummaryDto summary)
    {
        var feedback = new AICoachFeedbackDto();

        // Overall assessment
        if (summary.OverallAccuracy >= 80)
            feedback.OverallAssessment = $"Excellent work! With {summary.OverallAccuracy}% accuracy, you demonstrate strong cybersecurity knowledge.";
        else if (summary.OverallAccuracy >= 60)
            feedback.OverallAssessment = $"Good job! Your {summary.OverallAccuracy}% accuracy shows you're on the right track.";
        else
            feedback.OverallAssessment = $"You're making progress! With {summary.OverallAccuracy}% accuracy, there's great potential to improve.";

        // Strengths - areas with 75%+ accuracy
        var strongAreas = summary.SubCategoryPerformances
            .Where(p => p.AccuracyPercentage >= 75)
            .OrderByDescending(p => p.AccuracyPercentage)
            .Take(3);

        foreach (var area in strongAreas)
        {
            feedback.Strengths.Add($"{area.CategoryName} - {area.SubCategoryName} ({area.AccuracyPercentage}%)");
        }

        if (!feedback.Strengths.Any())
        {
            feedback.Strengths.Add("You show dedication by practicing");
        }

        // Weaknesses - areas with less than 60% accuracy
        var weakAreas = summary.SubCategoryPerformances
            .Where(p => p.AccuracyPercentage < 60)
            .OrderBy(p => p.AccuracyPercentage)
            .Take(3);

        foreach (var area in weakAreas)
        {
            feedback.Weaknesses.Add($"{area.CategoryName} - {area.SubCategoryName} ({area.AccuracyPercentage}%)");
        }

        // Recommendations - areas that need attention
        var recommendations = summary.SubCategoryPerformances
            .Where(p => p.QuestionsAttempted < p.TotalAvailableQuestions || p.AccuracyPercentage < 70)
            .OrderBy(p => p.AccuracyPercentage)
            .ThenByDescending(p => p.TotalAvailableQuestions - p.QuestionsAttempted)
            .Take(5);

        int priority = 1;
        foreach (var rec in recommendations)
        {
            var reason = rec.AccuracyPercentage < 60
                ? $"Low accuracy ({rec.AccuracyPercentage}%) - needs more practice"
                : $"Only {rec.QuestionsAttempted} of {rec.TotalAvailableQuestions} questions attempted";

            feedback.Recommendations.Add(new RecommendationDto
            {
                SubCategoryId = rec.SubCategoryId,
                SubCategoryName = rec.SubCategoryName,
                CategoryName = rec.CategoryName,
                Reason = reason,
                Priority = priority++
            });
        }

        // Motivational message
        feedback.MotivationalMessage = summary.OverallAccuracy >= 80
            ? "Fantastic! You're on your way to mastering cybersecurity. Keep it up!"
            : "Every question you answer makes you stronger in cybersecurity. Keep practicing!";

        feedback.GeneratedAt = DateTime.UtcNow;

        return feedback;
    }

    private int FindSubCategoryId(string subCategoryName, UserQuizSummaryDto summary)
    {
        var perf = summary.SubCategoryPerformances
            .FirstOrDefault(p => p.SubCategoryName.Equals(subCategoryName, StringComparison.OrdinalIgnoreCase));
        return perf?.SubCategoryId ?? 0;
    }
    private string FindCategoryName(string subCategoryName, UserQuizSummaryDto summary)
    {
        var perf = summary.SubCategoryPerformances
            .FirstOrDefault(p => p.SubCategoryName.Equals(subCategoryName, StringComparison.OrdinalIgnoreCase));
        return perf?.CategoryName ?? string.Empty;
    }

    private class OllamaResponse
    {
        public string Response { get; set; } = string.Empty;
    }


    private class AICoachResponse
    {
        public string OverallAssessment { get; set; } = string.Empty;
        public List<string> Strengths { get; set; } = new();
        public List<string> Weaknesses { get; set; } = new();
        public List<AIRecommendation> Recommendations { get; set; } = new();
        public string MotivationalMessage { get; set; } = string.Empty;
    }

    private class AIRecommendation
    {
        public string SubCategoryName { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public int Priority { get; set; }
    }




}