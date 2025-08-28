using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    [Table("Purchases")]
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime purchaseDate { get; set; }

        [ForeignKey("book")]
        public int bookId { get; set; }
        public Book book { get; set; }

        [ForeignKey("customer")]
        public int customerId { get; set; }
        public Customer customer { get; set; }

        public Purchase()
        {
        }

        public Purchase(DateTime purchaseDate, int bookId, int customerId)
        {
            this.purchaseDate = purchaseDate;
            this.bookId = bookId;
            this.customerId = customerId;
        }
    }
}
