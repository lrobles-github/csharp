using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using login_reg.Models;


namespace login_reg.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            return View();
        }


        // POST: /create-registration
        [HttpPost]
        [Route("register")]
        public IActionResult register(User user)
        {

            List<Dictionary<string, object>> CheckEmail= _dbConnector.Query("SELECT * from users WHERE email = '" + user.email + "'");

            if (CheckEmail.Count > 0)
            {
                ViewBag.EmailError= "User already exists.";
            }

            else if (ModelState.IsValid && CheckEmail.Count == 0)
            {
                _dbConnector.Execute("INSERT INTO users (first_name, last_name, email, password) VALUES ('" + user.first_name + "', '" + user.last_name + "', '" + user.email + "', '" + user.password + "')");
                List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
                
                foreach (var cell in AllUsers)
                {
                    System.Console.WriteLine("########################" + cell["id"] + " " + cell["first_name"] + " " + cell["last_name"] + " " + cell["email"]);
                }
            };

            // TryValidateModel(user);
            ViewBag.errors = ModelState.Values;
            return View("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult login(string email, string password)
        {

            ViewBag.LoggedIn = false;

            List<Dictionary<string, object>> CheckPw = _dbConnector.Query("SELECT password FROM users WHERE email = '" + email + "'");
            
            System.Console.WriteLine("#########################" + CheckPw[0]["password"] + " is " + password);

            if (CheckPw.Count > 0 && CheckPw[0]["password"].Equals(password))  
            {
                ViewBag.LoggedIn = true;
                System.Console.WriteLine("##################### Match!");
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }

}