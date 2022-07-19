using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
          
            HomeVM homeVm=new HomeVM();
            homeVm.Sliders = _context.Sliders.ToList();
            homeVm.SliderContent = _context.SliderContents.FirstOrDefault();
            homeVm.Categories= _context.Categories.ToList();
            homeVm.Products = _context.Products.Include(p=>p.Category).ToList();
            homeVm.Experts=_context.Experts.ToList();
            homeVm.Blogs=_context.Blogs.ToList();
            homeVm.CaruselBlogs=_context.CaruselBlogs.ToList();
            homeVm.Instagrams= _context.Instagrams.ToList();
            return View(homeVm);
        }
        public IActionResult SearchProduct(string search) 
        {

            List<Product> products = _context.Products
                 .Include(p => p.Category)
                .OrderBy(p => p.Id)

                .Where(p => p.Name.ToLower()
                  .Contains(search.ToLower()))
                 .Take(10)
                .ToList();
            return PartialView("_SearchPartial",products);
        
        }
    }
}
