using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Controllers
{
    public class BasketController : Controller
    {

        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddItem(int? id)
        {
            //HttpContext.Session.SetString("Person", "Aqil");
            //Response.Cookies.Append("group", "p322", new CookieOptions {MaxAge=TimeSpan.FromDays(14) });
            if (id == null) return NotFound();

            Product dbProduct = await _context.Products.FindAsync(id);

            if (dbProduct == null) return NotFound();
            List<BasketVM> products;
            if (Request.Cookies["basket"] == null)
            {
                products = new List<BasketVM>();
            }
            else {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            BasketVM existProduct = products.Find(x => x.Id == id);
            if (existProduct == null)
            {
                BasketVM basketVM = new BasketVM
                {
                    Id = dbProduct.Id,
                    Price = dbProduct.Price,
                    ImageUrl = dbProduct.ImageUrl,
                    CategoryId = dbProduct.CategoryId,
                    Name = dbProduct.Name,
                    ProductCount = 1


                };
                products.Add(basketVM);
            }
            else 
            {
                existProduct.ProductCount++;
            
            
            }
     
         
            Response.Cookies.Append("basket",JsonConvert.SerializeObject(products),new CookieOptions { MaxAge=TimeSpan.FromDays(5)});
            return RedirectToAction("index","home");
        }
        public IActionResult ShowItem()
        {

            string basket = Request.Cookies["basket"];
            List<BasketVM> products;
            if (basket != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                foreach (var item in products)
                {
                    Product dbProduct = _context.Products.FirstOrDefault(x => x.Id == item.Id);
                    item.Price = dbProduct.Price;
                    item.ImageUrl = dbProduct.ImageUrl;
                    item.CategoryId = dbProduct.CategoryId;
                    item.Name = dbProduct.Name;


                }
            }
            else 
            {
                products=new List<BasketVM>();


            }
            
            
            return View(products);
        }
        public IActionResult Delete(int? id)
        {
            List<BasketVM> basketVMs;
            string basket = Request.Cookies["basket"];
           basketVMs =   JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            basketVMs.RemoveAll(p => p.Id == id);
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketVMs), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });
        
            return Json(basketVMs.Count);

        }
        public IActionResult Plus(int? id)
        {

            List<BasketVM> products;
            string basket = Request.Cookies["basket"];
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM product = products.Find(p => p.Id == id);
         

            product.ProductCount = product.ProductCount + 1;
            product.Sum = product.Price * product.ProductCount;

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
            var productPlusObj = new
            {
                productCount = product.ProductCount,
                productSum=product.Sum
            };
            return Json(productPlusObj);
        }
        public IActionResult Minus(int? id)
        {
            

            List<BasketVM> products;
            string basket = Request.Cookies["basket"];
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM product = products.Find(p => p.Id == id);

         
            product.ProductCount = product.ProductCount -1;
            product.Sum = product.Price * product.ProductCount;
            if (product.ProductCount==0)
            {
                products.Remove(product);
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
            var productPlusObj = new
            {
                productCount = product.ProductCount,
                productSum = product.Sum
            };
            return Json(productPlusObj);
        }
    }
}
