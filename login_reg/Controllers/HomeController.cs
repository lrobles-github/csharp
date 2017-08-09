using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;


namespace login_reg.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        // POST: /validate-registration
        [HttpPost]
        [Route("validate-registration")]
        public IActionResult register(string first_name, string last_name, string email, string password) 
        {
            DbConnector.Execute("INSERT INTO users (first_name, last_name, email, password) VALUES ('" + first_name + "', '" + last_name + "', '" + email + "', '" + password + "')");
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users");

            foreach (var cell in AllUsers)
            {
                System.Console.WriteLine("########################" + cell["id"] + " " + cell["first_name"] + " " + cell["last_name"] + " " + cell["email"]);
            }

            return RedirectToAction("Index");
        }
    }
}
