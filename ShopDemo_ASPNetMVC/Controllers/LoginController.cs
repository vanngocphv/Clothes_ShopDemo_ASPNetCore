using Microsoft.AspNetCore.Mvc;

namespace ShopDemo_ASPNetMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
