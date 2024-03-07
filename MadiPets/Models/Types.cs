using System.ComponentModel.DataAnnotations;

namespace MadiPets.Models
{
    public class Types
    {
        [Key]
        public int TypeId { get; set; }
        public string Type { get; set; }
    }
}
