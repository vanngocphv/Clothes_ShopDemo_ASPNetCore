using Microsoft.AspNetCore.Mvc;

namespace ShopDemo_ASPNetMVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
