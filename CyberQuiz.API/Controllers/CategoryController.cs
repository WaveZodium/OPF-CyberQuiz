using CyberQuiz.Application.Interfaces;
using CyberQuiz.Shared.DTOs.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CyberQuiz.API.Controllers;

[ApiController]
[Route("api/catalog")]
[Authorize]
public class CatalogController : ControllerBase
{
    private readonly IQuizService _quizService;

    public CatalogController(IQuizService quizService)
    {
        _quizService = quizService;
    }

    // GET /api/catalog/categories
    [HttpGet("categories")]
    public async Task<ActionResult<List<CategoryDto>>> GetCategories()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null) return Unauthorized();

        var result = await _quizService.GetCategoriesForUserAsync(userId);
        return Ok(result);
    }
}