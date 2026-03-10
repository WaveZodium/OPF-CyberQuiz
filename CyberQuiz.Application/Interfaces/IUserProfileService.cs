using CyberQuiz.Shared.DTOs.Profile;
using CyberQuiz.Shared.DTOs.Progress;

namespace CyberQuiz.Application.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfileDto> GetUserProfileAsync(string userId);
        Task<List<CategoryProgressDto>> GetUserProgressByAllCategoriesAsync(string userId);
    }
}