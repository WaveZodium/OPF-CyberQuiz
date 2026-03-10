using CyberQuiz.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Infrastructure.Repositories
{
    public interface ICategoryRepository
    {
        //Category operations
        Task<Category?> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task UpdateAsync (Category category);
        Task DeleteAsync (int id);
        Task<bool> ExistsAsync(int id);

        // Category with subcategories (för UI-visning)
        Task<Category?> GetCategoryWithSubCategoriesAsync(int id);
        Task<List<Category>> GetAllCategoriesWithSubCategoriesAsync();
    }
}
