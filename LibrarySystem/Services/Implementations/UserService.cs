using LibrarySystem.Dtos;
using LibrarySystem.Repositories.Implementation;
using LibrarySystem.Repositories.Interfaces;
using LibrarySystem.Services.Interfaces;

namespace LibrarySystem.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user == null)
                return false;
            await userRepository.DeleteAsync(user);
            await userRepository.SaveChangesAsync();
            return true;

        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
           var user =await userRepository.getByEmail(email);
            if (user == null)
                return null;
            return new UserDto
            {
                Id = user.Id,
                UserName = user.username,
                Email = user.Email,
                Role = user.GetType().Name
            };
        }

        public async Task<UserDto> GetByUsernameAsync(string username)
        {
           var user =await userRepository.getByUserName(username);
            if (user == null)
                return null;
            return new UserDto
            {
                Id = user.Id,
                UserName = user.username,
                Email = user.Email,
                Role = user.GetType().Name
            };
        }
    }
}
