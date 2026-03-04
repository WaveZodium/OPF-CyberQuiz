using CyberQuiz.Application.DTOs;
using CyberQuiz.Application.Interfaces;
using CyberQuiz.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CyberQuiz.Application.Services
{
    public class ProgressCalculator : IProgressCalculator
    {
        private readonly ApplicationDbContext _db;

        public ProgressCalculator(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<SubCategoryProgressDto> GetSubCategoryProgressAsync(int subCategoryId, string userId)
        {
            int totalQuestions = await _db.Questions
                .Where(q => q.SubCategoryId == subCategoryId)
                .CountAsync();

            if (totalQuestions == 0)
            {
                return new SubCategoryProgressDto
                {
                    SubCategoryId = subCategoryId,
                    TotalQuestions = 0,
                    TotalAttempts = 0,
                    CorrectAttempts = 0,
                    PercentCorrect = 0m,
                    HasAttemptedAllQuestions = false,
                    IsCompleted = false
                };
            }

            var resultsQuery = _db.UserResults
                .Where(r => r.UserId == userId && r.SubCategoryId == subCategoryId);

            int totalAttempts = await resultsQuery.CountAsync();
            int correctAttempts = await resultsQuery.CountAsync(r => r.IsCorrect);

            int attemptedDistinctQuestions = await resultsQuery
                .Select(r => r.QuestionId)
                .Distinct()
                .CountAsync();

            bool hasAttemptedAllQuestions = attemptedDistinctQuestions >= totalQuestions;

            decimal percentCorrect = totalAttempts == 0
                ? 0m
                : (decimal)correctAttempts / totalAttempts;

            bool isCompleted = hasAttemptedAllQuestions && percentCorrect >= 0.80m;

            return new SubCategoryProgressDto
            {
                SubCategoryId = subCategoryId,
                TotalQuestions = totalQuestions,
                TotalAttempts = totalAttempts,
                CorrectAttempts = correctAttempts,
                PercentCorrect = percentCorrect,
                HasAttemptedAllQuestions = hasAttemptedAllQuestions,
                IsCompleted = isCompleted
            };
        }
    }
}
