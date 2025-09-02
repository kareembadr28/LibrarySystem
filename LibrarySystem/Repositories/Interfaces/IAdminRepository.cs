using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Interfaces
{
    public interface IAdminRepository:IGenericRepository<Admin>
    {
        public Task<bool> IsExist(string username);
        public Task<Admin> getByUserName(string username);
        public Task<Admin> getByEmail(string email);
    }
}
