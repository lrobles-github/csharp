using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ecommerce.Models;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ecommerce.Controllers
{
    public class DashboardController : Controller
    {
      
        private ecommerceContext _context;
 
        public DashboardController(ecommerceContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {

            // Customer TestCustomer = new Customer {
            //     Name = "Test Name",
            //     CreatedAt = DateTime.Now
            // };
            
            // Product TestProduct = new Product { 
            //     Name = "Poop Patrol Bags",
            //     Image  = "https://sep.yimg.com/ay/entirelypets/firstrax-poop-patrol-pet-waste-bag-6-refill-rolls-90-bags-17.jpg",
            //     Description = "",
            //     Quantity = 200,
            //     CreatedAt = DateTime.Now
            // };


            // Customer tc = _context.Customers.SingleOrDefault(x => x.Id == 1);
            // Product tp = _context.Products.SingleOrDefault(x => x.Id == 1);



            // Order TestOrder = new Order {
            //     Quantity = 2,
            //     Customer = tc,
            //     CreatedAt = DateTime.Now,
            //     Product = tp
            // };
            
            // // _context.Customers.Add(tc);
            // // _context.SaveChanges();
            // // _context.Products.Add(tp);
            // // _context.SaveChanges();
            // _context.Orders.Add(TestOrder);
            // _context.SaveChanges();

            // DateTime myTime = DateTime.Now;
            // System.TimeSpan elapsed = DateTime.Now - tc.CreatedAt;
            // int x = elapsed.Hours;
            // System.Console.WriteLine("###############  " + x + " hours ago");

            return View("dashboard");
        }
    }
}
