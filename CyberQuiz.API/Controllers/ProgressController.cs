using CyberQuiz.Shared.DTOs.Progress;
using CyberQuiz.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CyberQuiz.API.Controllers
{
    [ApiController]
    [Route("api/progress")]
    [Authorize]//Kräver autentisering för att få åtkomst till dessa endpoints
    public class ProgressController : ControllerBase
    {
        private readonly IProgressCalculator _progressCalculator;
        public ProgressController(IProgressCalculator progressCalculator)
        {
            _progressCalculator = progressCalculator;
        }
        // GET /api/progress/subcategories/5
        [HttpGet("subcategories/{subCategoryId:int}")]
        public async Task<ActionResult<SubCategoryProgressDto>> GetSubCategoryProgress(int subCategoryId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId == null) return Unauthorized();
            var result = await _progressCalculator.GetSubCategoryProgressAsync(subCategoryId, userId);
            return Ok(result);
        }        
    }
}
