using CyberQuiz.Infrastructure.Data;
using CyberQuiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CyberQuiz.Infrastructure.Repositories;

public class AnswerRepository : IAnswerRepository
{
    private readonly ApplicationDbContext _context;

    public AnswerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AnswerOption?> GetByIdAsync(int id)
    {
        return await _context.AnswerOptions
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<AnswerOption>> GetByQuestionIdAsync(int questionId)
    {
        return await _context.AnswerOptions
            .Where(a => a.QuestionId == questionId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(AnswerOption option)
    {
        await _context.AnswerOptions.AddAsync(option);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AnswerOption option)
    {
        _context.AnswerOptions.Update(option);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.AnswerOptions.FindAsync(id);
        if (entity is null)
            return;

        _context.AnswerOptions.Remove(entity);
        await _context.SaveChangesAsync();
    }
}