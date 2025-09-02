using LibrarySystem.Dtos;

namespace LibrarySystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetByUsernameAsync(string username);
        Task<UserDto> GetByEmailAsync(string email);
        Task<bool> DeleteUserAsync(int id);
    }
}
