using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repositories.Implementation
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Context context) : base(context)
        {
        }

        public async Task<Customer> getByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(a => a.Email.Equals(email));
        }

        public async Task<Customer> getByUserNameAsync(string username)
        {
          
         return await _context.Customers.FirstOrDefaultAsync(a => a.username.Equals(username));
        }

        public async Task<Customer> GetCustomerWithBorrowsAsync(int id)
        {
           return await _context.Customers
                .Include(c => c.Borrows)
                .ThenInclude(b => b.book)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<Customer> GetCustomerWithPurchaseAsync(int id)
        {
            return _context.Customers
                 .Include(c => c.Purchase)
                 .ThenInclude(p => p.book)
                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> IsExist(string username)
        {
            return await _context.Customers.AnyAsync(a => a.username.Equals(username));
        }
    }
}
