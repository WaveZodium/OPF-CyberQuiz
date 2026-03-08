namespace CyberQuiz.Shared.DTOs.AICoach;

public class AICoachFeedbackDto
{
    public string OverallAssessment { get; set; } = string.Empty;
    public List<string> Strengths { get; set; } = new();
    public List<string> Weaknesses { get; set; } = new();
    public List<RecommendationDto> Recommendations { get; set; } = new();
    public string MotivationalMessage { get; set; } = string.Empty;
    public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
}

public class RecommendationDto
{
    public int SubCategoryId { get; set; }
    public string SubCategoryName { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public int Priority { get; set; }
}