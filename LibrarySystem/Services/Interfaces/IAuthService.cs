using LibrarySystem.Dtos.AuthDtos;
using LibrarySystem.Models;

namespace LibrarySystem.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<UserDetails> RegisterAsync(RegisterUserDto registerUserDto);
        public Task<UserDetails> LoginAsync(LoginUserDto loginUserDto);

    }
}
