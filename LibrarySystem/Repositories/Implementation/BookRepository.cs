using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repositories.Implementation
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId)
        {
            return await _context.Books.Where(b=>b.authorId == authorId).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId)
        {
            return await _context.Books.Where(b => b.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByPublisherAsync(int publisherId)
        {
            return await _context.Books.Where(b=>b.publishers.Any(p => p.Id == publisherId)).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetByPublishedDateRangeAsync(DateTime first, DateTime second)
        {
            return await _context.Books
                .Where(b => b.publishedDate >= first && b.publishedDate <= second)
                .ToListAsync();
        }

        public async Task<Book?> GetByISBNAsync(string isbn)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.iSBN == isbn);
        }

        public async Task<Book?> GetByTitleAsync(string title)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.title == title);
        }

        public async Task<Book?> GetWithAuthorAsync(int bookId)
        {
            return await _context.Books.Include(b => b.author).FirstOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<Book?> GetWithBorrowsAndPurchasesAsync(int bookId)
        {
           return await _context.Books
                .Include(b => b.borrows)
                .Include(b => b.purchases)
                .FirstOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<Book?> GetWithCategoryAsync(int bookId)
        {
           return await _context.Books.Include(b => b.category).FirstOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<Book?> GetWithPublishersAsync(int bookId)
        {
           return await _context.Books.Include(b => b.publishers).FirstOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<bool> IsInStockAsync(int bookId)
        {
           return await _context.Books
                .AnyAsync(b => b.Id == bookId && b.stock > 0);
        }

        public async Task<IEnumerable<Book>> SearchAsync(string searchTerm)
        {
            return await _context.Books.
                Where(b => b.title.Contains(searchTerm) || b.iSBN.Contains(searchTerm))
                .ToListAsync();
        }
    }
}
