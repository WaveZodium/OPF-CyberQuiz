using System.Security.Claims;
using CyberQuiz.Application.Interfaces;
using CyberQuiz.Shared.DTOs.Quiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberQuiz.API.Controllers;

[ApiController]
[Route("api/quiz")]
[Authorize]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService)
    {
        _quizService = quizService;
    }

    [HttpGet("next/{subCategoryId}")]
    public async Task<ActionResult<QuestionDto>> GetNextQuestion(int subCategoryId)
    {
        // Extract the user ID from the cookies
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var question = await _quizService.GetNextQuestionAsync(subCategoryId, userId);

        if (question == null)
            return NotFound();

        return Ok(question);
    }

    [HttpPost("answer")]
    public async Task<ActionResult<SubmitAnswerResponseDto>> SubmitAnswer([FromBody] SubmitAnswerRequestDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        if (dto == null)
            return BadRequest("Request body is missing.");

        if (dto.SubCategoryId <= 0 || dto.QuestionId <= 0 || dto.SelectedAnswerOptionId <= 0)
            return BadRequest("Invalid Request");

        var result = await _quizService.SubmitAnswerAsync(dto, userId);

        return Ok(result);
    }

    // GET /api/quiz/review/1
    [HttpGet("review/{subCategoryId:int}")]
    public async Task<ActionResult<List<QuestionReviewDto>>> GetReview(int subCategoryId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var result = await _quizService.GetSubCategoryReviewAsync(subCategoryId, userId);
        return Ok(result);
    }
}