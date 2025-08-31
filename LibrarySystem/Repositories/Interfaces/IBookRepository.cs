using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book?> GetByISBNAsync(string isbn);
        Task<Book?> GetByTitleAsync(string title);

        Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId);
        Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId);
        Task<IEnumerable<Book>> GetBooksByPublisherAsync(int publisherId);

        Task<Book?> GetWithAuthorAsync(int bookId);
        Task<Book?> GetWithCategoryAsync(int bookId);
        Task<Book?> GetWithPublishersAsync(int bookId);
        Task<Book?> GetWithBorrowsAndPurchasesAsync(int bookId);

        Task<bool> IsInStockAsync(int bookId);
     

        Task<IEnumerable<Book>> SearchAsync(string searchTerm);
        Task<IEnumerable<Book>> GetByPublishedDateRangeAsync(DateTime first,DateTime second);
    }
}
