using System;
using System.Collections.Generic;
using System.Text;

namespace CyberQuiz.Infrastructure.Entities
{
    public class UserResult
    {
        // Primärnyckel för resultat-raden
        public int Id { get; set; }

        // FK till Identity-användaren som svarade (IdentityUser.Id är normalt string)
        public string UserId { get; set; } = null!;

        // FK till frågan som besvarades
        public int QuestionId { get; set; }

        // Navigation till frågan (many UserResults -> one Question)
        public Question Question { get; set; } = null!;

        // FK till subkategorin (dupliceras här för enklare progressions-queries)
        public int SubCategoryId { get; set; }

        // Navigation till subkategorin (many UserResults -> one SubCategory)
        public SubCategory SubCategory { get; set; } = null!;

        // FK till det svarsalternativ användaren valde
        public int SelectedAnswerOptionId { get; set; }

        // Navigation till valt svarsalternativ (many UserResults -> one AnswerOption)
        public AnswerOption SelectedAnswerOption { get; set; } = null!;

        // Om användarens val var korrekt (sparas vid varje svar)
        public bool IsCorrect { get; set; }

        // Försöksnummer på samma fråga/subkategori 
        public int? AttemptNumber { get; set; }

        // Tidpunkt då svaret registrerades 
        public DateTime AnsweredAtUtc { get; set; } = DateTime.UtcNow;
    }
}
