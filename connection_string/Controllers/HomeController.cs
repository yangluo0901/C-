using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using connection_string.Models;
using Microsoft.Extensions.Options;

namespace connection_string.Controllers
{
    public class HomeController : Controller
    {
        private DbConnector _dbconnector;
        private UserFactory _userFactory;
        public HomeController(DbConnector dbconnector , UserFactory userFactory)
        {
            _dbconnector = dbconnector;
            _userFactory = userFactory;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            
            var userDapper = _userFactory.GetUsers();
            ViewBag.results = userDapper;
            return View();
        }

        [HttpGet("/getbyid/{id}")]
        public IActionResult GetUserId(int id)
        {
            
            var userDapper = _userFactory.GetUserById(id); // Good thing is you can get an object instead just List<Dictionary<string,object>>!!!
            ViewBag.results = userDapper;
            return View("Index",userDapper);
        }

        [HttpPost("/register")]
        public IActionResult Register(User user)
        {
            if(!_userFactory.EmailIfExist(user))
            {
                ModelState.AddModelError("email","This e-mail has already exist !");
            }
            if(ModelState.IsValid)
            {
                _userFactory.CreateUser(user);
            }
            
            Console.WriteLine("i am here");
            return View("Index",user);
        }
    }
        
}
