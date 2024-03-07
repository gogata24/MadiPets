using MadiPets.Models;

namespace MadiPets.ViewModel
{
    public class PetsViewModel
    {
        public int PetId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}

