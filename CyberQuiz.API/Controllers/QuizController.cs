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
        => _quizService = quizService;

    [HttpGet("subcategories/{subCategoryId:int}/questions")]
    public async Task<ActionResult<List<QuestionDto>>> GetQuestions(int subCategoryId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var result = await _quizService.GetQuestionsAsync(subCategoryId, userId);
        return Ok(result);
    }

    [HttpGet("next/{subCategoryId:int}")]
    public async Task<ActionResult<QuestionDto>> GetNextQuestion(int subCategoryId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var result = await _quizService.GetNextQuestionAsync(subCategoryId, userId);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("answer")]
    public async Task<ActionResult<SubmitAnswerResponseDto>> SubmitAnswer([FromBody] SubmitAnswerRequestDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var result = await _quizService.SubmitAnswerAsync(dto, userId);
        return Ok(result);
    }
}