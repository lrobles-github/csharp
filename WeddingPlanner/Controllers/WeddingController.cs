using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private WeddingPlannerContext _context;
 
        public WeddingController(WeddingPlannerContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            System.Console.WriteLine("############## In Dashboard...");
            
            if (HttpContext.Session.GetInt32("LoggedIn") == 1) 
            {
                ViewBag.AllWeddings = _context.Weddings.Include(w => w.Guests).ToList();

                ViewBag.UserId = (int)HttpContext.Session.GetInt32("UserId");

                return View("dashboard");
            } 
            else 
            {
                return RedirectToAction("index", "User");
            }
        }


        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            System.Console.WriteLine("############  In Add page...");

            if (HttpContext.Session.GetInt32("LoggedIn") == 1) 
            {
                ViewBag.Today = DateTime.Now.ToString("yyyy-MM-dd");
                return View("add");
            } 
            else 
            {
                return RedirectToAction("index");
            }
        }


        [HttpPost]
        [Route("add")]
        public IActionResult Add(WeddingViewModel wedding)
        {
            int x = (int)HttpContext.Session.GetInt32("UserId");
            System.Console.WriteLine(", " + x);
            System.Console.WriteLine(wedding.Date.GetType() + " ====== " + DateTime.Now.GetType());
            System.Console.WriteLine("############# ModelState.IsValid?" + ModelState.IsValid);
            
            if (wedding.Date < DateTime.Now)
            {
                ViewBag.DateError = "Date must be in the future.";
                ViewBag.Today = DateTime.Now.ToString("yyyy-MM-dd");
                return View("add");
            }
            else if (ModelState.IsValid)
            {
                System.Console.WriteLine("############ model is valid");
                Wedding NewWedding = new Wedding {
                    FirstName = wedding.FirstName, 
                    SecondName = wedding.SecondName, 
                    Date = wedding.Date, 
                    CreatedAt = DateTime.Now,
                    Address = wedding.Address, 
                    UserId = (int)HttpContext.Session.GetInt32("UserId") 
                    };
                    
                _context.Weddings.Add(NewWedding);
                _context.SaveChanges();
                System.Console.WriteLine("##########  NewWedding id:" + NewWedding.Id);
                System.Console.WriteLine("########### new item should have been created...");
                return RedirectToAction("show", new { id = NewWedding.Id} );
            }
            else 
            {
                System.Console.WriteLine("############# Redirecting to dashboard, no new item created...");
                return RedirectToAction("dashboard");
            }
        }


        [HttpGet]
        [Route("show/{id}")]
        public IActionResult Show(int id)
        {
            Wedding GetWedding = _context.Weddings.Include(x => x.Guests).ThenInclude(z => z.User).SingleOrDefault(x => x.Id == id);
            return View("show", GetWedding);
        }

        
        [HttpGet]
        [Route("notattend/{id}")]
        public IActionResult NotAttend(int id)
        {
            Guest GetGuest = _context.Guests.SingleOrDefault(x => x.WeddingId == id);
            System.Console.WriteLine("########## GetGuest is" + GetGuest.Id);
            _context.Guests.Remove(GetGuest);
            _context.SaveChanges();
            ViewBag.AttendToggle = false;
            return RedirectToAction("dashboard");
        }


        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Wedding GetWedding = _context.Weddings.SingleOrDefault(x => x.Id == id);
            System.Console.WriteLine("########## GetWedding is" + GetWedding.Id);
            _context.Weddings.Remove(GetWedding);
            _context.SaveChanges();
            return RedirectToAction("dashboard");
        }
        

        [HttpGet]
        [Route("attend/{id}")]
        public IActionResult Attend(int id)
        {
            Guest NewGuest = new Guest { 
                WeddingId = id, 
                UserId = (int)HttpContext.Session.GetInt32("UserId")  
                };

            _context.Guests.Add(NewGuest);
            _context.SaveChanges();
            ViewBag.AttendToggle = true;
            return RedirectToAction("dashboard");
        }
    }
}
