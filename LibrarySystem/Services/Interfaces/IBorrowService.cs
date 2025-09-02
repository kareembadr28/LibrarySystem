using LibrarySystem.Dtos.BorrowDtos;

namespace LibrarySystem.Services.Interfaces
{
    public interface IBorrowService
    {
        Task<BorrowDto> BorrowBookAsync(int customerId, int bookId);

        Task<ReturnBorrowDto> ReturnBookAsync(int borrowId);

        Task<IEnumerable<BorrowDto>> GetBorrowsByUserIdAsync(int userId);

        Task<IEnumerable<BorrowDto>> GetActiveBorrowsAsync();

        Task<IEnumerable<BorrowDto>> GetBorrowsByBookIdAsync(int bookId);

        Task<BorrowDetailsDto?> GetBorrowWithDetailsAsync(int borrowId);

        Task<bool> IsBookBorrowedByUserAsync(int userId, int bookId);

        Task<IEnumerable<BorrowDto>> GetBorrowsByDateRangeAsync(DateTime startDate, DateTime endDate);

        Task<decimal> CalculateFineAsync(int borrowId);
    }
}
