using CyberQuiz.Shared.DTOs.Progress;

namespace CyberQuiz.Shared.DTOs.Profile
{
    public class UserProfileDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime MemberSince { get; set; }

        // Statistics
        public int TotalQuestionsAttempted { get; set; }
        public int TotalCorrectAnswers { get; set; }
        public decimal OverallAccuracy { get; set; }
        public int CompletedSubCategories { get; set; }
        public int TotalSubCategories { get; set; }
        
        // Progress
        public List<CategoryProgressDto> CategoryProgress { get; set; }
    }
    
    public class CategoryProgressDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<SubCategoryProgressDto> SubCategories { get; set; }
        public decimal CategoryCompletionPercent { get; set; }
    }
}