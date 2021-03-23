using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using ShoppingApp.Models;

namespace ShoppingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public EntityContext EContext;
        public int CartId = 0;
        public decimal Tax = 0.05M;
             
        public HomeController(ILogger<HomeController> logger, EntityContext entityContext)
        {
            EContext = entityContext;
            _logger = logger;           
        }
            
        public IActionResult SearchItems(string Term) 
        {
            IEnumerable<Item> SearchResult = EContext.Items.Where(c => c.Name == Term);
            return View(SearchResult);
        }
        public IActionResult ItemByCategory(int Id) 
        {
            IEnumerable<Item> Items = EContext.Items.Where(c => c.CategoryId == Id);
            return View(Items);
        }
        public IActionResult ItemView(int id) 
        {           
            Item item = EContext.Items.Find(id);
            ItemNCount itemNCount = new ItemNCount(item.Id,item.Name,item.ImagePath,1,CartId,item.Cost);
            return View(itemNCount);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ItemToCart(ItemNCount itemNCount) 
        {
            if (ModelState.IsValid) 
            {                 
                addToCart(itemNCount);
            }
            return RedirectToAction("SeeCart");
        }
        public IActionResult SeeCart() 
        {
            Order Cart = BuildCart();           
            return View(Cart);       
        }
        
        public IActionResult CheckOut() 
        {
            Order Cart = BuildCart();
            Cart.DateSubMitted = DateTime.Now;
            EContext.Orders.Add(Cart);
            IEnumerable<ItemNCount> OldCart = EContext.ItemsNCounts.Where(c => c.ForeignKey == Cart.Id);
            EContext.ItemsNCounts.RemoveRange(OldCart);
            EContext.SaveChanges();
            return View(Cart);
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = EContext.Categories;
            return View(categories);
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
        public void addToCart(ItemNCount itemandcount)
        {            
           if (itemandcount != null)
           {
                var ItemQ =
                    from e in EContext.ItemsNCounts
                    where e.ForeignKey == itemandcount.ForeignKey && e.ItemId == itemandcount.ItemId
                    select e;              
                if (ItemQ != null && ItemQ.Count() > 0) 
                {
                    if (ItemQ.Count() > 1)
                    {
                        EContext.ItemsNCounts.RemoveRange(ItemQ);
                        if (itemandcount.Count >= 0 ) 
                        {
                            EContext.ItemsNCounts.Add(itemandcount);
                        }                      
                        EContext.SaveChanges();
                    }
                    else if (itemandcount.Count <= 0)
                    {
                        EContext.ItemsNCounts.RemoveRange(ItemQ);
                        EContext.SaveChanges();
                    }
                    else 
                    {
                        ItemQ.First().Count = itemandcount.Count;
                        EContext.SaveChanges();
                    }                   
                }              
                else if(itemandcount.Count > 0)
                {
                    EContext.ItemsNCounts.Add(itemandcount);
                    EContext.SaveChanges();
                }           
           }           
        }
        public Order BuildCart() 
        {
            Order Cart = new Order(Tax);
            List<ItemNCount> ItemNCounts = EContext.ItemsNCounts.Where(c => c.ForeignKey == CartId).ToList();
            Cart.Items.AddRange(ItemNCounts);
            Cart.Subtotal = Cart.subtotal(ItemNCounts);
            Cart.Total = Cart.total(Cart.Subtotal,Cart.Tax);
            return Cart;
        }
        public bool UserExists(string Email) 
        {
            bool found = false;
            foreach (User u in EContext.Users) 
            {
                if (u.Email == Email) { found = true; }
            }
            return found;
        }
    }
     
}
