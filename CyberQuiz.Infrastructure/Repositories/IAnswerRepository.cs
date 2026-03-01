using CyberQuiz.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Infrastructure.Repositories
{
    public interface IAnswerRepository
    {
        Task<AnswerOption?> GetByIdAsync(int id);
        Task<List<AnswerOption>> GetByQuestionIdAsync(int questionId);
        Task AddAsync(AnswerOption option);
        Task UpdateAsync(AnswerOption option);
        Task DeleteAsync(int id);
    }
}
