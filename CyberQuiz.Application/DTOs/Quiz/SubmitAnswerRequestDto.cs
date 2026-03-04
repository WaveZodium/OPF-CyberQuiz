using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Application.DTOs.Quiz
{
    public class SubmitAnswerRequestDto
    {
        public int SubCategoryId { get; set; }
        public int QuestionId { get; set; }
        public int SelectedAnswerOptionId { get; set; }
    }
}
