using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync() 
        {
           int total = 0;
            ViewBag.Total = 0;
            ViewBag.BasketCount = 0;

            string basket = Request.Cookies["basket"];
            if (basket != null)
            {
                List<BasketVM> products = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
                ViewBag.BasketCount = products.Count();
                foreach (var item in products)
                {
               total += item.Price* item.ProductCount;
                }
            
            }
            ViewBag.Total = total;
            Bio bio = _context.Bios.FirstOrDefault();
            return View(await Task.FromResult(bio));
        
        }
    }
}
