using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    [Table("Customers")]
    public class Customer:User
    {
        public Customer(string username, string passwordHash, string email) : base(username, passwordHash, email)
        {
        }


        public Customer() : base()
        {
        }
        ICollection<Borrow> Borrows { get; set; } = new HashSet<Borrow>();
        ICollection<Purchase> Purchase { get; set; } = new HashSet<Purchase>();

    }

}
