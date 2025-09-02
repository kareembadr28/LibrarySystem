using LibrarySystem.Dtos;

namespace LibrarySystem.Services.Interfaces
{
    public interface IAdminService
    {
        Task<bool> IsExistAsync(string username);
        Task<UserDto> GetByUserNameAsync(string username);
        Task<UserDto> GetByEmailAsync(string email);
    }
}
