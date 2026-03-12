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

                    bool isLocked = !previousCompleted && !progress.HasAttemptedAllQuestions; // Lock only if previous is incomplete AND this subcategory is not fully answered

                    subCategoryDtos.Add(new SubCategoryDto
                    {
                        Id = sub.Id,
                        Name = sub.Name,
                        OrderIndex = sub.OrderIndex,
                        IsLocked = isLocked,
                        IsCompleted = progress.IsCompleted,
                        PercentCorrect = progress.PercentCorrect,
                        ProgressPercent = progress.ProgressPercent,
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

            // If repository returns null, technical error
            if (questions is null)
                throw new NotFoundException($"Subcategory {subCategoryId} not found.");

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

                // More subcategories exist - subcategory completed
                return null;
            }


            var options = await _answerRepo.GetByQuestionIdAsync(nextQuestion.Id); // Get answer options for the question

            var unansweredQuestions = questions.Where(q => !answeredQuestionIds.Contains(q.Id)).ToList();// Get the list of unanswered questions for the subcategory
            bool isLastQuestion = unansweredQuestions.Count == 1; // If there is only one unanswered question, it means that the next question is the last one for the subcategory
            return new QuestionDto
            {
                QuestionId = nextQuestion.Id,
                Text = nextQuestion.Text,
                OrderIndex = nextQuestion.OrderIndex,
                AnswerOptions = options.Select(o => new AnswerOptionDto
                {
                    Id = o.Id,
                    Text = o.Text
                }).ToList(),
                IsLastQuestion = isLastQuestion
            };

        }

        public async Task<SubmitAnswerResponseDto> SubmitAnswerAsync(SubmitAnswerRequestDto dto, string userId)
        {
            // Searches if the question exists and belongs to the specified subcategory, then checks if the selected answer is correct.
            var question = await _questionRepo.GetByIdAsync(dto.QuestionId);

            if (question is null)
                throw new NotFoundException($"Question {dto.QuestionId} not found.");

            if (question.SubCategoryId != dto.SubCategoryId)
                throw new ValidationException($"Question {dto.QuestionId} does not belong to subcategory {dto.SubCategoryId}.");

            // Get the selected answer option and check if it's correct.
            var selectedOption = await _answerRepo.GetByIdAsync(dto.SelectedAnswerOptionId);
            if (selectedOption is null)
                throw new NotFoundException($"Answer option {dto.SelectedAnswerOptionId} not found.");

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
            try
            {
                var nextQuestion = await GetNextQuestionAsync(dto.SubCategoryId, userId);

                return new SubmitAnswerResponseDto
                {
                    IsCorrect = isCorrect,
                    CorrectAnswerOptionId = correctAnswerOptionId,
                    Progress = progress,
                    NextQuestion = nextQuestion
                };
            }
            catch (DomainException)
            {
                // Category completed - no more subcategories
                return new SubmitAnswerResponseDto
                {
                    IsCorrect = isCorrect,
                    CorrectAnswerOptionId = correctAnswerOptionId,
                    Progress = progress,
                    NextQuestion = null
                };
            }

        }

        public async Task<List<QuestionReviewDto>> GetSubCategoryReviewAsync(int subCategoryId, string userId)
        {
            // Get all questions for the subcategory along with the user's answers
            var questions = await _questionRepo.GetQuestionsWithAnswersAsync(subCategoryId);

            // Get the user's results for the subcategory
            var userResults = await _userResultRepo.GetBySubCategoryAsync(userId, subCategoryId);

            // Build the review list
            var reviewList = new List<QuestionReviewDto>();

            //Loop through each question

            foreach (var question in questions)
            {
                var userResult = userResults.FirstOrDefault(ur => ur.QuestionId == question.Id);

                if (userResult is null)
                    continue;

                var correctOption = question.AnswerOptions.FirstOrDefault(ao => ao.IsCorrect);
                // Build the list of answer options for the review, marking which one is correct
                var answerOptionReviews = question.AnswerOptions.Select(ao => new AnswerOptionReviewDto
                {
                    Id = ao.Id,
                    Text = ao.Text,
                    IsCorrect = ao.IsCorrect,
                    IsSelectedByUser = ao.Id == userResult.SelectedAnswerOptionId
                }).ToList();

                // Build the QuestionReviewDto for the question and add it to the review list
                reviewList.Add(new QuestionReviewDto
                {
                    QuestionId = question.Id,
                    QuestionText = question.Text,
                    OrderIndex = question.OrderIndex,
                    SelectedAnswerOptionId = userResult.SelectedAnswerOptionId,
                    CorrectAnswerOptionId = correctOption?.Id,
                    AnswerOptions = answerOptionReviews,
                    IsCorrect = userResult.IsCorrect,
                    Explanation = question.Explanation,
                    NextSubCategoryId = await DetermineNextSubCategoryId(subCategoryId, userId)
                });
            }

            return reviewList;
        }

        private async Task<int> DetermineNextSubCategoryId(int currentSubCategoryId, string userId)
        {
           // check if the user has reached 80% correct
            var progress = await _progress.GetSubCategoryProgressAsync(currentSubCategoryId, userId);
            
            if (progress.PercentCorrect < 80)
                return 0; // YOU SHALL NOT PASS! (to the next subcategory)
        
            var nextSubCategoryId = await _subCategoryRepo
                .GetNextSubCategoryAsync(currentSubCategoryId);
            
            return nextSubCategoryId ?? 0;
        }

        public async Task UpdateQuizResultAsync(
            string userId,
            int questionId,
            int selectedAnswerOptionId,
            bool isCorrect)
        {
            var existingResult = await _userResultRepo.GetByUserAndQuestionAsync(userId, questionId);

            if (existingResult is null)
                throw new NotFoundException($"User result for question {questionId} was not found.");

            existingResult.SelectedAnswerOptionId = selectedAnswerOptionId;
            existingResult.IsCorrect = isCorrect;
            existingResult.AnsweredAtUtc = DateTime.UtcNow;

            await _userResultRepo.UpdateAsync(existingResult);
        }

        public async Task ResetSubCategoryProgressAsync(int subCategoryId, string userId)
        {
            // Verify that the subcategory exists
            var subCategory = await _subCategoryRepo.GetByIdAsync(subCategoryId);
            if (subCategory is null)
                throw new NotFoundException($"Subcategory {subCategoryId} not found.");

            // Delete all user results for this subcategory
            await _userResultRepo.DeleteBySubCategoryAsync(userId, subCategoryId);
        }
    }
}
