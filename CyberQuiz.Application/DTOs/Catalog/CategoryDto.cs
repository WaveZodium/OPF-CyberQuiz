using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Application.DTOs.Catalog
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<SubCategoryDto> SubCategories { get; set; } = new();
    }
}
