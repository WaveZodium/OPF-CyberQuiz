using CyberQuiz.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CyberQuiz.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public CategoriesController(IQuizService quizService)
        {
            _quizService = quizService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
            {
                return Unauthorized();
            }

            var result = await _quizService.GetCategoriesForUserAsync(userId);
            return Ok(result);
        }

    }
}
