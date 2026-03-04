using CyberQuiz.Application.DTOs.Progress;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Application.DTOs.Quiz
{
    public class SubmitAnswerResponseDto
    {
        public bool IsCorrect { get; set; }
        public int? CorrectAnswerOptionId { get; set; } // valfritt men nice för UI
        public SubCategoryProgressDto Progress { get; set; } = new();
    }
}
