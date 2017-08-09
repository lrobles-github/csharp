using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace portfolio.Controllers
{
    public class portfolioController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            return View("index");
        }

        [HttpGet]
        [Route("/projects")]
        public IActionResult Projects()
        {
            return View("projects");
        }

        [HttpGet]
        [Route("/contact")]
        public IActionResult Contact()
        {
            return View("contact");
        }
    }
}