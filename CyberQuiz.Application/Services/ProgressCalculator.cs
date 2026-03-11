using CyberQuiz.Application.Interfaces;
using CyberQuiz.Infrastructure.Data;
using CyberQuiz.Infrastructure.Repositories;
using CyberQuiz.Shared.DTOs.Progress;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Application.Services
{
    public class ProgressCalculator : IProgressCalculator
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IUserResultRepository _userResultRepo;
        private readonly ISubCategoryRepository _subCategoryRepo;

        public ProgressCalculator(
            IQuestionRepository questionRepo,
            IUserResultRepository userResultRepo,
            ISubCategoryRepository subCategoryRepo)
        {
            _questionRepo = questionRepo;
            _userResultRepo = userResultRepo;
            _subCategoryRepo = subCategoryRepo;
        }

        public async Task<SubCategoryProgressDto> GetSubCategoryProgressAsync(int subCategoryId, string userId)
        {
            var subCategory = await _subCategoryRepo.GetByIdAsync(subCategoryId);
            var subCategoryName = subCategory?.Name ?? string.Empty;

            int totalQuestions = await _questionRepo.CountQuestionsInSubCategoryAsync(subCategoryId);

            if (totalQuestions == 0)
            {
                return new SubCategoryProgressDto
                {
                    SubCategoryId = subCategoryId,
                    SubCategoryName = subCategoryName,
                    TotalQuestions = 0,
                    TotalAttempts = 0,
                    CorrectAttempts = 0,
                    PercentCorrect = 0m,
                    ProgressPercent = 0m,
                    HasAttemptedAllQuestions = false,
                    IsCompleted = false
                };
            }

            int totalAttempts = await _userResultRepo.CountTotalAnswersAsync(userId, subCategoryId);
            int correctAttempts = await _userResultRepo.CountCorrectAnswersAsync(userId, subCategoryId);
            int attemptedDistinctQuestions = await _userResultRepo.CountDistinctQuestionsAttemptedAsync(userId, subCategoryId);

            bool hasAttemptedAllQuestions = attemptedDistinctQuestions >= totalQuestions;

            decimal percentCorrect = totalQuestions == 0
                ? 0m
                : (decimal)correctAttempts / totalQuestions * 100m;

            decimal progressPercent = (decimal)attemptedDistinctQuestions / totalQuestions * 100m;

            bool isCompleted = hasAttemptedAllQuestions && percentCorrect >= 80m;

            return new SubCategoryProgressDto
            {
                SubCategoryId = subCategoryId,
                SubCategoryName = subCategoryName,
                TotalQuestions = totalQuestions,
                TotalAttempts = totalAttempts,
                CorrectAttempts = correctAttempts,
                PercentCorrect = percentCorrect,
                ProgressPercent = progressPercent,
                HasAttemptedAllQuestions = hasAttemptedAllQuestions,
                IsCompleted = isCompleted
            };
        }
    }
}
