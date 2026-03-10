using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CyberQuiz.Shared.DTOs.Quiz
{
    public class SubmitAnswerRequestDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "SubCategoryId must be greater than 0.")]
        public int SubCategoryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "QuestionId must be greater than 0.")]
        public int QuestionId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "SelectedAnswerOptionId must be greater than 0.")]
        public int SelectedAnswerOptionId { get; set; }
    }
}
