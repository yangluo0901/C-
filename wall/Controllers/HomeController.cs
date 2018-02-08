using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wall.Models;
using Microsoft.AspNetCore.Identity;

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
            string log_query = $@"SELECT password FROM users WHERE email = '{user.email}'";
            List<Dictionary<string,object>> result = DbConnector.Query(log_query);
            if(result.Count() != 0)
            {
                string password = result[0]["password"].ToString();
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                Console.WriteLine(hasher.VerifyHashedPassword(user,password,user.password));
                if(hasher.VerifyHashedPassword(user,password,user.password) != PasswordVerificationResult.Failed)
                {
                    Console.WriteLine(" i am here");
                    return RedirectToAction("Wall");
                }else
                {
                    ViewBag.errormessage="Wrong password!";
                }
            }else
            {
                ViewBag.errormessage="User does not exist !";
            }
            Console.WriteLine("not valid");
            return View("Index");
        }

        [HttpGet("wall")]
        public IActionResult Wall()
        {

            string messages_query = $@"SELECT first_name, last_name, content, messages.id AS message_id, messages.created_at 
                                From messages JOIN users ON users.id = messages.user_id
                                ORDER BY messages.created_at DESC
                                ";
            string comments_query = $@"SELECT comments.message_id,comments.content, CONCAT(first_name,' ',last_name) AS name, comments.created_at
                                    FROM comments
                                    JOIN messages ON comments.message_id = messages.id
                                    JOIN users ON comments.user_id = users.id";
            List<Dictionary<string,object>> messages = DbConnector.Query(messages_query);
             List<Dictionary<string,object>> comments = DbConnector.Query(comments_query);
            ViewBag.messages = messages;
            ViewBag.comments = comments;
            return View();
        }

        [HttpPost("add_message")]
        public IActionResult Message(Message message)
        {
            string message_execute = $@"INSET INTO messages (content,created_at) VALUES ('{message.content}',NOW())";
            return RedirectToAction("Wall");
        }

        [HttpPost("add_comment")]
        public IActionResult Comment(Comment comment)
        {
            string message_execute = $@"INSET INTO comments (content,created_at) VALUES ('{comment.content}',NOW())";
            return RedirectToAction("Wall");
        }
    }
}
