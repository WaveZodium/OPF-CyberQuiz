using CyberQuiz.Application.Interfaces;
using CyberQuiz.Infrastructure.Entities;
using CyberQuiz.Infrastructure.Repositories;
using CyberQuiz.Shared.DTOs.Catalog;
using CyberQuiz.Shared.DTOs.Quiz;
using CyberQuiz.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Application.Services
{
    public class QuizService : IQuizService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly ISubCategoryRepository _subCategoryRepo;
        private readonly IQuestionRepository _questionRepo;
        private readonly IAnswerRepository _answerRepo;
        private readonly IUserResultRepository _userResultRepo;
        private readonly IProgressCalculator _progress;

        public QuizService(
            ICategoryRepository categoryRepo,
            ISubCategoryRepository subCategoryRepo,
            IQuestionRepository questionRepo,
            IAnswerRepository answerRepo,
            IUserResultRepository userResultRepo,
            IProgressCalculator progress)
        {
            _categoryRepo = categoryRepo;
            _subCategoryRepo = subCategoryRepo;
            _questionRepo = questionRepo;
            _answerRepo = answerRepo;
            _userResultRepo = userResultRepo;
            _progress = progress;
        }

        public async Task<List<CategoryDto>> GetCategoriesForUserAsync(string userId)
        {
            var categories = await _categoryRepo.GetAllCategoriesWithSubCategoriesAsync();
            var result = new List<CategoryDto>();

            foreach (var category in categories)
            {
                var orderedSubs = category.SubCategories
                    . OrderBy(sc => sc.OrderIndex)
                    .ToList();

                var subCategoryDtos = new List<SubCategoryDto>();
                bool previousCompleted = true;

                foreach (var sub in orderedSubs)
                {
                    // Recives the progress for the subcategory and user
                    var progress = await _progress.GetSubCategoryProgressAsync(sub.Id, userId);

                    bool isLocked = !previousCompleted; // A subcategory is locked if the previous one is not completed

                    subCategoryDtos.Add(new SubCategoryDto
                    {
                        Id = sub.Id,
                        Name = sub.Name,
                        OrderIndex = sub.OrderIndex,
                        IsLocked = isLocked,
                        IsCompleted = progress.IsCompleted,
                        PercentCorrect = progress.PercentCorrect,
                        TotalQuestions = progress.TotalQuestions
                    });

                    previousCompleted = progress.IsCompleted;
                }

                result.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    SubCategories = subCategoryDtos
                });
            }

            return result;
        }

        public async Task<List<QuestionDto>> GetQuestionsAsync(int subCategoryId, string userId)
        {
            var questions = await _questionRepo.GetBySubCategoryAsync(subCategoryId);

            if (questions is null || questions.Count == 0)
                return [];

            var result = new List<QuestionDto>(questions.Count);

            foreach (var question in questions)
            {
                var options = await _answerRepo.GetByQuestionIdAsync(question.Id);

                result.Add(new QuestionDto
                {
                    QuestionId = question.Id,
                    Text = question.Text,
                    AnswerOptions = options.Select(o => new AnswerOptionDto
                    {
                        Id = o.Id,
                        Text = o.Text
                    }).ToList()
                });
            }

            return result;
        }

        public async Task<QuestionDto?> GetNextQuestionAsync(int subCategoryId, string userId)
        {
            var questions = await _questionRepo.GetBySubCategoryAsync(subCategoryId);

            // If repository returns null, technical error
            if (questions is null)
                throw new NotFoundException($"Question not found.");

            // If no questions exist in database for this subcategory
            if (questions.Count == 0)
                throw new ValidationException($"No questions available for subcategory {subCategoryId}.");

            // Get the list of question ids that the user has already answered for the subcategory
            var answeredQuestionIds = await _userResultRepo.GetAnsweredQuestionIdsAsync(userId, subCategoryId);

            // Find the first question that the user has not answered yet
            var nextQuestion = questions.FirstOrDefault(q => !answeredQuestionIds.Contains(q.Id));

            if (nextQuestion is null)
            {
                // Check if there are more subcategories in the same category
                var subCategory = await _subCategoryRepo.GetByIdAsync(subCategoryId);
                if (subCategory is null)
                    throw new NotFoundException($"Subcategory {subCategoryId} not found.");

                var allSubCategories = await _subCategoryRepo.GetByCategoryAsync(subCategory.CategoryId);
                var orderedSubCategories = allSubCategories.OrderBy(s => s.OrderIndex).ToList();

                var currentIndex = orderedSubCategories.FindIndex(s => s.Id == subCategoryId);
                var hasMoreSubCategories = currentIndex >= 0 && currentIndex < orderedSubCategories.Count - 1;

                if (!hasMoreSubCategories)
                {
                    // Last subcategory - no more questions in entire category
                    throw new DomainException("No more questions available in this category. You have completed all subcategories!");
                }

                // More subcategories exist - subcategory completed
                return null;
            }


            var options = await _answerRepo.GetByQuestionIdAsync(nextQuestion.Id); // Get answer options for the question

            return new QuestionDto
            {
                QuestionId = nextQuestion.Id,
                Text = nextQuestion.Text,
                AnswerOptions = options.Select(o => new AnswerOptionDto
                {
                    Id = o.Id,
                    Text = o.Text
                }).ToList()
            };
        }

        public async Task<SubmitAnswerResponseDto> SubmitAnswerAsync(SubmitAnswerRequestDto dto, string userId)
        {
            var question = await _questionRepo.GetByIdAsync(dto.QuestionId);

            if (question is null)
                throw new NotFoundException($"Question {dto.QuestionId} not found.");

            if (question.SubCategoryId != dto.SubCategoryId)
                throw new ValidationException($"Question {dto.QuestionId} does not belong to subcategory {dto.SubCategoryId}.");

            var selectedOption = await _answerRepo.GetByIdAsync(dto.SelectedAnswerOptionId);
            if (selectedOption is null)
                throw new NotFoundException($"Answer option {dto.SelectedAnswerOptionId} not found.");

            bool isCorrect = selectedOption.IsCorrect;

            int? correctAnswerOptionId = null;
            var allOptions = await _answerRepo.GetByQuestionIdAsync(dto.QuestionId);
            var correctOption = allOptions.FirstOrDefault(o => o.IsCorrect);
            correctAnswerOptionId = correctOption?.Id;

            var userResult = new UserResult
            {
                UserId = userId,
                SubCategoryId = dto.SubCategoryId,
                QuestionId = dto.QuestionId,
                SelectedAnswerOptionId = dto.SelectedAnswerOptionId,
                IsCorrect = isCorrect,
                AnsweredAtUtc = DateTime.UtcNow
            };

            await _userResultRepo.AddAsync(userResult);

            var progress = await _progress.GetSubCategoryProgressAsync(dto.SubCategoryId, userId);

            // Get the next question after submitting the answer
            try
            {
                IsCorrect = isCorrect,
                CorrectAnswerOptionId = correctAnswerOptionId,
                Progress = progress
            };
        }
    }
}
