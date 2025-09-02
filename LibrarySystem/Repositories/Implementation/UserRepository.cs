using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repositories.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public async Task<User> getByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

        public async Task<User> getByUserName(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.username.Equals(username));
        }

        public async Task<bool> IsExist(string username)
        {
            return await _context.Users.AnyAsync(u => u.username.Equals(username));
        }
    }
}
