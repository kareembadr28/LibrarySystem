using LibrarySystem.Dtos;
using LibrarySystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("by-username/{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByUsernameAsync(string username)
        {
            var user = await userService.GetByUsernameAsync(username);
            if (user == null)
                return NotFound(new ApiResponse(false,"UserNotFound"));
            return Ok(new ApiResponse(true,"user found",user));
        }

        [HttpGet("by-email/{email}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByEmailAsync(string email)
        {
            var user = await userService.GetByEmailAsync(email);
            if (user == null)
                return NotFound(new ApiResponse(false, "UserNotFound"));
            return Ok(new ApiResponse(true, "user found", user));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var result = await userService.DeleteUserAsync(id);
            if (!result)
                return NotFound(new ApiResponse(false, "UserNotFound"));
            return Ok(new ApiResponse(true, "UserDeleted"));
        }
    }
}
