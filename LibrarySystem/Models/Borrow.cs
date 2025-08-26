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

        [ForeignKey("user")]
        public int userId { get; set; }
        public User user { get; set; }

        public Borrow(DateTime borrowDate, int bookId, int userId)
        {
            this.borrowDate = borrowDate;
            this.status = BorrowStatus.Borrowed;
            this.bookId = bookId;
            this.userId = userId;
        }

        public Borrow()
        {
        }


    }
}
