using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Infrastructure.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public string? Explanation { get; set; }
        public int OrderIndex { get; set; }

        //FK
        public int SubCategoryId { get; set; }

        //Navigation back to SubCategory (many to one)
        public SubCategory SubCategory { get; set; } = null!;

        //Navigation to AnswerOptions (one to many)
        public List<AnswerOption> AnswerOptions { get; set; } = new();
    }
}
