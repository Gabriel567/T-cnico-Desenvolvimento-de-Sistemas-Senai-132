using Microsoft.AspNetCore.Mvc;

namespace RoleTop.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}