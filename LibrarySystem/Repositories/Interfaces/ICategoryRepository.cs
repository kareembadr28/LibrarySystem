using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        // يجيب كاتيجوري بالاسم
        Task<Category> GetByNameAsync(string name);

        // يجيب كاتيجوري ومعاه الكتب بتاعته
        Task<Category> GetWithBooksAsync(int categoryId);

        // يشيك هل الكاتيجوري موجود بالاسم
        Task<bool> IsExistAsync(string name);

        // يجيب كل الكاتيجوريز اللي ليها كتب
        Task<IEnumerable<Category>> GetCategoriesWithBooksAsync();

        // يجيب كل الكتب تحت كاتيجوري معين
        Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(int categoryId);
    }
}
