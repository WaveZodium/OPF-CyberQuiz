using CyberQuiz.Application.Interfaces;
using CyberQuiz.Shared.DTOs.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CyberQuiz.API.Controllers;

[ApiController]
[Route("api/categories")]
[Authorize]
public class CategoryController : ControllerBase
{
    private readonly IQuizService _quizService;

    public CategoryController(IQuizService quizService)
    {
        _quizService = quizService;
    }

    // GET /api/categories
    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetCategories()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var result = await _quizService.GetCategoriesForUserAsync(userId);
        return Ok(result);
    }
}