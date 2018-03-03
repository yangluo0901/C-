using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lost_In_Woods.Models;

namespace Lost_In_Woods.Controllers
{
    public class HomeController : Controller
    {
        private UserFactory _userFactory;
        private DbConnector _dbConnector;
        public HomeController(UserFactory userFactory, DbConnector dbConnector)
        {
            _userFactory = userFactory;
            _dbConnector = dbConnector;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Trail> trails = _userFactory.GetAll();
            ViewBag.trails =trails;
            return View();
        }

        [HttpPost("/add_trail")]
        public IActionResult Add(Trail trail)
        {
            if(ModelState.IsValid)
            {
                _userFactory.Add(trail);
            }
            Console.WriteLine("i am in side Add function!");
            return View("Index",trail);
        }

        [HttpGet("/trail/{id}")]
        public IActionResult Detail(int id)
        {
            Trail trail = _userFactory.GetTrailById(id);
            return View(trail);
        }
        
    }
}
