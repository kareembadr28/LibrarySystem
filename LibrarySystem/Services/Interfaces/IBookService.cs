using LibrarySystem.Dtos.BookDtos;
using LibrarySystem.Models;

namespace LibrarySystem.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookDetailsDto> AddBookAsync(AddBookDto bookdto);
        Task<bool> DeleteBookAsync(int bookId);
        Task<IEnumerable<BasicBookDTO>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int bookId);
        Task<IEnumerable<BookWithAuthorDto>> GetBooksByAuthorAsync(int authorId);
        Task<IEnumerable<BookWithCategoryDto>> GetBooksByCategoryAsync(int categoryId);
        Task<IEnumerable<BasicBookDTO>> GetBooksByPublisherAsync(int publisherId);
        Task<BasicBookDTO> GetByISBNAsync(string isbn);
        Task<IEnumerable<BasicBookDTO>> GetByPublishedDateRangeAsync(DateTime first, DateTime second);
        Task<BasicBookDTO> GetByTitleAsync(string title);
        Task<BookWithAuthorDto> GetWithAuthorAsync(int bookId);
        Task<Book> GetWithBorrowsAndPurchasesAsync(int bookId);
        Task<BookWithCategoryDto> GetWithCategoryAsync(int bookId);
        Task<BookWithPublishersDto> GetWithPublishersAsync(int bookId);
        Task<bool> IsInStockAsync(int bookId);
        Task<IEnumerable<BasicBookDTO>> SearchAsync(string searchTerm);
        Task<Book> UpdateBookAsync(Book book);

    }
}
