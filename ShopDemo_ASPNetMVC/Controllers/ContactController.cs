using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopDemo_ASPNetMVC.Data;
using ShopDemo_ASPNetMVC.Models;
using System.Text.RegularExpressions;

namespace ShopDemo_ASPNetMVC.Controllers
{
    public class ContactController : Controller
    {
        private ApplicationDbContext _dbContext;
        public ContactController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendContact(ContactMessage contactMessage)
        {

            if (contactMessage.Message.Length > 500)
            {
                ModelState.AddModelError("Message", "Your Message greater than 500 character, cannot send, please check again");
            }

            //Create value into database
            if (ModelState.IsValid)
            {
                contactMessage.Message = contactMessage.Message.Replace(System.Environment.NewLine, "\\n");
                Regex reg = new Regex("['\"]");
                contactMessage.Message = reg.Replace(contactMessage.Message, "\\\"");

                _dbContext.ContactMessages.Add(contactMessage);
                _dbContext.SaveChanges();


                TempData["Success"] = "Your Contact has been uploaded, we will check after!";
                return RedirectToAction("");
            }

            TempData["Error"] = "Your Contact has something wrong, please check and try again!";
            return View(contactMessage);
        }
    }
}
