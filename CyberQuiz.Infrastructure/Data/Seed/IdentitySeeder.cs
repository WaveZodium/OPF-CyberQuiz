using CyberQuiz.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CyberQuiz.Infrastructure.Data.Seed;

public static class IdentitySeeder
{
    // Skapar testanvändaren som uppgiften kräver: username "user" och password "Password1234!".
// Vi gör detta via UserManager (runtime seeding) istället för HasData eftersom Identity måste
// hasha lösenordet korrekt och sätta interna Identity-fält (SecurityStamp, NormalizedUserName osv).
// Seedern kör bara om användaren inte redan finns.
    public static async Task SeedRequiredUserAsync(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        // const string userName = "user"; - kravet är username=user, inte email 
        //behöver ändra UI login.razor för detta
        const string userName = "user"; //kommer tas bort när UI login.razor ändras 
        const string email = "user@cyberquiz.local";
        const string password = "Password1234!";

        /*

        // Kolla på username (inte email) eftersom kravet är username=user
        var existing = await userManager.FindByNameAsync(userName);
        if (existing != null) return;

        var user = new ApplicationUser
        {
            UserName = userName,
            // Sätt email ändå (många templates förväntar sig det)
            Email = "user@cyberquiz.local",
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new Exception($"Kunde inte skapa seed-user '{userName}': {errors}");
        }
        */

        //Kommer ändras när UI login.razor ändras så att username är "user" istället för email
        var existing = await userManager.FindByNameAsync(userName);
        if (existing != null) return;

        var user = new ApplicationUser
        {
            UserName = userName,
            Email = email,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, password);
    }
}