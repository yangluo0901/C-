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
        public IActionResult Register(User user)
        {
            if( ModelState.IsValid)
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                string hashed = hasher.HashPassword(user,user.password);
                string reg_query = $@"INSET INTO users ( first_name, last_name, email, password, created_at) 
                VALUES ('{user.first_name}','{user.last_name}','{user.email}','{hashed}',NOW())";
                DbConnector.Execute(reg_query);
                TempData["success"]="Registered, please log in !";
                return RedirectToAction("Index");
            }
            
            return View("Index", user);
        }

        [HttpPost("/login")]
        public IActionResult Login(User user)
        {
            string log_query = $@"SELECT password FROM users WHERE email = '{user.email}'";
            List<Dictionary<string,object>> result = DbConnector.Query(log_query);
            if(result.Count() != 0)
            {
                string password = result[0]["password"].ToString();
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                if(hasher.VerifyHashedPassword(user,password,user.password) == 0)
                {
                    return RedirectToAction("Wall");
                }else
                {
                    ModelState.AddModelError("password","Wrong password!");
                }
            }else
            {
                ModelState.AddModelError("email","User does not exist !");
            }

            return View("Index", user);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
