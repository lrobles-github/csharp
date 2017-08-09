using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace callingcard
{
    public class myCallingCardController : Controller
    {

        [HttpGet]
        [Route("")]
        public string index()
        {
            return "Enter name and favorite color in URL..."; 
        }

        [HttpGet]
        [Route("card/{f_name}/{l_name}/{age}/{fav_color}")]
        public JsonResult card(string f_name, string l_name, int age, string fav_color)
        {
            return Json(new {FirstName = f_name, LastName = l_name, age = age, FavoriteColor = fav_color}); 
        }

    }
}