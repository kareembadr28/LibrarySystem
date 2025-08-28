using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repositories.Implementation
{
    public class PurchaseRepository:GenericRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesBetweenDatesAsync(DateTime startDate, DateTime endDate)
        {
          return await _context.Purchases
                .Where(p => p.purchaseDate >= startDate && p.purchaseDate <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesByBookAsync(int bookId)
        {
           return await _context.Purchases
                .Where(p => p.bookId == bookId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesByCustomerAsync(int customerId)
        {
            return await _context.Purchases
                .Where(p => p.customerId == customerId)
                .ToListAsync();
        }

        public async Task<Purchase> GetWithDetailsAsync(int purchaseId)
        {
           return await _context.Purchases
                .Include(p => p.book)
                .Include(p => p.customer)
                .FirstOrDefaultAsync(p => p.Id == purchaseId);
        }
    }
   
}
