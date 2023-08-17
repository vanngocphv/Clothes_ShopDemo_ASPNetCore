using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using ShopDemo_ASPNetMVC.Data;
using ShopDemo_ASPNetMVC.Models;
using System.Text.RegularExpressions;

namespace ShopDemo_ASPNetMVC.Controllers
{
    public class ManagerController : Controller
    {
        private ApplicationDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        public ManagerController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }


        [Route("manager/test/")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Clothes(int? id = 1)
        {
            //IEnumerable<Clothe> clothes = _context.Clothes.Include(item => item.ClotheCategory).ToList();
            //return View(clothes);
            if (id != null && id < 1)
            {
                id = 1;
            }

            int pageSize = 5;
            var clothes = _context.Clothes;
            return View(await PaginatedList<Clothe>.CreateAsync(clothes.AsNoTracking(), id ?? 1, pageSize));
        }
        public async Task<IActionResult> UpdateClothes(List<Clothe> list)
        {
            
            //Create value into database
            var cloth = list[0];
            Clothe respCloth = _context.Clothes.SingleOrDefault(x => x.Id == cloth.Id);
            //if file image not null, copy path and set for respCloth
            if (cloth.FileImage != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(cloth.FileImage.FileName);
                string extension = Path.GetExtension(cloth.FileImage.FileName);
                string fileWithDateAndExtension = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                cloth.Image = "/images/" + fileWithDateAndExtension;
                //upload into wwwroot
                string path = Path.Combine(wwwRootPath + "/images/", fileWithDateAndExtension);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await cloth.FileImage.CopyToAsync(filestream);
                }

                respCloth.Image = cloth.Image;
            }

            if (respCloth.Name != cloth.Name) respCloth.Name = cloth.Name;
            if (respCloth.ClotheCategory != cloth.ClotheCategory)
            {
                //respCloth.ClotheCategory.Id = cloth.ClotheCategory.Id;
                //respCloth.ClotheCategory.CategoryName = _context.ClotheCategories.SingleOrDefault(item => item.Id == respCloth.ClotheCategory.Id).CategoryName;
                respCloth.ClotheCategory = cloth.ClotheCategory;
            }
            if (respCloth.Price != cloth.Price) respCloth.Price = cloth.Price;
            if (respCloth.Description != cloth.Description) { 
                respCloth.Description = cloth.Description;
                respCloth.Description = respCloth.Description.Replace(System.Environment.NewLine, "\\n");
                Regex reg = new Regex("['\"]");
                respCloth.Description = reg.Replace(respCloth.Description, "\\\"");
            }
            //image check later

            try
            {
                _context.Clothes.Update(respCloth);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                TempData["Error"] = "Something wrong, please try again!";
                return RedirectToAction("Clothes");
            }


            TempData["Success"] = "Your Cloth data has been changed";
            return RedirectToAction("Clothes");
        }

        public async Task<IActionResult> CreateClothes(List<Clothe> list)
        {

            //Create value into database
            Clothe cloth = list[0];

            //Handle Image and upload file
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (cloth.FileImage != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(cloth.FileImage.FileName);
                string extension = Path.GetExtension(cloth.FileImage.FileName);
                string fileWithDateAndExtension = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                cloth.Image = "/images/" + fileWithDateAndExtension;
                //upload into wwwroot
                string path = Path.Combine(wwwRootPath + "/images/", fileWithDateAndExtension);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await cloth.FileImage.CopyToAsync(filestream);
                }
            }
            else
            {
                cloth.Image = "/images/370x390.jpg";
            }


            //handle clear \\ value in description
            cloth.Description = cloth.Description.Replace(System.Environment.NewLine, "\\n");
            Regex reg = new Regex("['\"]");
            cloth.Description = reg.Replace(cloth.Description, "\\\"");

            
            //try insert
            try
            {
                _context.Clothes.Add(cloth);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                TempData["Error"] = "Something wrong, please try again!";
                return RedirectToAction("Clothes");
            }


            TempData["Success"] = "Your Cloth data has been added";
            return RedirectToAction("Clothes");
        }

        public async Task<IActionResult> Orders(int? id = 1)
        {
            if (id != null && id < 1)
            {
                id = 1;
            }

            int pageSize = 5;
            var customerOrder = _context.Customers;
            return View(await PaginatedList<Customer>.CreateAsync(customerOrder.AsNoTracking(), id ?? 1, pageSize));

            //IEnumerable<Customer> customerOrder = _context.Customers.ToList();
            //return View(customerOrder);
        }

        public async Task<IActionResult> Contacts(int? id = 1)
        {
            if (id != null && id < 1)
            {
                id = 1;
            }

            //IEnumerable<ContactMessage> contactMessages = _context.ContactMessages.ToList();
            //return View(contactMessages);
            int pageSize = 5;

            var contactMessages = _context.ContactMessages;
            return View(await PaginatedList<ContactMessage>.CreateAsync(contactMessages.AsNoTracking(), id ?? 1, pageSize));
        }
    }
}
