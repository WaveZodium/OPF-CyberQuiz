using CyberQuiz.Shared.DTOs.Progress;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Shared.DTOs.Quiz
{
    public class SubmitAnswerResponseDto
    {
        public bool IsCorrect { get; set; }
        public int? CorrectAnswerOptionId { get; set; } // valfritt men nice för UI
        public SubCategoryProgressDto Progress { get; set; } = new();

        public QuestionDto? NextQuestion { get; set; }
    }
}
