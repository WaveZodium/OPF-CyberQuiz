using CyberQuiz.Application.Interfaces;
using CyberQuiz.Infrastructure.Entities;
using CyberQuiz.Infrastructure.Repositories;
using CyberQuiz.Shared.DTOs.Profile;
using CyberQuiz.Shared.DTOs.Progress;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

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
        {     _userResultRepo = userResultRepo;
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
                throw new Exception($"User with ID {userId} not found");
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
           
            throw new NotImplementedException();
        }

    }
}
