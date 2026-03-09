using CyberQuiz.Application.Interfaces;
using CyberQuiz.Shared.DTOs.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CyberQuiz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IUserProfileService _profileService;

        public ProfileController(IUserProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult<UserProfileDto>> GetProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Ensure we have a valid user ID from the claims
            if (string.IsNullOrWhiteSpace(userId))
                return Unauthorized();
            // Get the user profile data
            var profile = await _profileService.GetUserProfileAsync(userId);
            return Ok(profile);
        }

        [HttpGet("categories")]
        public async Task<ActionResult> GetCategoryProgress()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Ensure we have a valid user ID from the claims
            if (string.IsNullOrWhiteSpace(userId))
                return Unauthorized();
            // Get the user's progress across all categories
            var progress = await _profileService.GetUserProgressByAllCategoriesAsync(userId);
            return Ok(progress);
        }
    }
}