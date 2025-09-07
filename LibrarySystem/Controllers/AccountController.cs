using LibrarySystem.Dtos;
using LibrarySystem.Dtos.AuthDtos;
using LibrarySystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IAuthService authService;
        public AccountController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult>Register(RegisterUserDto registerUserDto)
        {
            var result =await authService.RegisterAsync(registerUserDto);
            return Ok(new ApiResponse(true, "User registered successfully", result));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            var result = await authService.LoginAsync(loginUserDto);
            return Ok(new ApiResponse(true, "User logged in successfully", result));
        }

      
        

    }
}
