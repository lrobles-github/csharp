using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RandomPasscode.Controllers
{
    public class RandomPasscodeController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? count = HttpContext.Session.GetInt32("count");

                count += 1;
                System.Console.WriteLine("adding one");

            string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string passcode = "";
            Random Rand = new Random();

            for (int i = 0; i < 14; i++)
            {
                passcode = passcode + allowedChars[Rand.Next(0, allowedChars.Length)];
                System.Console.WriteLine(passcode);

            }

            ViewBag.passcode = passcode;
            System.Console.WriteLine(ViewBag.passcode);
            ViewBag.count = count;
            System.Console.WriteLine(ViewBag.count);
            HttpContext.Session.SetInt32("count", (int)count);

            return View("index");

        }
    }

}