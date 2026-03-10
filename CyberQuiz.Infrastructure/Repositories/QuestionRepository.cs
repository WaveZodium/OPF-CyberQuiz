using CyberQuiz.Infrastructure.Data;
using CyberQuiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CyberQuiz.Infrastructure.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly ApplicationDbContext _context;

    public QuestionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Question?> GetByIdAsync(int id)
    {
        return await _context.Questions
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<List<Question>> GetBySubCategoryAsync(int subCategoryId)
    {
        return await _context.Questions
            .Where(q => q.SubCategoryId == subCategoryId)
            .OrderBy(q => q.OrderIndex)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Question>> GetQuestionsWithAnswersAsync(int subCategoryId)
    {
        return await _context.Questions
            .Where(q => q.SubCategoryId == subCategoryId)
            .Include(q => q.AnswerOptions)
            .OrderBy(q => q.OrderIndex)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(Question question)
    {
        await _context.Questions.AddAsync(question);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Question question)
    {
        _context.Questions.Update(question);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Questions.FindAsync(id);
        if (entity is null)
            return;

        _context.Questions.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public Task<int> CountQuestionsInSubCategoryAsync(int subCategoryId)
    {
        return _context.Questions
            .Where(q => q.SubCategoryId == subCategoryId)
            .CountAsync();
    }
}