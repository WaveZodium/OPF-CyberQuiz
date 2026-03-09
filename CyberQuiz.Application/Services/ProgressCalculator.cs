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

        public ProgressCalculator(IQuestionRepository questionRepo, IUserResultRepository userResultRepo)
        {
            _questionRepo = questionRepo;
            _userResultRepo = userResultRepo;
        }

        public async Task<SubCategoryProgressDto> GetSubCategoryProgressAsync(int subCategoryId, string userId)
        {
            int totalQuestions = await _questionRepo.CountQuestionsInSubCategoryAsync(subCategoryId);

            if (totalQuestions == 0)
            {
                return new SubCategoryProgressDto
                {
                    SubCategoryId = subCategoryId,
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

            decimal percentCorrect = totalAttempts == 0
                ? 0m
                : (decimal)correctAttempts / totalAttempts * 100m;

            decimal progressPercent = (decimal)attemptedDistinctQuestions / totalQuestions * 100m;

            bool isCompleted = hasAttemptedAllQuestions && percentCorrect >= 0.80m;

            return new SubCategoryProgressDto
            {
                SubCategoryId = subCategoryId,
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
