using System.ComponentModel.DataAnnotations;

namespace MadiPets.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
