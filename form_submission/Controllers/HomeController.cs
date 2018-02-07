using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using form_submission.Models;

namespace form_submission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("success_page")]
        public IActionResult Success()
        {
            return View();
        }


        [HttpPost]
        [Route("success")]
        public IActionResult Submit(User user)
        {   
            if(ModelState.IsValid)

            {   
                Console.WriteLine(ModelState.IsValid);
                 string query = $@"INSERT INTO users (first_name,last_name,age,email,password,created_at) 
                        VALUES('{user.first_name}','{user.last_name}','{user.age}','{user.email}','{user.password}',NOW())";
                 DbConnector.Execute(query);
                return View("Success",user);
            }
            else
            {
                Console.WriteLine("I am here");
                return RedirectToAction ("Index",user);
            }

           
            
        }

    }
}
