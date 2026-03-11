using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Shared.DTOs.AiChat
{
    public class QuizHelpRequestDto
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string? UserAnswer { get; set; }
        public string CorrectAnswer { get; set; } = string.Empty;
        public string? Explanation { get; set; }
        public bool WasUserAnswerCorrect { get; set; }
    }
}
