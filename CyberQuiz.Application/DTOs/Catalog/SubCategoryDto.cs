using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Application.DTOs.Catalog
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int OrderIndex { get; set; }

        public bool IsLocked { get; set; }
        public bool IsCompleted { get; set; }

        public decimal PercentCorrect { get; set; }

        public int TotalQuestions { get; set; }
    }
}
