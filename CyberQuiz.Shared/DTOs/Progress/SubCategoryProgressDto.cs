using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Shared.DTOs.Progress
{
    public class SubCategoryProgressDto
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; } = string.Empty;

        public int TotalQuestions { get; set; }

        public int TotalAttempts { get; set; }
        public int CorrectAttempts { get; set; }
        public decimal PercentCorrect { get; set; }

        public decimal PercentAnswered { get; set; }

        public bool HasAttemptedAllQuestions { get; set; }

        public bool IsCompleted { get; set; }
        public decimal ProgressPercent { get; set; }
    }
}
