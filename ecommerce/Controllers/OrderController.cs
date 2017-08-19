using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ecommerce.Models;

namespace ecommerce.Controllers
{
    public class OrderController : Controller
    {

        private ecommerceContext _context;
 
        public OrderController(ecommerceContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("orders")]
        public IActionResult Index()
        {
            return View("orders");
        }
    }
}
