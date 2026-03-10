using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Shared.DTOs.Progress
{
    public class SubCategoryProgressDto
    {
        public int SubCategoryId { get; set; }

        public int TotalQuestions { get; set; }

        // "Alla försök"
        public int TotalAttempts { get; set; }
        public int CorrectAttempts { get; set; }

        // 0.00 - 1.00 (UI kan visa 0–100%)
        public decimal PercentCorrect { get; set; }

        public decimal PercentAnswered { get; set; }

        // guard: har user försökt alla frågor minst en gång?
        public bool HasAttemptedAllQuestions { get; set; }

        // 80%-regel + guard
        public bool IsCompleted { get; set; }
        public decimal ProgressPercent { get; set; }
    }
}
