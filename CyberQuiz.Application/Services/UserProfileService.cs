using CyberQuiz.Application.Interfaces;
using CyberQuiz.Infrastructure.Entities;
using CyberQuiz.Infrastructure.Repositories;
using CyberQuiz.Shared.DTOs.Profile;
using CyberQuiz.Shared.DTOs.Progress;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using CyberQuiz.Shared.Exceptions; // ← LÄGG TILL

namespace CyberQuiz.Application.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserResultRepository _userResultRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly ISubCategoryRepository _subCategoryRepo;
        private readonly IProgressCalculator _progressCalculator;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserProfileService(
            IUserResultRepository userResultRepo,
            ICategoryRepository categoryRepo,
            ISubCategoryRepository subCategoryRepo,
            IProgressCalculator progressCalculator,
            UserManager<ApplicationUser> userManager)
        {
            _userResultRepo = userResultRepo;
            _categoryRepo = categoryRepo;
            _subCategoryRepo = subCategoryRepo;
            _progressCalculator = progressCalculator;
            _userManager = userManager;
        }

        public async Task<UserProfileDto> GetUserProfileAsync(string userId)
        {
            // Get user info
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException($"User with ID {userId} not found"); // ← Custom exception!
            }

            // Get the stats
            int totalAttempts = await _userResultRepo.CountTotalAnswersForUserAsync(userId);
            int correctAttempts = await _userResultRepo.CountCorrectAnswersForUserAsync(userId);
            int distinctQuestionsAttempted = await _userResultRepo.CountDistinctQuestionsAttemptedForUserAsync(userId);

            // Calculate overall accuracy
            decimal overallAccuracy = totalAttempts == 0
                ? 0m
                : (decimal)correctAttempts / totalAttempts * 100m;

            // Get category progress
            var categoryProgress = await GetUserProgressByAllCategoriesAsync(userId);

            // Count completed subcategories( IsCompleted = 80% and all questions attempted)
            int completedSubCategories = categoryProgress
                .SelectMany(cat => cat.SubCategories)
                .Count(sub => sub.IsCompleted);

            int totalSubCategories = categoryProgress
                .SelectMany(cat => cat.SubCategories)
                .Count();

            return new UserProfileDto
            {
                UserId = userId,
                UserName = user.UserName ?? "Unknown",
                Email = user.Email ?? "No email",
                MemberSince = user.CreatedAt,
                TotalQuestionsAttempted = distinctQuestionsAttempted,
                TotalCorrectAnswers = correctAttempts,
                OverallAccuracy = overallAccuracy,
                CompletedSubCategories = completedSubCategories,
                TotalSubCategories = totalSubCategories,

                CategoryProgress = categoryProgress
            };
        }

        public async Task<List<CategoryProgressDto>> GetUserProgressByAllCategoriesAsync(string userId)
        {
            // Get all categories with their subcategories
            var categories = await _categoryRepo.GetAllCategoriesWithSubCategoriesAsync();
            //  Creates a empty list to hold the progress data for each category
            var result = new List<CategoryProgressDto>();
            // Loops through each category
            foreach (var category in categories)
            {
                var subCategoryProgressList = new List<SubCategoryProgressDto>();
                // Loops through each subcategory in the current category, ordered by their OrderIndex
                foreach (var subCategory in category.SubCategories.OrderBy(sc => sc.OrderIndex))
                {
                    // Uses the progress calculator to get the progress for the current subcategory
                    var progress = await _progressCalculator.GetSubCategoryProgressAsync(subCategory.Id, userId);
                    progress.SubCategoryName = subCategory.Name;

                    subCategoryProgressList.Add(progress);
                }

                // Counts how many subcategories in the current category are completed
                int completedCount = subCategoryProgressList.Count(sp => sp.IsCompleted);
                // Count How many subcategories in the current category
                int totalCount = subCategoryProgressList.Count;

                // Calculates the completion percentage for the current category
                decimal categoryCompletionPercent = totalCount == 0
                    ? 0m
                    : (decimal)completedCount / totalCount * 100m;

                // Creates a new CategoryProgressDto object with the calculated data and adds it to the result list
                result.Add(new CategoryProgressDto
                {
                    CategoryId = category.Id,
                    CategoryName = category.Name,
                    SubCategories = subCategoryProgressList,
                    CategoryCompletionPercent = categoryCompletionPercent,
                    CompletedSubCategoriesCount = completedCount,
                    TotalSubCategoriesCount = totalCount,
                });


            }

            return result;

        }
    }
}
