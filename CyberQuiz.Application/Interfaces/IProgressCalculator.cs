using CyberQuiz.Shared.DTOs.Progress;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Application.Interfaces
{
    public interface IProgressCalculator
    {
        Task<SubCategoryProgressDto> GetSubCategoryProgressAsync(int subCategoryId, string userId);
    }
}
