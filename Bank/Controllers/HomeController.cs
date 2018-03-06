using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bank.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Bank.Controllers
{
    public class HomeController : Controller
    {
        private BankContext _bcontext;
        // private Person _loggineduser
        // {
        //     get{ return _bcontext.users.SingleOrDefault(u=> u.user_id == (int?)HttpContext.Session.GetInt32("log_id") );}
        // }
        public HomeController(BankContext bcontext)
        {
            _bcontext = bcontext;
            // Console.WriteLine($"loged user is {(int?)HttpContext.Session.GetInt32("log_id")}");
        }
        
        [HttpGet("")]
        public IActionResult Index()
        {   
            return View();
        }
        
        [HttpPost("create")]
        public IActionResult Create(VGPerson vuser)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<VGPerson> hasher = new PasswordHasher<VGPerson>();
                vuser.password = hasher.HashPassword(vuser,vuser.password);
                Person user = new Person
                {
                   
                    first_name = vuser.first_name,
                    last_name = vuser.last_name,
                    email = vuser.email,
                    password = vuser.password
                };
                _bcontext.users.Add(user);
                _bcontext.SaveChanges();
                return RedirectToAction("Login");
                
            }
            return View("Index",vuser);
        }
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("log_in")]
        public IActionResult Log(VLPerson vuser)
        {
            
            Console.WriteLine(ModelState.IsValid);
            if(ModelState.IsValid)
            {
                Person checkemail = _bcontext.users.SingleOrDefault(user =>user.email == vuser.email);
                if(checkemail != null)
                {
                    PasswordHasher<VLPerson> hasher = new PasswordHasher<VLPerson>();
                    if(hasher.VerifyHashedPassword(vuser,checkemail.password,vuser.password) != PasswordVerificationResult.Failed)
                    {
                         HttpContext.Session.SetInt32("log_id",checkemail.user_id);
                         return RedirectToAction("Account", new{id = checkemail.user_id});
                    }
                    else
                    {
                        ModelState.AddModelError("password","Wrong password !");
                        return View("Login",vuser);
                    }
                   
                }
                else{
                    ModelState.AddModelError("email","User does not exit !");
                    return View("Login",vuser);
                }

            }
            return View("Login",vuser);
        }
        [HttpGet("account/{id}")]
        public IActionResult Account(int id)
        {
            if (HttpContext.Session.GetInt32("log_id") != null)
            {
                AccountModel model = new AccountModel()
                {
                    user = _bcontext.users.Include(u=>u.actions).SingleOrDefault(user => user.user_id == id),
                   
                };
                
                return View(model);
            }
            
            return RedirectToAction("Index");
        }
        [HttpPost("account/action")]
        public IActionResult CreateAction(AccountModel model)
        {
            int loggineduserid = (int)HttpContext.Session.GetInt32("log_id");
            model.action.user_id = loggineduserid;
            _bcontext.actions.Add(model.action);
            Person updateuser = _bcontext.users.Include(u=>u.actions).SingleOrDefault(user => user.user_id == loggineduserid);
            updateuser.balance =  updateuser.balance + model.action.amount;
            _bcontext.SaveChanges();
            return RedirectToAction("Account", new{id = loggineduserid});
        }
        [HttpGet("/logout")]
        public IActionResult Logout(int id)
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
