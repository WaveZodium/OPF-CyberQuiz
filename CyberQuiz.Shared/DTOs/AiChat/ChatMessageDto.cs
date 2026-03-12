using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Shared.DTOs.AiChat
{
    public class ChatMessageDto
    // Simple format for chat messages
    // Uses for both sending user messages and receiving AI responses
    //saving message in UI and sending to API
    // building up the conversation history
    {
        //Role indicates who is speaking: user, assistant(AI), or system (prompt)
        public string Role { get; set; } = string.Empty;

        //Content is the actual message text, for instance,  Content = "What is MFA?"
        public string Content { get; set; } = string.Empty;

        //Timestamp for when the message was created (UI uses it for display)
        public DateTimeOffset Timestamp { get; set; }
    }
}

/*
 new ChatMessageDto
{
    Role = "user",
    Content = "What is MFA?"
}
means:

user asked : “What is MFA?”

new ChatMessageDto
{
    Role = "assistant",
    Content = "MFA means Multi-Factor Authentication."
}
means:

AI answered: “MFA means Multi-Factor Authentication.”
*/