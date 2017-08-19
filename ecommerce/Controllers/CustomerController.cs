using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ecommerce.Models;


namespace ecommerce.Controllers
{
    public class CustomerController : Controller
    {

        private ecommerceContext _context;
 
        public CustomerController(ecommerceContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("customers")]
        public IActionResult Index()
        {
            return View("customers");
        }
    }
}
