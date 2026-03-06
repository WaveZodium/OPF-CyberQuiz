using System.Security.Claims;
using CyberQuiz.Application.Interfaces;
using CyberQuiz.Shared.DTOs.Quiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/quiz")]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService)

    public async Task<ActionResult<QuestionDto>> GetNextQuestion(int subCategoryId)
    {
            // Extract the user ID from the cookies
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();


            return NotFound();

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

    }
}