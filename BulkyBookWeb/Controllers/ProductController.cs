using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
       
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
                   }

        public IActionResult Index()
        {
            var obj = _context.Products;
            return View(obj);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
            if (obj.Title == obj.Quantiy.ToString())
            {
                ModelState.AddModelError("name", "The Quality cannot exatly match the Name");
            }
            if (ModelState.IsValid)
            {


              
                _context.Products.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Product created successfully";


                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null||id == 0)
            {
                return NotFound();
            }
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
         
            if (obj.Title == obj.Quantiy.ToString())
            {
                ModelState.AddModelError("name", "The Quality cannot exatly match the Name");
            }
            if (ModelState.IsValid)
            {
                _context.Products.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Product Update successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            TempData["success"] = "Product Deleted successfully";
            return RedirectToAction("Index");

        }

        public IActionResult IndexForUser()
        {
            var obj = _context.Products;
            return View(obj);
        }
    }
}

