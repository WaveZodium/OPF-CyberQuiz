namespace CyberQuiz.Shared.DTOs.Progress
{
    public class CategoryProgressDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public List<SubCategoryProgressDto> SubCategories { get; set; } = new();

        public decimal CategoryCompletionPercent { get; set; }

        public int CompletedSubCategoriesCount { get; set; }
        
        public int TotalSubCategoriesCount { get; set; }
        public int ProgressPercent { get; set; }
    }
}