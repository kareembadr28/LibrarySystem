using LibrarySystem.Dtos.PurchaseDtos;
using LibrarySystem.Exceptions;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using LibrarySystem.Services.Interfaces;

namespace LibrarySystem.Services.Implementations
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository purchaseRepository;
        private readonly IBookRepository bookRepository;
        private readonly ICustomerRepository customerRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository, IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            this.purchaseRepository = purchaseRepository;
            this.bookRepository = bookRepository;
            this.customerRepository = customerRepository;
        }

        public async Task<PurchaseDto> CreatePurchaseAsync(CreatePurchaseDto purchaseDto)
        {
        var customer=await customerRepository.GetByIdAsync(purchaseDto.CustomerId);
            if (customer == null)
                throw new CustomerNotFoundException("Customer not found");
            var book = await bookRepository.GetByIdAsync(purchaseDto.BookId);
            if (book == null)
                throw new BookNotFoundException("Book not found");
            if(book.stock <= 0)
                throw new BookOutOfStockException("Book is out of stock");
            var purchase = new Purchase
            {
                purchaseDate = DateTime.UtcNow,
                bookId = purchaseDto.BookId,
                customerId = purchaseDto.CustomerId,
                book = book,
                customer = customer

            };
            await purchaseRepository.AddAsync(purchase);
            book.stock -= 1;
             bookRepository.Update(book);
            await bookRepository.SaveChangesAsync();
            return new PurchaseDto
            {
                Id = purchase.Id,
                PurchaseDate = purchase.purchaseDate,
                BookTitle = book.title,
                CustomerName = customer.username
            };

        }

        public async Task DeletePurchaseAsync(int id)
        {
            var purchase =await purchaseRepository.GetByIdAsync(id);
            if (purchase == null)
                throw new PurchaseNotFoundException("Purchase not found");
            var book = await bookRepository.GetByIdAsync(purchase.bookId);
            if (book != null)
            {
                book.stock += 1;
                bookRepository.Update(book);
            }
             purchaseRepository.Delete(purchase);
            await purchaseRepository.SaveChangesAsync();

        }

        public async Task<IEnumerable<BasicPurchaseDto>> GetAllPurchasesAsync()
        {
            var purchases=await purchaseRepository.GetAllAsync();
            return purchases.Select(p => new BasicPurchaseDto
            {
                Id = p.Id,
                PurchaseDate = p.purchaseDate,
                BookId = p.bookId,
                CustomerId = p.customerId
            }).ToList();
        }

        public async Task<BasicPurchaseDto> GetPurchaseByIdAsync(int id)
        {
            var purchase=await purchaseRepository.GetByIdAsync(id);
            if (purchase == null)
                throw new PurchaseNotFoundException("Purchase not found");
            return new BasicPurchaseDto
            {
                Id = purchase.Id,
                PurchaseDate = purchase.purchaseDate,
                BookId = purchase.bookId,
                CustomerId = purchase.customerId
            };
        }

        public async Task<IEnumerable<BasicPurchaseDto>> GetPurchasesBetweenDatesAsync(DateTime startDate, DateTime endDate)
        {
           var purchases=await purchaseRepository.GetPurchasesBetweenDatesAsync(startDate, endDate);
            return purchases.Select(p => new BasicPurchaseDto
            {
                Id = p.Id,
                PurchaseDate = p.purchaseDate,
                BookId = p.bookId,
                CustomerId = p.customerId
            }).ToList();
        }

        public async Task<IEnumerable<PurchaseWithBookDto>> GetPurchasesByBookAsync(int bookId)
        {
            var book = await bookRepository.GetByIdAsync(bookId);
            if (book == null)
                throw new BookNotFoundException("Book not found");
            var purchases=await purchaseRepository.GetPurchasesByBookAsync(bookId);
            return purchases.Select(p => new PurchaseWithBookDto
            {
                Id = p.Id,
                PurchaseDate = p.purchaseDate,
                BookTitle = book.title
               
            }).ToList();
        }

        public async Task<IEnumerable<PurchaseWithCustomerDto>> GetPurchasesByCustomerAsync(int customerId)
        {
            var customer =await customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new CustomerNotFoundException("Customer not found");
            var purchases = await purchaseRepository.GetPurchasesByCustomerAsync(customerId);
            return purchases.Select(p => new PurchaseWithCustomerDto
            {
                Id = p.Id,
                PurchaseDate = p.purchaseDate,
                CustomerName = customer.username
            }).ToList();
        }
    }
}
