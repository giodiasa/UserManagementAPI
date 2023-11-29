using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Entities;
using UserManagement.Services.Services;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserProfileService _userProfileService;

        public UserProfileController(UserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet("{userProfileId}")]
        public IActionResult GetUserProfileById(int userProfileId)
        {
            var userProfile = _userProfileService.GetUserProfileById(userProfileId);

            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }

        [HttpGet]
        public IActionResult GetAllUserProfiles()
        {
            var userProfiles = _userProfileService.GetAllUserProfiles();
            return Ok(userProfiles);
        }

        [HttpPost]
        public IActionResult AddUserProfile(UserProfile userProfile)
        {
            try
            {
                _userProfileService.CreateUserProfile(userProfile);

                return CreatedAtAction(nameof(GetUserProfileById), new { userProfileId = userProfile.UserProfileId }, userProfile);
            }
            catch (DbUpdateException ex)
            {
                return Conflict(ex.Message);
            }
            
        }

        [HttpPut("{userProfileId}")]
        public IActionResult UpdateUserProfile(int userProfileId, UserProfile userProfile)
        {
            if (userProfileId != userProfile.UserProfileId)
            {
                return BadRequest();
            }

            _userProfileService.UpdateUserProfile(userProfile);

            return NoContent();
        }

        [HttpDelete("{userProfileId}")]
        public IActionResult DeleteUserProfile(int userProfileId)
        {
            _userProfileService.DeleteUserProfile(userProfileId);

            return NoContent();
        }

    }
}
