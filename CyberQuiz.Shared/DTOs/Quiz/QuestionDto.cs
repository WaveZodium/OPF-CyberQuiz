using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Shared.DTOs.Quiz
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public string Text { get; set; } = "";
        public List<AnswerOptionDto> AnswerOptions { get; set; } = new();
        public bool IsLastQuestion { get; set; }
        public int OrderIndex { get; set; }
    }
}
