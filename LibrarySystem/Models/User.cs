using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string username { get; set; }

        [Column("password")]
        [Required]
        public string PasswordHash { get; set; }
        public string Email { get; set; }

        public User()
        {

        }

        public User(string username, string passwordHash, string email)
        {
            this.username = username;
            this.PasswordHash = passwordHash;
            this.Email = email;
        }


    }
}
