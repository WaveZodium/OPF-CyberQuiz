using CyberQuiz.Shared.DTOs.AiChat;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Application.Interfaces
{
    public interface IAiChatService
    {
        // Method takes a ChatRequestDto and returns a ChatResponseDto asynchronously
        Task<ChatResponseDto> SendMessageAsync(ChatRequestDto request);
        // Method takes a QuizHelpRequestDto and returns a ChatResponseDto asynchronously
        Task<ChatResponseDto> GetQuizHelpAsync(QuizHelpRequestDto request);
    }
}
