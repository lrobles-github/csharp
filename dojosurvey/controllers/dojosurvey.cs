using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojosurvey.Controllers
{
    public class dojosurveyController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");
        }


        [HttpPost]
        [Route("process")]
        public IActionResult process(string name, string location, string favorite_language, string comments)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.favorite_language = favorite_language;
            ViewBag.comments = comments;
            return View("result");
        }

    }
}