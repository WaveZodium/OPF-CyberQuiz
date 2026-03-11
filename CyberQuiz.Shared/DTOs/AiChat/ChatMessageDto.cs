using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Shared.DTOs.AiChat
{
    public class ChatMessageDto
    {
        public string Role { get; set; } = string.Empty; // user / assistant / system
        public string Content { get; set; } = string.Empty;
    }
}
