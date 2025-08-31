using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Interfaces
{
    public interface IBorrowRepository : IGenericRepository<Borrow>
    {
        Task<IEnumerable<Borrow>> GetBorrowsByUserIdAsync(int userId);

        Task<IEnumerable<Borrow>> GetActiveBorrowsAsync();

        Task<IEnumerable<Borrow>> GetBorrowsByBookIdAsync(int bookId);


        Task<Borrow?> GetBorrowWithDetailsAsync(int borrowId);

        Task<bool> IsBookBorrowedByUserAsync(int userId, int bookId);

        Task<IEnumerable<Borrow>> GetBorrowsByDateRangeAsync(DateTime startDate, DateTime endDate);

    }
}
