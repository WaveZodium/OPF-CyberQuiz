using CyberQuiz.Application.Interfaces;
using CyberQuiz.Shared.DTOs.AiChat;
using Microsoft.AspNetCore.Mvc;

namespace CyberQuiz.API.Controllers
{
    [ApiController]
    [Route("api/ai")]
    public class AiChatController : ControllerBase
    {
        //DI for the AI chat service, which will handle the logic of communicating with the AI model
        //and generating responses based on the user's input and quiz question details.
        private readonly IAiChatService _aiChatService;

        public AiChatController(IAiChatService aiChatService)
        {
            _aiChatService = aiChatService;
        }

        // Endpoint for handling general chat messages from the user.
        [HttpPost("chat")]
        public async Task<ActionResult<ChatResponseDto>> Chat([FromBody] ChatRequestDto request)
        {
            var response = await _aiChatService.SendMessageAsync(request);
            return Ok(response);
        }

        // Endpoint for handling quiz help requests, where the user asks for assistance on a specific quiz question.
        [HttpPost("quiz-help")]
        public async Task<ActionResult<ChatResponseDto>> QuizHelp([FromBody] QuizHelpRequestDto request)
        {
            var response = await _aiChatService.GetQuizHelpAsync(request);
            return Ok(response);
        }
    }
}