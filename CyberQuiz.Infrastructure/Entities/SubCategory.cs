using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Infrastructure.Entities
{
    public class SubCategory
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int OrderIndex { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
        //Navigation back to Category (many to one)
        public Category Category { get; set; } = null!;

        //Navigation to Questions (one to many)
        public List<Question> Questions { get; set; } = new();
    }
}
