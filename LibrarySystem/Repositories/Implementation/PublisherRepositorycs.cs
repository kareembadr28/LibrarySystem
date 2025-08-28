using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repositories.Implementation
{
    public class PublisherRepository: GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Publisher>> GetAllWithBooksAsync()
        {
            return await _context.Publishers
                .Include(p => p.Books)
                .ToListAsync();
        }

        public async Task<Publisher> GetByNameAsync(string name)
        {
            return await _context.Publishers
                .FirstOrDefaultAsync(p => p.name == name);
        }

        public async Task<Publisher> GetWithBooksAsync(int publisherId)
        {
            return await _context.Publishers
                .Include(p => p.Books)
                .FirstOrDefaultAsync(p => p.Id == publisherId);
        }

        public async Task<bool> IsExistAsync(string name)
        {
            return await _context.Publishers
                .AnyAsync(p => p.name == name);
        }
    }
}
