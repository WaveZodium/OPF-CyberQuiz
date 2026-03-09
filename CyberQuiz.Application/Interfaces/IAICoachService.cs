using CyberQuiz.Shared.DTOs.AICoach;

namespace CyberQuiz.Application.Interfaces;

public interface IAICoachService
{
    // Gets a summary of the user's quiz performance, including strengths and weaknesses.
    Task<UserQuizSummaryDto> GetUserQuizSummaryAsync(string userId);
    // Gets a summary of the user's quiz performance, including strengths and weaknesses.
    Task<AICoachFeedbackDto> GenerateCoachFeedbackAsync(string userId);
}