using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Shared.DTOs.AiChat
{
    public class QuizHelpRequestDto
    // This DTO is used to send quiz question details to the AI
    // when the user needs help on a specific question.
    {
        // Gets QuestionId to identify which question the user is asking about
        public int QuestionId { get; set; }
        // Gets QuestionText which is the text of the quiz question itself
        public string QuestionText { get; set; } = string.Empty;
        // Gets UserAnswer which is the answer the user has currently selected or entered for this question
        public string? UserAnswer { get; set; }
        // Gets CorrectAnswer which is the correct answer for this quiz question,
        // used by AI to explain why it's correct and why user's answer might be wrong
        public string CorrectAnswer { get; set; } = string.Empty;
        // Gets Explanation which is any additional explanation text stored in the database for this question,
        public string? Explanation { get; set; }
        // Gets WasUserAnswerCorrect which indicates whether the user's current answer is correct or not,
        public bool WasUserAnswerCorrect { get; set; }
    }
}
