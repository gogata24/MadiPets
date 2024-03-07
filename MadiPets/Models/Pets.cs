using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MadiPets.Models
{
    public class Pets
    {
        [Key]
        public int PetId { get; set; }
        [ForeignKey("Types")]
        public int TypeId { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public string ImagePath { get; set; }
    }
}
