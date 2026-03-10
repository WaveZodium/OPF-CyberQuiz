using System.ComponentModel.DataAnnotations;

namespace CyberQuiz.Shared.DTOs.Quiz
{
    public class UpdateQuizResultRequestDto
    {
        [Range(1, int.MaxValue)]
        public int QuestionId { get; set; }

        [Range(1, int.MaxValue)]
        public int SelectedAnswerOptionId { get; set; }

        public bool IsCorrect { get; set; }
    }
}