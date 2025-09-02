using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        public Task<bool> IsExist(string username);
        public Task<User> getByUserName(string username);
        public Task<User> getByEmail(string email);
    }
}
