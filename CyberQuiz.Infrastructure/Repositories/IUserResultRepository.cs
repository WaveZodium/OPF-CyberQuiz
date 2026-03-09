using CyberQuiz.Infrastructure.Entities;

namespace CyberQuiz.Infrastructure.Repositories;

public interface IUserResultRepository
{
    Task<UserResult?> GetByIdAsync(int id);
    Task<List<UserResult>> GetByUserAsync(string userId);
    Task<List<UserResult>> GetBySubCategoryAsync(string userId, int subCategoryId);
    Task<UserResult?> GetByUserAndQuestionAsync(string userId, int questionId);
    Task AddAsync(UserResult result);
    Task UpdateAsync(UserResult result);
    Task DeleteAsync(int id);
    Task DeleteBySubCategoryAsync(string userId, int subCategoryId);

    // Extra queries som behövs för progression
    Task<int> CountCorrectAnswersAsync(string userId, int subCategoryId);
    Task<int> CountTotalAnswersAsync(string userId, int subCategoryId);
    Task<int> CountDistinctQuestionsAttemptedAsync(string userId, int subCategoryId);
    Task<List<int>> GetAnsweredQuestionIdsAsync(string userId, int subCategoryId);

    //Global
    Task<int> CountTotalAnswersForUserAsync(string userId);
    Task<int> CountCorrectAnswersForUserAsync(string userId);
    Task<int> CountDistinctQuestionsAttemptedForUserAsync(string userId);
}