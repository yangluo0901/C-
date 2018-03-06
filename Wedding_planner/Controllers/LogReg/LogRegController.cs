using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wedding_planner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Wedding_planner.Controllers
{
   
    public class LogRegController : Controller
    {
        private WeddingContext _wcontext;
        public LogRegController(WeddingContext wcontext)
        {
            _wcontext = wcontext;
        }
        [HttpGet("")]
        public IActionResult Home()
        {
            return View();
        }
        [HttpPost("register")]
        public IActionResult Register(LogRegModel model)
        {
            PasswordHasher<RegUser> hasher = new PasswordHasher<RegUser>();
            
            if (ModelState.IsValid)
            {
                model.newuser.password = hasher.HashPassword(model.newuser,model.newuser.password);
                Person user = new Person()
                {
                    first_name = model.newuser.first_name,
                    last_name = model.newuser.last_name,
                    email = model.newuser.email,
                    password = model.newuser.password
                };
                _wcontext.users.Add(user);
                _wcontext.SaveChanges(); 
                TempData["reg"] = "Register successfully, please login !";  
                return RedirectToAction("Home");
            }
            
            return View("Home",model);
            
        }
        [HttpPost("login")]
        public IActionResult Login(LogRegModel model)
        {
            if (ModelState.IsValid)
            {
                var checkemail = _wcontext.users.SingleOrDefault(u=>u.email==model.loguser.email);
                if (checkemail != null)
                {
                    PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
                    if(hasher.VerifyHashedPassword(model.loguser,checkemail.password,model.loguser.password)!=PasswordVerificationResult.Failed)
                    {
                        HttpContext.Session.SetInt32("loggin_id",checkemail.user_id);
                        return RedirectToAction("Dashboard","Dashboard",new {id = checkemail.user_id});
                    }
                    else{
                        ModelState.AddModelError("password","Wrong Password !");
                    }

                }
                else
                {
                    ModelState.AddModelError("email","Email does not exist!");
                    
                }
            }
            return View("Home",model);
        }       
        
    }
}
