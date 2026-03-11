using CyberQuiz.Application.Interfaces;
using CyberQuiz.Shared.DTOs.AiChat;
using Microsoft.AspNetCore.Mvc;

namespace CyberQuiz.API.Controllers
{
    [ApiController]
    [Route("api/ai")]
    public class AiChatController : ControllerBase
    {
        private readonly IAiChatService _aiChatService;

        public AiChatController(IAiChatService aiChatService)
        {
            _aiChatService = aiChatService;
        }

        [HttpPost("chat")]
        public async Task<ActionResult<ChatResponseDto>> Chat([FromBody] ChatRequestDto request)
        {
            var response = await _aiChatService.SendMessageAsync(request);
            return Ok(response);
        }

        [HttpPost("quiz-help")]
        public async Task<ActionResult<ChatResponseDto>> QuizHelp([FromBody] QuizHelpRequestDto request)
        {
            var response = await _aiChatService.GetQuizHelpAsync(request);
            return Ok(response);
        }
    }
}