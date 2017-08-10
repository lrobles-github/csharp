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
            ViewBag.errors = ModelState.Values;
            return View();
        }


        // POST: /create-registration
        [HttpPost]
        [Route("register")]
        public IActionResult create(User user)
        {
            if (ModelState.IsValid)
            {
                _dbConnector.Execute("INSERT INTO users (first_name, last_name, email, password) VALUES ('" + user.first_name + "', '" + user.last_name + "', '" + user.email + "', '" + user.password + "')");
                List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
                
                foreach (var cell in AllUsers)
                {
                    System.Console.WriteLine("########################" + cell["id"] + " " + cell["first_name"] + " " + cell["last_name"] + " " + cell["email"]);
                }
            };
            // TryValidateModel(NewUser);
            ViewBag.errors = ModelState.Values;
            return View();
        }



        // // POST: /validate-registration
        // [HttpPost]
        // [Route("validate_registration")]
        // public IActionResult validate_registration(string first_name, string last_name, string email, string password, string password_confirm)
        // {
        //     User NewUser = new User
        //     {
        //         first_name = first_name,
        //         last_name = last_name,
        //         email = email,
        //         password = password
        //     };
        //     TryValidateModel(NewUser);
        //     ViewBag.errors = ModelState.Values;
        //     return View();
        // }



        // // POST: /validate-registration
        // [HttpPost]
        // [Route("validate-registration")]
        // public IActionResult register(string first_name, string last_name, string email, string password) 
        // {
        //     // DbConnector.Execute("INSERT INTO users (first_name, last_name, email, password) VALUES ('" + first_name + "', '" + last_name + "', '" + email + "', '" + password + "')");
        //     // List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users");

        //     // foreach (var cell in AllUsers)
        //     // {
        //     //     System.Console.WriteLine("########################" + cell["id"] + " " + cell["first_name"] + " " + cell["last_name"] + " " + cell["email"]);
        //     // }

        //     return RedirectToAction("Index");
        // }
    }
}