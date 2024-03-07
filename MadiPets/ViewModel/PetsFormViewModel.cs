using MadiPets.Models;

namespace MadiPets.ViewModel
{
    public class PetsFormViewModel
    {
        public List<Users> Users { get; set; } = new List<Users>();
        public List<Types> Types { get; set; } = new List<Types>();
    }
}
