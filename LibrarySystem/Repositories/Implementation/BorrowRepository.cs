using System.Net;
using LibrarySystem.Data;
using LibrarySystem.Enums;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repositories.Implementation
{
    public class BorrowRepository: GenericRepository<Borrow>, IBorrowRepository
    {
        public BorrowRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Borrow>> GetActiveBorrowsAsync()
        {
           return await _context.Borrows
                .Where(b => b.status == BorrowStatus.Borrowed)
                .ToListAsync();
        }

        public async Task<IEnumerable<Borrow>> GetBorrowsByBookIdAsync(int bookId)
        {
            return await _context.Borrows
                .Where(b => b.bookId == bookId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Borrow>> GetBorrowsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Borrows
                .Where(b => b.borrowDate >= startDate && b.borrowDate <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Borrow>> GetBorrowsByUserIdAsync(int customerId)
        {
            return await _context.Borrows
                .Where(b => b.customerId == customerId)
                .ToListAsync();

        }

        public async Task<Borrow?> GetBorrowWithDetailsAsync(int borrowId)
        {
           return await _context.Borrows
                .Include(b => b.book)
                .Include(b => b.customer)
                .FirstOrDefaultAsync(b => b.Id == borrowId);
        }

        public async Task<bool> IsBookBorrowedByUserAsync(int userId, int bookId)
        {
            return await _context.Borrows
                .AnyAsync(b => b.customerId == userId && b.bookId == bookId && b.status == BorrowStatus.Borrowed);
        }
    }
}
