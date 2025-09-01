using LibrarySystem.Models;
namespace LibrarySystem.Repositories.Interfaces
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        public Task<bool> IsExist(string username);
        public Task<Customer> getByUserNameAsync(string username);
        public Task<Customer> getByEmailAsync(string email);

        public Task<Customer> GetCustomerWithBorrowsAsync(int id);
        public Task<Customer> GetCustomerWithPurchaseAsync(int id);

    }
}
