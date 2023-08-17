using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopDemo_ASPNetMVC.Data;
using ShopDemo_ASPNetMVC.Models;

namespace ShopDemo_ASPNetMVC.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(Customer model)
        {
            if (model.TotalPurchase == 0 || model.TotalPurchase == null)
            {
                ModelState.AddModelError("TotalPurchase", "The value cannot be 0 or nothing");
            }

            //Create value into database
            if (ModelState.IsValid)
            {
                model.Message = model.Message?.Replace(System.Environment.NewLine, "\\n");
                model.TotalProductPurchase = model.TotalProductPurchase.Replace("\"", "\\\"");
                
                
                _context.Customers.Add(model);
                _context.SaveChanges();


                TempData["Success"] = "Your order has been registed!";
                return Redirect("~/Home/Index");
            }

            TempData["Error"] = "Your order information has been wrong, check again!";
            return View(model);

        }
    }
}
