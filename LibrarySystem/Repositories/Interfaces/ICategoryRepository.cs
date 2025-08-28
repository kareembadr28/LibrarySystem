using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetByNameAsync(string name);

        Task<Category> GetWithBooksAsync(int categoryId);

        Task<bool> IsExistAsync(string name);

        Task<IEnumerable<Category>> GetCategoriesWithBooksAsync();

        Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(int categoryId);
    }
}
