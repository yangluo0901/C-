using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using login_and_registration.Models;

namespace login_and_registration.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                string reg_query = $@"INSERT INTO users (first_name, last_name, email, password, created_at)
                         VALUES ('{user.first_name}','{user.last_name}','{user.email}','{user.password}',NOW())";
                         DbConnector.Execute(reg_query);
                Console.WriteLine("registerred !!!");
                ViewBag.message = "Registerred, please login !";
                return View("Index");
            }else
            {
                return View("Index",user);
            }

        }
        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            string query = $"SELECT password FROM users WHERE email = '{user.email}' ";
            List<Dictionary<string,object>> result =  DbConnector.Query(query);
            Console.WriteLine(result[0]["password"].ToString());
            if (result.Count() != 0)
            {
                if(result[0]["password"].ToString() == user.password)
                {
                    Console.WriteLine("password is correct!");
                    return View("Success");
                }
            }else
            {
                ViewBag.message = "This user does not exist !";

            }

            return View("Index");
        }
        
        
    }
}
