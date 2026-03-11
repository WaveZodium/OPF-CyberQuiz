using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Shared.DTOs.AiChat
{
    public class ChatRequestDto
    {
        public string Message { get; set; } = string.Empty;
        public List<ChatMessageDto> History { get; set; } = [];
    }
}
