namespace CyberQuiz.Shared.DTOs.Quiz;

public class QuestionReviewDto
{
    public int QuestionId { get; set; }
    public string QuestionText { get; set; } = "";
    public int? SelectedAnswerOptionId { get; set; }
    public int? CorrectAnswerOptionId { get; set; }
    public bool IsCorrect { get; set; }
    public List<AnswerOptionReviewDto> AnswerOptions { get; set; }
    public string? Explanation { get; set; }
    public int OrderIndex { get; set; }
    public int NextSubCategoryId { get; set; }
    public int NextCategoryId { get; set; }
}

public class AnswerOptionReviewDto
{
    public int Id { get; set; }
    public string Text { get; set; } = "";
    public bool IsCorrect { get; set; } 
    public bool IsSelectedByUser { get; set; }  
}