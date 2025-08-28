using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repositories.Implementation
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepositorycs
    {
        public AdminRepository(Context context) : base(context)
        {
        }

        public async Task<Admin> getByEmail(string email)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.Email.Equals(email));

        }

        public async Task<Admin> getByUserName(string username)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.username.Equals(username));

        }

        public async Task<bool> IsExist(string username)
        {
            return await _context.Admins.AnyAsync(a => a.username.Equals(username));
        }
    }
}
