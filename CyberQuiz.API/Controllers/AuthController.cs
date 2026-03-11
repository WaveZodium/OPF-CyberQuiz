using CyberQuiz.Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CyberQuiz.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var identifier = request.Identifier.Trim();
        var user = await userManager.FindByNameAsync(identifier)
            ?? await userManager.FindByEmailAsync(identifier);

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

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
    {
        // Find the user by email
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return BadRequest("User not found.");
        }
        // Generate a password and reset the password
        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var result = await userManager.ResetPasswordAsync(user, token, request.NewPassword);
        // Check if the password reset was successful
        if (!result.Succeeded)
        {
            var errors = result.Errors
                .GroupBy(e => e.Code)
                .ToDictionary(g => g.Key, g => g.Select(e => e.Description).ToArray());

            return BadRequest(new ValidationProblemDetails(errors));
        }

        return Ok(new { message = "Password has been reset successfully." });
    }

    [Authorize]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
    {
        // Get the currently authenticated user
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null)
        {
            return Unauthorized("User not found.");
        }

        // Retrieve the user from the database
        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
        {
            return Unauthorized("User not found.");
        }
        // Verify current password and change to new password
        var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

        if (!result.Succeeded)
        {
            var errors = result.Errors
                .GroupBy(e => e.Code)
                .ToDictionary(g => g.Key, g => g.Select(e => e.Description).ToArray());

            return BadRequest(new ValidationProblemDetails(errors));
        }

        return Ok(new { message = "Password changed successfully." });
    }

    [Authorize]
    [HttpPost("change-email")]
    public async Task<IActionResult> ChangeEmail(ChangeEmailRequest request)
    {
        // Get the currently authenticated user
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null)
        {
            return Unauthorized("User not found.");
        }

        // Retrieve the user from the database
        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
        {
            return Unauthorized("User not found.");
        }

        // Verify password for security
        var isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);
        if (!isPasswordValid)
        {
            return BadRequest("Invalid password.");
        }

        // Check if the new email is already in use
        var existingUser = await userManager.FindByEmailAsync(request.NewEmail);
        if (existingUser is not null && existingUser.Id != userId)
        {
            return BadRequest("Email is already in use.");
        }

        // Update the email
        var result = await userManager.SetEmailAsync(user, request.NewEmail);
        if (!result.Succeeded)
        {
            var errors = result.Errors
                .GroupBy(e => e.Code)
                .ToDictionary(g => g.Key, g => g.Select(e => e.Description).ToArray());

            return BadRequest(new ValidationProblemDetails(errors));
        }

        return Ok(new { message = "Email changed successfully." });
    }

    public sealed record LoginRequest(string Identifier, string Password);
    public sealed record RegisterRequest(string UserName, string Email, string Password);
    public sealed record ResetPasswordRequest(string Email, string NewPassword);
    public sealed record ChangePasswordRequest(string CurrentPassword, string NewPassword);
    public sealed record ChangeEmailRequest(string Password, string NewEmail);
}
