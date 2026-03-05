using CyberQuiz.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CyberQuiz.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = request.Identifier.Contains('@')
            ? await userManager.FindByEmailAsync(request.Identifier)
            : await userManager.FindByNameAsync(request.Identifier);

        if (user is null)
        {
            return Unauthorized("Invalid credentials.");
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
        if (!result.Succeeded)
        {
            return Unauthorized("Invalid credentials.");
        }

        await signInManager.SignInAsync(user, isPersistent: false);
        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var user = new ApplicationUser
        {
            UserName = request.UserName,
            Email = request.Email
        };

        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors
                .GroupBy(e => e.Code)
                .ToDictionary(g => g.Key, g => g.Select(e => e.Description).ToArray());

            return BadRequest(new ValidationProblemDetails(errors));
        }

        await signInManager.SignInAsync(user, isPersistent: false);
        return Ok();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return Ok();
    }

    public sealed record LoginRequest(string Identifier, string Password);
    public sealed record RegisterRequest(string UserName, string Email, string Password);
}
