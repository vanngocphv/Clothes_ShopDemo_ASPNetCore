using Microsoft.AspNetCore.Mvc;
using ShopDemo_ASPNetMVC.Data;
using ShopDemo_ASPNetMVC.Models;
using System.Diagnostics;

namespace ShopDemo_ASPNetMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Men"] = _context.Clothes.Where((clothe) => (int) clothe.ClotheCategory == 0).ToList();
            ViewData["Women"] = _context.Clothes.Where((clothe) => (int) clothe.ClotheCategory == 1).ToList();
            ViewData["Kid"] = _context.Clothes.Where((clothe) => (int) clothe.ClotheCategory == 2).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}