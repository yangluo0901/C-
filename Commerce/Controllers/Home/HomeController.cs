using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Commerce.Controllers
{
    public class HomeController : Controller
    {
        private CommerceContext _ccontext;
        public HomeController(CommerceContext ccontext)
        {
            _ccontext = ccontext;
        }
        [HttpGet("/user/home")]
         public IActionResult Home()
        {
            return View();
        }
        [HttpPost("register")]
        public IActionResult Register(RegLogModel model)
        {
            PasswordHasher<RegUser> hasher = new PasswordHasher<RegUser>();
            
            if (ModelState.IsValid)
            {
                model.reguser.password = hasher.HashPassword(model.reguser,model.reguser.password);
                Customer user = new Customer()
                {
                    first_name = model.reguser.first_name,
                    last_name = model.reguser.last_name,
                    email = model.reguser.email,
                    password = model.reguser.password
                };
                _ccontext.customers.Add(user);
                _ccontext.SaveChanges(); 
                TempData["reg"] = "Register successfully, please login !";  
                return RedirectToAction("Home");
            }
            
            return View("Home",model);
            
        }
        [HttpPost("login")]
        public IActionResult Login(RegLogModel model)
        {
            if (ModelState.IsValid)
            {
                var checkemail = _ccontext.customers.SingleOrDefault(c=>c.email==model.loguser.email);
                if (checkemail != null)
                {
                    PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
                    if(hasher.VerifyHashedPassword(model.loguser,checkemail.password,model.loguser.password)!=PasswordVerificationResult.Failed)
                    {
                        HttpContext.Session.SetInt32("loggin_id",checkemail.customer_id);
                        return RedirectToAction("Index","Dashboard");
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
