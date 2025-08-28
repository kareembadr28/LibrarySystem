using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repositories.Implementation
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(int categoryId)
        {
            return await _context.Books
                .Where(b => b.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.name == name);

        }

        public async Task<IEnumerable<Category>> GetCategoriesWithBooksAsync()
        {
          return await _context.Categories
                .Include(c => c.Books)
                .Where(c => c.Books.Any())
                .ToListAsync();
        }

        public async Task<Category> GetWithBooksAsync(int categoryId)
        {
            return await _context.Categories
               .Include(c => c.Books).FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task<bool> IsExistAsync(string name)
        {
            return await _context.Categories
                .AnyAsync(c => c.name == name);
        }
    }
}
