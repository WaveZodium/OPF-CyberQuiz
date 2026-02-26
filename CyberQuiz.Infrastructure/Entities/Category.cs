using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Infrastructure.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        //Navigation to SubCategories (one to many)
        public List<SubCategory> SubCategories { get; set; } = new();
    }
}
