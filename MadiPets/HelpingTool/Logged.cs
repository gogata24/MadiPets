using MadiPets.Models;
using MadiPets.ViewModel;

namespace MadiPets.HelpingTool
{
    public class Logged
    {
        public static LoginViewModel Login { get; set; } = new LoginViewModel();
        public static Users User { get; set; } = new Users();   

    }
}
