using MadiPets.Db;
using MadiPets.Models;
using MadiPets.ViewModel;
using MadiPets.HelpingTool;
using Microsoft.AspNetCore.Mvc;


namespace MadiPets.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(LoginViewModel model)
        {
            using (var db = new MadiPetsDbContext())
            {
                Users user = db.Users.FirstOrDefault(x => x.Username == model.Username);
                if (user != null)
                {
                    if (user.Password == model.Password)
                    {
                        Logged.Login = new LoginViewModel() { Username = model.Username, Password = model.Password };
                        Logged.User = user;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
    }
}
