using System.ComponentModel.DataAnnotations.Schema;
using LibrarySystem.Enums;

namespace LibrarySystem.Models
{
    public class Borrow
    {
        public int Id { get; set; }
        public DateTime borrowDate { get; set; }
        public DateTime? returnDate { get; set; }

        public BorrowStatus status { get; set; }

        [ForeignKey("book")]
        public int bookId { get; set; }
        public Book book { get; set; }

        [ForeignKey("customer")]
        public int customerId { get; set; }
        public Customer customer { get; set; }

        public Borrow(DateTime borrowDate, int bookId, int customerId)
        {
            this.borrowDate = borrowDate;
            this.status = BorrowStatus.Borrowed;
            this.bookId = bookId;
            this.customerId = customerId;
        }

        public Borrow()
        {
        }


    }
}
