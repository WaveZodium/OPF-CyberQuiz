using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Shared.DTOs.AiChat
{
    public class ChatResponseDto
    // an asnwer from AI that API sends back to UI after processing the ChatRequestDto
    {
        public string Reply { get; set; } = string.Empty;// AI's response text
    }
}
