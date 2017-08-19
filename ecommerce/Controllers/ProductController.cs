using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ecommerce.Models;

namespace ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private ecommerceContext _context;
 
        public ProductController(ecommerceContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("products")]
        public IActionResult Index()
        {
            return View("products");
        }
    }
}
