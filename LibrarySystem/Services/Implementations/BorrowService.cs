using LibrarySystem.Dtos.BorrowDtos;
using LibrarySystem.Enums;
using LibrarySystem.Exceptions;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Interfaces;
using LibrarySystem.Services.Interfaces;

namespace LibrarySystem.Services.Implementations
{
    public class BorrowService : IBorrowService
    {
        private readonly IBookRepository bookRepository;
        private readonly IBorrowRepository borrowRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly decimal finePerDay;
        private readonly int borrowPeriodDays;

        public BorrowService(IBookRepository bookRepository, IBorrowRepository borrowRepository,
                            ICustomerRepository customerRepository,IConfiguration configuration)
        {
            this.bookRepository = bookRepository;
            this.borrowRepository = borrowRepository;
            this.customerRepository = customerRepository;
            finePerDay = configuration.GetValue<decimal>("LibrarySettings:FinePerDay",1);
            borrowPeriodDays = configuration.GetValue<int>("LibrarySettings:BorrowPeriodDays",14);
        }
        public async Task<BorrowDto> BorrowBookAsync(int customerId, int bookId)
        {
           var customer =await customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new CustomerNotFoundException("Customer not found");
            var book = await bookRepository.GetByIdAsync(bookId);
            if (book == null)
                throw new BookNotFoundException("Book not found");
            if(book.stock <= 0)
                throw new BookOutOfStockException("Book is out of stock");
            var Borrow = new Borrow
            {
                bookId = bookId,
                customerId = customerId,
                borrowDate = DateTime.UtcNow,
                status = Enums.BorrowStatus.Borrowed,
                book = book,
                customer = customer
            };
            await borrowRepository.AddAsync(Borrow);

            book.stock -= 1;
             bookRepository.Update(book);
            await bookRepository.SaveChangesAsync();
            return new BorrowDto
            {
                bookId = bookId,
                customerId = customerId,
                borrowDate = Borrow.borrowDate,
                returnDate = Borrow.returnDate,
                status = Borrow.status.ToString()
            };


        }

        public async Task<decimal> CalculateFineAsync(int borrowId)
        {
            var borrow =await borrowRepository.GetByIdAsync(borrowId);
            if (borrow == null)
                throw new BorrowNotFoundException("Borrow record not found");
            var endDate = borrow.returnDate ?? DateTime.UtcNow;
            var daysBorrowed = (endDate - borrow.borrowDate).Days;
            if (daysBorrowed <= borrowPeriodDays)
                return 0;
            var fine = (decimal)(daysBorrowed - borrowPeriodDays) * finePerDay; 
              return fine;
        }

        public async Task<IEnumerable<BorrowDto>> GetActiveBorrowsAsync()
        {
           var borrows=await borrowRepository.GetActiveBorrowsAsync();
            return borrows.Select(b => new BorrowDto
            {
                bookId = b.bookId,
                customerId = b.customerId,
                borrowDate = b.borrowDate,
                returnDate = b.returnDate,
                status = b.status.ToString()
            }).ToList();
        }

        public async Task<IEnumerable<BorrowDto>> GetBorrowsByBookIdAsync(int bookId)
        {
            var borrows =await  borrowRepository.GetBorrowsByBookIdAsync(bookId);
            return borrows.Select(b => new BorrowDto
            {
                bookId = b.bookId,
                customerId = b.customerId,
                borrowDate = b.borrowDate,
                returnDate = b.returnDate,
                status = b.status.ToString()
            }).ToList();
        }

        public async Task<IEnumerable<BorrowDto>> GetBorrowsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var borrows =await borrowRepository.GetBorrowsByDateRangeAsync(startDate, endDate);
            return borrows.Select(b => new BorrowDto
            {
                bookId = b.bookId,
                customerId = b.customerId,
                borrowDate = b.borrowDate,
                returnDate = b.returnDate,
                status = b.status.ToString()
            }).ToList();
        }

        public async Task<IEnumerable<BorrowDto>> GetBorrowsByUserIdAsync(int userId)
        {
            var borrows =await borrowRepository.GetBorrowsByUserIdAsync(userId);
            return borrows.Select(b => new BorrowDto
            {
                bookId = b.bookId,
                customerId = b.customerId,
                borrowDate = b.borrowDate,
                returnDate = b.returnDate,
                status = b.status.ToString()
            }).ToList();
        }

        public async Task<BorrowDetailsDto?> GetBorrowWithDetailsAsync(int borrowId)
        {
            var borrow = await borrowRepository.GetBorrowWithDetailsAsync(borrowId);
            if (borrow == null) return null;
            return new BorrowDetailsDto
            {
               bookTitle = borrow.book.title,
                customerName = borrow.customer.username,
                borrowDate = borrow.borrowDate,
                returnDate = borrow.returnDate,
                status = borrow.status.ToString()

            };
        }

        public async Task<bool> IsBookBorrowedByUserAsync(int userId, int bookId)
        {
           var ans =await borrowRepository.IsBookBorrowedByUserAsync(userId, bookId);
            return ans;
        }

        public async Task<ReturnBorrowDto> ReturnBookAsync(int borrowId)
        {
            var borrow =await borrowRepository.GetByIdAsync(borrowId);
            if (borrow == null)
                throw new BorrowNotFoundException("Borrow record not found");
            if (borrow.status == BorrowStatus.Returned)
                throw new InvalidOperationException("Book already returned");
            borrow.status = BorrowStatus.Returned;
            borrow.returnDate = DateTime.UtcNow;
            borrowRepository.Update(borrow);
            var book = await bookRepository.GetByIdAsync(borrow.bookId);
            book.stock += 1;
            bookRepository.Update(book);
            await borrowRepository.SaveChangesAsync();
            return new ReturnBorrowDto
            {
                bookTitle = book.title,
                customerName = borrow.customer.username,
                borrowDate = borrow.borrowDate,
                returnDate = borrow.returnDate,
                status = borrow.status.ToString(),
                fine = await CalculateFineAsync(borrowId)
            };

        }
    }
}
