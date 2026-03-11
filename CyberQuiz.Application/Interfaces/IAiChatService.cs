using CyberQuiz.Shared.DTOs.AiChat;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Application.Interfaces
{
    public interface IAiChatService
    {
        Task<ChatResponseDto> SendMessageAsync(ChatRequestDto request);
        Task<ChatResponseDto> GetQuizHelpAsync(QuizHelpRequestDto request);
    }
}
