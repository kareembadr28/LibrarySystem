using LibrarySystem.Dtos.PurchaseDtos;

namespace LibrarySystem.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<PurchaseDto> CreatePurchaseAsync(CreatePurchaseDto purchaseDto);

        Task<BasicPurchaseDto> GetPurchaseByIdAsync(int id);

        Task<IEnumerable<BasicPurchaseDto>> GetAllPurchasesAsync();

        Task<IEnumerable<PurchaseWithCustomerDto>> GetPurchasesByCustomerAsync(int customerId);

        Task<IEnumerable<PurchaseWithBookDto>> GetPurchasesByBookAsync(int bookId);

        Task<IEnumerable<BasicPurchaseDto>> GetPurchasesBetweenDatesAsync(DateTime startDate, DateTime endDate);

        Task DeletePurchaseAsync(int id);
    }
}
