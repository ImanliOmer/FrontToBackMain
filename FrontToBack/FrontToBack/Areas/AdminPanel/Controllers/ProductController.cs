using FrontToBack.DAL;
using FrontToBack.Extentions;
using FrontToBack.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_context.Products.Include(p=>p.Category).ToList());
        }
        public async Task<IActionResult> Detail(int? id)

        {
            if (id == null) return NotFound();
            Product product = await _context.Products.Include(p=>p.Category).FirstOrDefaultAsync(p=>p.Id==id);
            if (product == null) return NotFound();
            return View(product);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(),"Id","Name");

            return View();
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Create(Product product)
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            if (product.Photo==null)
            {
                ModelState.AddModelError("Photo", "Bosqoyma");
                return View();
            }
            if (!product.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "only Photo");
                View();

            }
            if (product.Photo.ValidSize(200))
            {
                ModelState.AddModelError("Photo", "olcu uygun deyil");
             return   View();

            }

            Product newProduct = new Product

            { 
                Price=product.Price,
                 Name=product.Name,
                 CategoryId=product.CategoryId,
                 ImageUrl=product.Photo.SaveImage(_env,"img")
            
            };
               
            
       
       await   _context.Products.AddAsync(newProduct);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
        public async Task< IActionResult> Delete(int? id)
        {
            Product dbproduct =  await _context.Products.FindAsync(id);
            string path = Path.Combine(_env.WebRootPath, "img",dbproduct.ImageUrl);
            if (dbproduct == null)
                Helpers.Helpers.DeleteImage(path);
            _context.Products.Remove(dbproduct);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
