using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using WeddingPlanner.Models;


namespace WeddingPlanner.Controllers
{
    public class UserController : Controller
    {

        private WeddingPlannerContext _context;
 
        public UserController(WeddingPlannerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            return View("index");
        }


        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View("register");
        }


        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserViewModel user)
        {

            System.Console.WriteLine("############# in register controller");
            System.Console.WriteLine("############# " + ModelState.IsValid);
            System.Console.WriteLine("############# " + user.Password + " should equal " + user.PasswordConfirm);

            User EmailChecker = _context.Users.SingleOrDefault(x => x.Email == user.Email);

            if (EmailChecker != null)
            {
                ViewBag.EmailError= "User already exists.";
            }

            else if (ModelState.IsValid && EmailChecker == null)
            {
                User newUser = new User {FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Password = user.Password, CreatedAt = DateTime.Now};
                _context.Users.Add(newUser);
                _context.SaveChanges();
                
                HttpContext.Session.SetInt32("LoggedIn", 1);
                HttpContext.Session.SetString("UserFirstName", user.FirstName);
                HttpContext.Session.SetInt32("UserId", user.Id);
                
                System.Console.WriteLine("############ Redirecting to dashboard...");
                return RedirectToAction("dashboard", "Wedding");
            }

            return View();

        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(User user)
        {
            System.Console.WriteLine("############ in login controller method");
            
            User UserChecker = _context.Users.SingleOrDefault(x => x.Email == user.Email);

            if (UserChecker != null && user.Password == (string)UserChecker.Password)
            {
                System.Console.WriteLine("############# Compare " + user.Password + " with " + UserChecker.Password);
                HttpContext.Session.SetInt32("LoggedIn", 1);
                HttpContext.Session.SetInt32("UserId", (int)UserChecker.Id);
                return RedirectToAction("dashboard", "Wedding");
            }
            else
            {
                ViewBag.EmailError= "Wrong username or password.";
                return View("index");                
            }
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("index");
        }

    }
}
