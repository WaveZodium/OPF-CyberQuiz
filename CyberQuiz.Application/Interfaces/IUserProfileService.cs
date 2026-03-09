using CyberQuiz.Shared.DTOs.Profile;

namespace CyberQuiz.Application.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfileDto> GetUserProfileAsync(string userId);
        Task<List<CategoryProgressDto>> GetUserProgressByAllCategoriesAsync(string userId);
    }
}