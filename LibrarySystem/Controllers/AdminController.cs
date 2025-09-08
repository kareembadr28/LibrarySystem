using LibrarySystem.Dtos;
using LibrarySystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;
        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet("ByUserName")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdminByUserName( string username)
        {
            var admin = await adminService.GetByUserNameAsync(username);
            if (admin == null) return NotFound(new ApiResponse(false,"admin is not found"));
            return Ok(new ApiResponse(true,"admin found ",admin));
        }

        [HttpGet("ByEmail")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdminByEmail( string email)
        {
            var admin = await adminService.GetByEmailAsync(email);
            if (admin == null) return NotFound(new ApiResponse(false, "admin is not found"));
            return Ok(new ApiResponse(true, "admin found ", admin));
        }

        [HttpGet("IsExist")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> IsExist( string username)
        {
            var isExist = await adminService.IsExistAsync(username);
            return Ok(new ApiResponse(true, "check completed", isExist));
        }

    }
}
