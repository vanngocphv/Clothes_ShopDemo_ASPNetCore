using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopDemo_ASPNetMVC.Data;
using ShopDemo_ASPNetMVC.Models;

namespace ShopDemo_ASPNetMVC.Controllers
{
    public class ShopController : Controller
    {
        private ApplicationDbContext _context;
        public ShopController(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<IActionResult> Index(int? id = 1)
        {
            if (id != null && id < 1)
            {
                id = 1;
            }
            int pageSize = 12;

            var totalProduct = _context.Clothes;
            //return View(totalProduct);

            return View(await PaginatedList<Clothe>.CreateAsync(totalProduct.AsNoTracking(), id ?? 1, pageSize));
        }

        public async Task<IActionResult> Men(int? id = 1)
        {
            if (id != null && id < 1)
            {
                id = 1;
            }
            int pageSize = 12;

            var products = _context.Clothes.Where(x => (int) x.ClotheCategory == 0);
            //return View("Index", products);
            return View("Index", await PaginatedList<Clothe>.CreateAsync(products.AsNoTracking(), id ?? 1, pageSize));
        }
        public async Task<IActionResult> Women(int? id = 1)
        {
            if (id != null && id < 1)
            {
                id = 1;
            }
            int pageSize = 12;

            var products = _context.Clothes.Where(x => (int) x.ClotheCategory == 1);
            //return View("Index", products);
            return View("Index", await PaginatedList<Clothe>.CreateAsync(products.AsNoTracking(), id ?? 1, pageSize));
        }
        public async Task<IActionResult> Kid(int ? id = 1)
        {
            if (id != null && id < 1)
            {
                id = 1;
            }
            int pageSize = 12;

            var products = _context.Clothes.Where(x => (int) x.ClotheCategory == 2);
            //return View("Index", products);
            return View("Index", await PaginatedList<Clothe>.CreateAsync(products.AsNoTracking(), id ?? 1, pageSize));
        }
        public async Task<IActionResult> Accessory(int? id = 1)
        {
            if (id != null && id < 1)
            {
                id = 1;
            }
            int pageSize = 12;

            var products = _context.Clothes.Where(x => (int) x.ClotheCategory == 3);
            //return View("Index", products);
            return View("Index", await PaginatedList<Clothe>.CreateAsync(products.AsNoTracking(), id ?? 1, pageSize));
        }

        public IActionResult Detail(int id)
        {
            Clothe product = _context.Clothes.SingleOrDefault(c => c.Id == id);
            return View(product);
        }
    }
}
