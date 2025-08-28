using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<IEnumerable<Purchase>> GetPurchasesByCustomerAsync(int customerId);
        Task<IEnumerable<Purchase>> GetPurchasesByBookAsync(int bookId);
        Task<IEnumerable<Purchase>> GetPurchasesBetweenDatesAsync(DateTime startDate, DateTime endDate);
        Task<Purchase> GetWithDetailsAsync(int purchaseId);
    }
}
