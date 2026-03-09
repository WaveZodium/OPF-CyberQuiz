using CyberQuiz.Infrastructure.Data;
using CyberQuiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CyberQuiz.Infrastructure.Repositories;

public class UserResultRepository : IUserResultRepository
{
    private readonly ApplicationDbContext _context;

    public UserResultRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserResult?> GetByIdAsync(int id)
    {
        return await _context.UserResults
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<UserResult>> GetByUserAsync(string userId)
    {
        return await _context.UserResults
            .Where(r => r.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<UserResult>> GetBySubCategoryAsync(string userId, int subCategoryId)
    {
        return await _context.UserResults
            .Where(r => r.UserId == userId && r.SubCategoryId == subCategoryId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(UserResult result)
    {
        await _context.UserResults.AddAsync(result);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserResult result)
    {
        _context.UserResults.Update(result);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.UserResults.FindAsync(id);
        if (entity is null)
            return;

        _context.UserResults.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<int> CountCorrectAnswersAsync(string userId, int subCategoryId)
    {
        return await _context.UserResults
            .Where(r => r.UserId == userId &&
                        r.SubCategoryId == subCategoryId &&
                        r.IsCorrect)
            .CountAsync();
    }

    public async Task<int> CountTotalAnswersAsync(string userId, int subCategoryId)
    {
        return await _context.UserResults
            .Where(r => r.UserId == userId &&
                        r.SubCategoryId == subCategoryId)
            .CountAsync();
    }

    public Task<int> CountDistinctQuestionsAttemptedAsync(string userId, int subCategoryId)
    {
        return _context.UserResults
            .Where(r => r.UserId == userId && r.SubCategoryId == subCategoryId)
            .Select(r => r.QuestionId)
            .Distinct()
            .CountAsync();
    }

    public async Task<List<int>> GetAnsweredQuestionIdsAsync(string userId, int subCategoryId)
    {
        return await _context.UserResults
            .Where(r => r.UserId == userId && r.SubCategoryId == subCategoryId)
            .Select(r => r.QuestionId)
            .Distinct()
            .ToListAsync();
    }

    public async Task<int> CountTotalAnswersForUserAsync(string userId)
    {
        return await _context.UserResults
            .Where(ur => ur.UserId == userId)
            .CountAsync();
    }

    public async Task<int> CountCorrectAnswersForUserAsync(string userId)
    {
        return await _context.UserResults
            .Where(ur => ur.UserId == userId && ur.IsCorrect)
            .CountAsync();
    }

    public async Task<int> CountDistinctQuestionsAttemptedForUserAsync(string userId)
    {
        return await _context.UserResults
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.QuestionId)
            .Distinct()
            .CountAsync();
    }
}