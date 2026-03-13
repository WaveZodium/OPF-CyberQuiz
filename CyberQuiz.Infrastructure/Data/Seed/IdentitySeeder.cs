using CyberQuiz.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CyberQuiz.Infrastructure.Data.Seed;

public static class IdentitySeeder
{
    // Creates the test user required by the assignment: username "user" and password "Password1234!".
    // We do this via UserManager (runtime seeding) instead of HasData because Identity needs to
    // hash the password correctly and set internal Identity fields (SecurityStamp, NormalizedUserName, etc.).
    // The seeder only runs if the user does not already exist.
    public static async Task SeedRequiredUserAsync(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        // Define default user credentials
        const string userName = "user";
        const string email = "user@cyberquiz.local";
        const string password = "Password1234!";

        var existing = await userManager.FindByNameAsync(userName);
        if (existing != null) return;

        var user = new ApplicationUser
        {
            UserName = userName,
            Email = email,
            EmailConfirmed = true
        };

        await userManager.CreateAsync(user, password);
    }
}