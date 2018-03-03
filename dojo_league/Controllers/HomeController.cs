using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dojo_league.Models;
using Microsoft.Extensions.Options;
using System.Data;
using MySql.Data.MySqlClient;

namespace dojo_league.Controllers
{
    public class HomeController : Controller
    {
        private DbConnector _db;
        private UserFactory _userFactory;
        public HomeController(DbConnector db,UserFactory userFactory)
        {
            _db = db;
            _userFactory = userFactory;
        }
        
        [HttpGet("/ninjas")]
        public IActionResult Ninjas()
        {
           ViewBag.ninjas =  _userFactory.GetNinjas();
            ViewBag.dojos = _userFactory.GetDojos();
            return View();
        }

       [HttpPost("/add_ninja")]
       public IActionResult AddNinja(Ninja ninja)
       {
           if(ModelState.IsValid)
           {
               _userFactory.AddNinja(ninja);
               
           }
           ViewBag.ninjas =  _userFactory.GetNinjas();
            ViewBag.dojos = _userFactory.GetDojos();
           return View("Ninjas",ninja);
       }
        [HttpGet("/dojos")]
        public IActionResult Dojos()
        {
            ViewBag.dojos = _userFactory.GetDojos();
            return View();
        }
        [HttpPost("/add_dojo")]
        public IActionResult AddDojo(Dojo dojo)
        {
            if (ModelState.IsValid)
            {
                _userFactory.AddDojo(dojo);
            }
            ViewBag.dojos = _userFactory.GetDojos();
            return View("Dojos",dojo);
        }
        [HttpGet("/ninja/{ninja_id}")]
        public IActionResult Ninja(int ninja_id)
        {
            ViewBag.ninja = _userFactory.GetNinja(ninja_id);
            return View();
        }
        [HttpGet("/dojo/{dojo_id}")]
        public IActionResult Dojo(int dojo_id)
        {
            ViewBag.dojo = _userFactory.GetDojo(dojo_id);
            return View();
        }

    }
}
