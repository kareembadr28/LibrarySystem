using LibrarySystem.Data;
using LibrarySystem.Dtos;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using LibrarySystem.Services.Interfaces;

namespace LibrarySystem.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }
         public async Task<UserDto> GetByEmailAsync(string email)
        {
           var admin =await adminRepository.getByEmail(email);
            if (admin == null) return null;
            var adminDto = new UserDto
            {
                Id = admin.Id,
                UserName = admin.username,
                Email = admin.Email,
                Role = "Admin"
            };
            return adminDto;
        }

        public async Task<UserDto> GetByUserNameAsync(string username)
        {
           var admin =await adminRepository.getByUserName(username);
            if (admin == null) return null;
            var adminDto = new UserDto
            {
                Id = admin.Id,
                UserName = admin.username,
                Email = admin.Email,
                Role = "Admin"
            };
            return adminDto;
        }

        public async Task<bool> IsExistAsync(string username)
        {
            return await adminRepository.IsExist(username);
        }
    }
}
