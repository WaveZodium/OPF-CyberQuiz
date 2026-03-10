namespace CyberQuiz.Shared.DTOs.AICoach;

public class UserQuizSummaryDto
{
    public string UserId { get; set; } = string.Empty;
    public int TotalQuestionsAnswered { get; set; }
    public int TotalCorrectAnswers { get; set; }
    public double OverallAccuracy { get; set; }
    public List<SubCategoryPerformanceDto> SubCategoryPerformances { get; set; } = new();
}

public class SubCategoryPerformanceDto
{
    public int SubCategoryId { get; set; }
    public string SubCategoryName { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public int QuestionsAttempted { get; set; }
    public int CorrectAnswers { get; set; }
    public double AccuracyPercentage { get; set; }
    public int TotalAvailableQuestions { get; set; }
    public DateTime? LastAttemptDate { get; set; }
}