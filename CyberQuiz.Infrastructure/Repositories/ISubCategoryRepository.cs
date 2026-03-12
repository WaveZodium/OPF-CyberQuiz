using CyberQuiz.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Infrastructure.Repositories
{
    public interface ISubCategoryRepository
    {
      
        Task<SubCategory?> GetByIdAsync(int id);
        Task<List<SubCategory>> GetByCategoryAsync(int cId);
        Task AddAsync(SubCategory subCategory);
        Task UpdateAsync(SubCategory subCategory);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<int?> GetNextSubCategoryAsync(int currentSubCategoryId);
    }
}
