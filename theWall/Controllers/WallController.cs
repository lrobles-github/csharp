using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using theWall.Models;

namespace theWall.Controllers
{
    public class WallController : Controller
    {

        private readonly DbConnector _dbConnector;

        public WallController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("wall")]
        public IActionResult wall()
        {

            ViewBag.Messages = new List<object>();
            ViewBag.Comments = new List<object>();

            List<Dictionary<string, object>> AllMessages = _dbConnector.Query("SELECT messages.id, message, DATE_FORMAT(messages.created_at, '%M %D, %Y') AS date, CONCAT(firstname, ' ', lastname) AS name FROM messages JOIN users ON messages.user_id = users.id ORDER BY messages.created_at DESC");
            
            List<Dictionary<string, object>> AllComments = _dbConnector.Query("SELECT comment, messages.id AS msgid, DATE_FORMAT(comments.created_at, '%M %D, %Y') AS date, CONCAT(users.firstname, ' ', users.lastname) AS name FROM comments JOIN users ON comments.user_id = users.id JOIN messages ON comments.message_id = messages.id ORDER BY comments.created_at");

/* Trying out something new*/


        //     var AllMessages = _dbConnector.Query("SELECT messages.id, message, DATE_FORMAT(messages.created_at, '%M %D, %Y') AS date, CONCAT(firstname, ' ', lastname) AS name FROM messages JOIN users ON messages.user_id = users.id ORDER BY messages.created_at DESC");
            
        //     var AllComments = _dbConnector.Query("SELECT comment, messages.id AS msgid, DATE_FORMAT(comments.created_at, '%M %D, %Y') AS date, CONCAT(users.firstname, ' ', users.lastname) AS name FROM comments JOIN users ON comments.user_id = users.id JOIN messages ON comments.message_id = messages.id ORDER BY comments.created_at");

        //    ViewBundle MessageCommentBundle = new ViewBundle { MessageModel = AllMessages, CommentModels = AllComments; }




/********************************** */

            ViewBag.Messages = AllMessages;
            ViewBag.Comments = AllComments;

            ViewBag.id = HttpContext.Session.GetInt32("userid");

            System.Console.WriteLine("################# In wall controller");

            if (HttpContext.Session.GetInt32("LoggedIn") != 1)
            {
                System.Console.WriteLine("################# NOT LOGGED IN... In wall controller IF statement, returning view-index...");
                return View("index");
            }
            else
            {
                System.Console.WriteLine("############## in wall");
                return View("wall");
            }
        }

        [HttpPost]
        [Route("post")]
        public IActionResult Post(string message)
        {

            System.Console.WriteLine("############ in message post controller method...");

            if (message != null)
            {
                _dbConnector.Execute("INSERT INTO messages (user_id, message, created_at) VALUES ('" + HttpContext.Session.GetInt32("userid") + "', '" + message + "', NOW())");
            }

            return RedirectToAction("wall");
        }


        [HttpPost]
        [Route("comment/{messageid}")]
        public IActionResult Comment(int messageid, string comment)
        {
            System.Console.WriteLine("############ in comment post controller method...");
            System.Console.WriteLine("############# comment is: " + comment);

            if (comment != null)
            {
                _dbConnector.Execute("INSERT INTO comments (user_id, message_id, comment, created_at) VALUES ('" + HttpContext.Session.GetInt32("userid") + "', '" + messageid + "', '" + comment + "', NOW())");
            }

            return RedirectToAction("wall");
        }



    }
}