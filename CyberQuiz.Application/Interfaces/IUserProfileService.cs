using CyberQuiz.Shared.DTOs.Profile;

namespace CyberQuiz.Application.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfileDto> GetUserProfileAsync(string userId);
        Task<UserProfileDto> UpdateUserProfileAsync(string userId, UpdateUserProfileDto dto);
        Task<List<CategoryProgressDto>> GetUserProgressByAllCategoriesAsync(string userId);
        Task<UserStatisticsDto> GetUserStatisticsAsync(string userId);
    }
}