namespace CyberQuiz.UI.Models;

public sealed class AnswerOptionViewModel
{
    public int Id { get; init; }
    public string Text { get; init; } = "";
    public bool IsCorrect { get; init; }
    public bool IsSelectedByUser { get; init; }
}