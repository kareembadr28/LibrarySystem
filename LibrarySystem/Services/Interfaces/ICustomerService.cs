using LibrarySystem.Dtos;
using LibrarySystem.Dtos.CustomerDtos;

namespace LibrarySystem.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> IsExistAsync(string username);
        Task<UserDto> GetByUserNameAsync(string username);
        Task<UserDto> GetByEmailAsync(string email);
        Task<CustomerWithBorrowsDto> GetCustomerWithBorrowsAsync(int id);
        Task<CustomerWithPurchasesDto> GetCustomerWithPurchasesAsync(int id);
    }
}
