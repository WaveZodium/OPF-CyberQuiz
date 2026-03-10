using Microsoft.AspNetCore.Identity;

namespace CyberQuiz.Infrastructure.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
