using CyberQuiz.Infrastructure.Data;
using CyberQuiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Infrastructure.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public SubCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // SubCategory operations
        public async Task<SubCategory?> GetByIdAsync(int id)
        {
            return await _context.SubCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(sc => sc.Id == id);
        }

        public async Task<List<SubCategory>> GetByCategoryAsync(int categoryId)
        {
            return await _context.SubCategories
                .Where(sc => sc.CategoryId == categoryId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<SubCategory>> GetAllAsync()
        {
            return await _context.SubCategories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(SubCategory subCategory)
        {
            await _context.SubCategories.AddAsync(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubCategory subCategory)
        {
            _context.SubCategories.Update(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory is null) return;        
                _context.SubCategories.Remove(subCategory);
                await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.SubCategories.AnyAsync(sc => sc.Id == id);
        }
    }
}
