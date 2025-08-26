using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string iSBN { get; set; }   
        public DateTime publishedDate { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }

        [ForeignKey("author")]
        public int authorId { get; set; }
        public Author author { get; set; }

        [ForeignKey("category")]
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public ICollection<Borrow> borrows { get; set; }=new HashSet<Borrow>();
        public ICollection<Purchase> purchases { get; set; }=new HashSet<Purchase>();

        public ICollection<Publisher> publishers { get; set; }=new HashSet<Publisher>();

        public Book(string title, string iSBN, DateTime publishedDate, decimal price, int stock, int authorId, int categoryId)
        {
            this.title = title;
            this.iSBN = iSBN;
            this.publishedDate = publishedDate;
            this.price = price;
            this.stock = stock;
            this.authorId = authorId;
            this.CategoryId = categoryId;
        }

        public Book()
        {
        }
    }
}
