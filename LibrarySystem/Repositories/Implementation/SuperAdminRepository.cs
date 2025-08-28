using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repositories.Implementation
{
    public class SuperAdminRepository : GenericRepository<SuperAdmin>, ISuperAdminRepository
    {
        public SuperAdminRepository(Context context) : base(context)
        {
        }

        public async Task<SuperAdmin> getByEmail(string email)
        {
           return await _context.SuperAdmins.FirstOrDefaultAsync(a => a.Email.Equals(email));

        }

        public async Task<SuperAdmin> getByUserName(string username)
        {
           return await _context.SuperAdmins.FirstOrDefaultAsync(a => a.username.Equals(username));
        }

        public async Task<bool> IsExist(string username)
        {
            return await _context.SuperAdmins.AnyAsync(a => a.username.Equals(username));


        }
    }
}
