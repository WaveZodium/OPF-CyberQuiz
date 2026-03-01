using CyberQuiz.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Infrastructure.Repositories
{
    public interface IQuestionRepository
    {
        Task<Question?> GetByIdAsync(int id);
        Task<List<Question>> GetBySubCategoryAsync(int subCategoryId);
        Task AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(int id);
    }
}
