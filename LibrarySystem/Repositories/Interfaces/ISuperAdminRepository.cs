using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Interfaces
{
    public interface ISuperAdminRepository
    {
        public Task<bool> IsExist(string username);
        public Task<SuperAdmin> getByUserName(string username);
        public Task<SuperAdmin> getByEmail(string email);
    }
}
