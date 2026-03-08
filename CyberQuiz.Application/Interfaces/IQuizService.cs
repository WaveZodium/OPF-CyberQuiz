using CyberQuiz.Shared.DTOs.Catalog;
using CyberQuiz.Shared.DTOs.Quiz;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Application.Interfaces
{
    public interface IQuizService
    {
        Task<List<CategoryDto>> GetCategoriesForUserAsync(string userId);
        Task<QuestionDto?> GetNextQuestionAsync(int subCategoryId, string userId);
        Task<SubmitAnswerResponseDto> SubmitAnswerAsync(SubmitAnswerRequestDto dto, string userId);
    }
}
