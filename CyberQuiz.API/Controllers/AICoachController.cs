using System.Security.Claims;
using CyberQuiz.Application.Interfaces;
using CyberQuiz.Shared.DTOs.AICoach;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberQuiz.API.Controllers;

[ApiController]
[Route("api/coach")]
[Authorize]
public class AICoachController : ControllerBase
{
    private readonly IAICoachService _aiCoachService;

    public AICoachController(IAICoachService aiCoachService)
    {
        _aiCoachService = aiCoachService;
    }

    // GET /api/coach/summary
    [HttpGet("summary")]
    [ProducesResponseType(typeof(UserQuizSummaryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserQuizSummaryDto>> GetSummary()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var summary = await _aiCoachService.GetUserQuizSummaryAsync(userId);
        return Ok(summary);
    }

    // GET /api/coach/feedback
    [HttpGet("feedback")]
    [ProducesResponseType(typeof(AICoachFeedbackDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<AICoachFeedbackDto>> GetFeedback()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var feedback = await _aiCoachService.GenerateCoachFeedbackAsync(userId);
        return Ok(feedback);
    }
}