using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Shared.DTOs.AiChat
{
    public class ChatRequestDto
    //a package data wich UI sends to API when user clicks "Send" button in chat interface
    {
        //Message is the new user message that we want to send to AI
        public string Message { get; set; } = string.Empty;

        //History is the list of all previous messages in the conversation,
        //including both user and AI messages
        public List<ChatMessageDto> History { get; set; } = [];//[] - means that the List is initialized as an empty list,
                                                               //so we can add messages to it without worrying about null reference exceptions.
        // Beccause History is the ChatMessageDto list,
        // it can contain both user and assistant messages,
        // and the Role property in each ChatMessageDto will indicate who sent that message.
    }
}
