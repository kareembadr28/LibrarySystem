using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime purchaseDate { get; set; }

        [ForeignKey("book")]
        public int bookId { get; set; }
        public Book book { get; set; }

        [ForeignKey("user")]
        public int userId { get; set; }
        public User user { get; set; }

        public Purchase()
        {
        }

        public Purchase(DateTime purchaseDate, int bookId, int userId)
        {
            this.purchaseDate = purchaseDate;
            this.bookId = bookId;
            this.userId = userId;
        }
    }
}
