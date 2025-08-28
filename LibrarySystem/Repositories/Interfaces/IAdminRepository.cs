using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Interfaces
{
    public interface IAdminRepositorycs
    {
        public Task<bool> IsExist(string username);
        public Task<Admin> getByUserName(string username);
        public Task<Admin> getByEmail(string email);
    }
}
