using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repositories.Implementation
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(Context context) : base(context)
        {
        }

        public async Task<Author> GetByFullName(string fullName)
        {
            return await _context.Authors
                .FirstOrDefaultAsync(a => a.fullName == fullName);
        }

        public async Task<Author> GetWithhBooks(int id)
        {
return await _context.Authors.Include(a=>a.Books).FirstOrDefaultAsync(a => a.Id == id);

        }

        public Task<bool> IsAuthorOfBook(int authorId, int bookId)
        {
            return _context.Authors
                .AnyAsync(a => a.Id == authorId && a.Books.Any(b => b.Id == bookId));
        }
    }
}
