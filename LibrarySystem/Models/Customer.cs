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
       public ICollection<Borrow> Borrows { get; set; } = new HashSet<Borrow>();
       public ICollection<Purchase> Purchase { get; set; } = new HashSet<Purchase>();

    }

}
