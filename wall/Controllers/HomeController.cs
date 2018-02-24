using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
namespace wall.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost("/register")]
        public IActionResult Register(RegUser user)
        {
            if( ModelState.IsValid)
            {
                PasswordHasher<RegUser> hasher = new PasswordHasher<RegUser>();
                string hashed = hasher.HashPassword(user,user.password);
                string reg_query = $@"INSERT INTO users (first_name, last_name, email, password, created_at)
                VALUES ('{user.first_name}','{user.last_name}','{user.email}','{hashed}',NOW())";
                DbConnector.Execute(reg_query);
                TempData["success"]="Registered, please log in !";
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        [HttpPost("/login")]
        public IActionResult Login(LoginUser user)
        {
            string log_query = $@"SELECT id,password,first_name FROM users WHERE email = '{user.loginemail}'";
            List<Dictionary<string,object>> result = DbConnector.Query(log_query);
            if (ModelState.IsValid)
            {
                if(result.Count() != 0)
            {
                string password = result[0]["password"].ToString();
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                if(hasher.VerifyHashedPassword(user,password,user.loginpassword) != PasswordVerificationResult.Failed)
                {
                    HttpContext.Session.SetInt32("log_id", (int)result[0]["id"]);
                    return RedirectToAction("Wall", new {user_id= result[0]["id"].ToString()});
                }else
                {
                    ViewBag.errormessage="Wrong password!";
                }
            }else
            {
                ViewBag.errormessage="User does not exist !";
            }
            }

            Console.WriteLine("not valid");
            return View("Index");
        }

        [HttpGet("wall/{user_id}")]
        public IActionResult Wall(int user_id)
        {
            if (HttpContext.Session.GetInt32("log_id") == null)
            {
                return RedirectToAction("Index");
            }
            string messages_query = $@"SELECT first_name, last_name, content, messages.id AS message_id, messages.created_at
                                From messages JOIN users ON users.id = messages.poster_id
                                ORDER BY messages.created_at DESC
                                ";
            string comments_query = $@"SELECT comments.message_id,comments.content, CONCAT(first_name,' ',last_name) AS name, comments.created_at
                                    FROM comments
                                    JOIN messages ON comments.message_id = messages.id
                                    JOIN users ON comments.poster_id = users.id";
            List<Dictionary<string,object>> messages = DbConnector.Query(messages_query);
            List<Dictionary<string,object>> comments = DbConnector.Query(comments_query);
            List<Dictionary<string,object>> log_name = DbConnector.Query($"SELECT first_name FROM users WHERE id = {user_id}");
            ViewBag.log_name = log_name[0]["first_name"];
            ViewBag.messages = messages;
            ViewBag.comments = comments;
            return View();
        }

        [HttpPost("add_message")]
        public IActionResult Message(Message message)
        {
            int ? log_id = HttpContext.Session.GetInt32("log_id");
            string message_execute = $@"INSERT INTO messages (content,created_at,poster_id) VALUES ('{message.content}',NOW(),{log_id})";
            DbConnector.Execute(message_execute);
            Console.WriteLine(log_id);
            return RedirectToAction("Wall", new {user_id = log_id.ToString()});
        }

        [HttpPost("add_comment")]
        public IActionResult Comment(Comment comment)
        {
            int ? log_id = HttpContext.Session.GetInt32("log_id");
            string comment_execute = $@"INSErT INTO comments (content,created_at,poster_id,message_id) VALUES ('{comment.content}',NOW(),{log_id},'{comment.message_id}')";
            DbConnector.Execute(comment_execute);
            return RedirectToAction("Wall",new {user_id = log_id});
        }

        [HttpGet("logout")]
        public IActionResult Logout()

        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
