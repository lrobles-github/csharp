using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using theWall.Models;

namespace theWall.Controllers
{
    public class UserController : Controller
    {

        private readonly DbConnector _dbConnector;
 
        public UserController(DbConnector connect)
        {
            _dbConnector = connect;
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
        public IActionResult Register(User user)
        {

            System.Console.WriteLine("############# in register controller");
            System.Console.WriteLine("############# " + ModelState.IsValid);
            System.Console.WriteLine("############# " + user.password + " should equal " + user.passwordconfirm);

            List<Dictionary<string, object>> CheckEmail= _dbConnector.Query("SELECT * from users WHERE email = '" + user.email + "'");

            if (CheckEmail.Count > 0)
            {
                ViewBag.EmailError= "User already exists.";
            }

            else if (ModelState.IsValid && CheckEmail.Count == 0)
            {
                _dbConnector.Execute("INSERT INTO users (firstname, lastname, email, password) VALUES ('" + user.firstname + "', '" + user.lastname + "', '" + user.email + "', '" + user.password + "')");
                
                HttpContext.Session.SetInt32("LoggedIn", 1);
                HttpContext.Session.SetString("userfirstname", user.firstname);
                HttpContext.Session.SetInt32("userid", user.id);

                List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
                
                foreach (var cell in AllUsers)
                {
                    System.Console.WriteLine("########################" + cell["id"] + " " + cell["firstname"] + " " + cell["lastname"] + " " + cell["email"]);
                }

                return RedirectToAction("Wall", "wall");
            };

            return View(user);
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(User user)
        {
            System.Console.WriteLine("############ in login controller method");

            List<Dictionary<string, object>> CheckPassword= _dbConnector.Query("SELECT id, password FROM users WHERE email = '" + user.email + "'");

            if (CheckPassword.Count > 0 && user.password == (string)CheckPassword[0]["password"])
            {
                System.Console.WriteLine("############# Compare " + user.password + " with " + CheckPassword[0]["password"]);
                HttpContext.Session.SetInt32("LoggedIn", 1);
                HttpContext.Session.SetInt32("userid", (int)CheckPassword[0]["id"]);
                return RedirectToAction("Wall", "wall");
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
