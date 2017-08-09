using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace dojodachi.Controllers
{

    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {

            if (HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi") == null)
            {
                HttpContext.Session.SetObjectAsJson("Dojodachi", new Dojodachi());
            }

            ViewBag.Dojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
            ViewBag.GameStatus = "active";
            Dojodachi jsonDachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
            return View("index");
        }

        [HttpPost]
        [Route("game")]
        public IActionResult game(string move)
        {
            Dojodachi jsonDachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
            Random rand = new Random();
            ViewBag.GameStatus = "active";
            switch (move)
            {
                case "feed":
                    if (jsonDachi.meals > 0)
                    {
                        jsonDachi.meals -= 1;
                        if (rand.Next(0, 4) > 0)
                        {
                            jsonDachi.fullness += rand.Next(5, 11);
                            ViewBag.Image = "eat";
                            ViewBag.Message = "Dojodachi eating...";
                        }
                        else
                        {
                            ViewBag.Image = "sad";
                            ViewBag.Message = "Dojodachi sad...";
                        }
                    }
                    else
                    {
                        ViewBag.Image = "sad";
                        ViewBag.Message = "No food for Dojodachi...";
                    }
                    break;
                case "play":
                    if (jsonDachi.energy > 4)
                    {
                        jsonDachi.energy -= 5;
                        if (rand.Next(0, 4) > 0)
                        {
                            jsonDachi.happiness += rand.Next(5, 11);
                            ViewBag.Image = "play";
                            ViewBag.Message = "Dojodachi playing...";
                        }
                        else
                        {
                            ViewBag.Image = "sad";
                            ViewBag.Message = "Dojodachi sad...";
                        }
                    }
                    else
                    {
                        ViewBag.Image = "sad";
                        ViewBag.Message = "No energy...";
                    }

                    break;
                case "work":
                    if (jsonDachi.energy > 4)
                    {
                        jsonDachi.energy -= 5;
                        jsonDachi.meals += rand.Next(1, 4);
                        ViewBag.Message = "You work to feed Dojodachi...";
                    }
                    else
                    {
                        ViewBag.Image = "sad";
                        ViewBag.Message = "No energy left...";
                    }
                    break;
                case "sleep":
                    jsonDachi.energy += 15;
                    jsonDachi.fullness -= 5;
                    jsonDachi.happiness -= 5;
                    ViewBag.Message = "Dojodachi sleeping...";
                    ViewBag.Image = "sleep";
                    break;
                default:
                    ViewBag.Image = "";
                    ViewBag.Message = "Something went wrong...";
                    break;

            }
            if (jsonDachi.fullness < 1 || jsonDachi.happiness < 1)
            {
                ViewBag.Image = "dead";
                ViewBag.Message = "Dojodachi dead...";
                ViewBag.GameStatus = "over";
            }
            else if (jsonDachi.fullness > 99 && jsonDachi.happiness > 99)
            {
                ViewBag.Image = "play";
                ViewBag.Message = "You win!";
                ViewBag.GameStatus = "over";
            }
            HttpContext.Session.SetObjectAsJson("Dojodachi", jsonDachi);
            ViewBag.Dojodachi = jsonDachi;
            return View("Index");
        }

        [HttpPost]
        [Route("reset")]
        public IActionResult resetDojo()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }

    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}


