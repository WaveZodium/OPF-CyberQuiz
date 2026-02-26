using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Infrastructure.Entities
{
    public class AnswerOption
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;

        // OBS: ska finnas i DB men API ska inte exponera det innan user svarat
        public bool IsCorrect { get; set; }

        //FK
        public int QuestionId { get; set; }

        //Navigation back to Question (many to one)
        public Question Question { get; set; } = null!;
    }
}
