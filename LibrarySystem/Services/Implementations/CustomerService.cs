using LibrarySystem.Dtos;
using LibrarySystem.Dtos.BorrowDtos;
using LibrarySystem.Dtos.CustomerDtos;
using LibrarySystem.Dtos.PurchaseDtos;
using LibrarySystem.Exceptions;
using LibrarySystem.Repositories.Implementation;
using LibrarySystem.Repositories.Interfaces;
using LibrarySystem.Services.Interfaces;
namespace LibrarySystem.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<CustomerWithBorrowsDto> GetCustomerWithBorrowsAsync(int id)
        {
            var customers = await customerRepository.GetCustomerWithBorrowsAsync(id);
            if(customers == null)
            {
                throw new CustomerNotFoundException("Customer not found");
            }
            var customerDto = new CustomerWithBorrowsDto
            {
                Name = customers.username,
                Email = customers.Email,
                Borrows = customers.Borrows.Select(b => new BorrowDto
                {
                    borrowDate = b.borrowDate,
                    returnDate = b.returnDate,
                    bookId = b.bookId,
                    status = b.status.ToString(),
                    customerId = b.customerId

                }).ToList()
            };
            return customerDto;
        }

        public async Task<CustomerWithPurchasesDto> GetCustomerWithPurchasesAsync(int id)
        {
            var customers = await customerRepository.GetCustomerWithPurchaseAsync(id);
            if (customers == null)
            {
                throw new CustomerNotFoundException("Customer not found");
            }
            var customerDto = new CustomerWithPurchasesDto
            {
                Name = customers.username,
                Email = customers.Email,
                Purchases = customers.Purchase.Select(p => new PurchaseDto
                {
                    Id = p.Id,
                    PurchaseDate = p.purchaseDate,
                    BookTitle = p.book.title,
                    CustomerName = customers.username
                }).ToList()
            };
            return customerDto;
               
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var customer = await customerRepository.getByEmailAsync(email);
            if (customer == null) return null;
            var adminDto = new UserDto
            {
                Id = customer.Id,
                UserName = customer.username,
                Email = customer.Email,
                Role = "Admin"
            };
            return adminDto;
        }

        public async Task<UserDto> GetByUserNameAsync(string username)
        {
            var customer = await customerRepository.getByUserNameAsync(username);
            if (customer == null) return null;
            var adminDto = new UserDto
            {
                Id = customer.Id,
                UserName = customer.username,
                Email = customer.Email,
                Role = "Admin"
            };
            return adminDto;
        }

        public async Task<bool> IsExistAsync(string username)
        {
            return await customerRepository.IsExist(username);
        }

    }
}
