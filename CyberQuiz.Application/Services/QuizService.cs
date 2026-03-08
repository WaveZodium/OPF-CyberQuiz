using CyberQuiz.Application.Interfaces;
using CyberQuiz.Infrastructure.Entities;
using CyberQuiz.Infrastructure.Repositories;
using CyberQuiz.Shared.DTOs.Catalog;
using CyberQuiz.Shared.DTOs.Quiz;
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
            // Get all categories and their subcategories
            var categories = await _categoryRepo.GetAllCategoriesWithSubCategoriesAsync();

            // Creates the list of CategoryDto to return
            var result = new List<CategoryDto>();

            foreach (var category in categories)
            {
                var orderedSubs = category.SubCategories.
                    OrderBy(sc => sc.OrderIndex)
                    .ToList();

                var subCategoryDtos = new List<SubCategoryDto>();

                bool previousCompleted = true; // The first subcategory is unlocked by default

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
                    // updates the previousCompleted variable for the next iteration, if the current subcategory is not completed, the next one will be locked
                    previousCompleted = progress.IsCompleted;
                }
                // BUilds the CategoryDto ands adds it to the result list
                result.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    SubCategories = subCategoryDtos
                });
            }

            return result;


        }


        public async Task<QuestionDto?> GetNextQuestionAsync(int subCategoryId, string userId)
        {
            // Get all questions for the subcategory
            var questions = await _questionRepo.GetBySubCategoryAsync(subCategoryId);

            if (questions is null || questions.Count == 0)
                return null; // No questions available for the subcategory

            // Get the list of question ids that the user has already answered for the subcategory
            var answeredQuestionIds = await _userResultRepo.GetAnsweredQuestionIdsAsync(userId, subCategoryId);

            // Find the first question that the user has not answered yet
            var nextQuestion = questions.FirstOrDefault(q => !answeredQuestionIds.Contains(q.Id));

            if (nextQuestion is null)
                return null;

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
            // Searches if the question exists and belongs to the specified subcategory, then checks if the selected answer is correct.
            var question = await _questionRepo.GetByIdAsync(dto.QuestionId);

            if (question is null)
                throw new InvalidOperationException($"Question {dto.QuestionId} not found.");

            if (question.SubCategoryId != dto.SubCategoryId)
                throw new InvalidOperationException($"Question {dto.QuestionId} does not belong to subcategory {dto.SubCategoryId}.");

            // Get the selected answer option and check if it's correct.
            var selectedOption = await _answerRepo.GetByIdAsync(dto.SelectedAnswerOptionId);
            if (selectedOption is null)
                throw new InvalidOperationException($"Answer option {dto.SelectedAnswerOptionId} not found.");

            // Check if the selected answer option belongs to the question.
            bool isCorrect = selectedOption.IsCorrect;

            int? correctAnswerOptionId = null; // If the answer is incorrect it is null, otherwise it is the same as the selected answer option id
            var allOptions = await _answerRepo.GetByQuestionIdAsync(dto.QuestionId); // Get all answer options for the question to find the correct one

            var correctOption = allOptions.FirstOrDefault(o => o.IsCorrect); // Find the correct answer option among all options for the question
            correctAnswerOptionId = correctOption?.Id; // If the correct option is found, set the correct answer option id to its id, otherwise it remains null

            var userResult = new UserResult
            {
                UserId = userId,
                SubCategoryId = dto.SubCategoryId,
                QuestionId = dto.QuestionId,
                SelectedAnswerOptionId = dto.SelectedAnswerOptionId,
                IsCorrect = isCorrect,
                AnsweredAtUtc = DateTime.UtcNow
            };

            await _userResultRepo.AddAsync(userResult); // Save the user's answer result to the database

            var progress = await _progress.GetSubCategoryProgressAsync(dto.SubCategoryId, userId); // Calculate the user's progress in the subcategory

            // Get the next question after submitting the answer
            var nextQuestion = await GetNextQuestionAsync(dto.SubCategoryId, userId);

            return new SubmitAnswerResponseDto
            {
                IsCorrect = isCorrect,
                CorrectAnswerOptionId = correctAnswerOptionId,
                Progress = progress,
                NextQuestion = nextQuestion // null om inga fler frågor
            };

        }
    }
}
