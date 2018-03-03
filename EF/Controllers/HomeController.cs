using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF.Models;

namespace EF.Controllers
{
    public class HomeController : Controller
    {
        private FirstContext _Context;
        
        public HomeController(FirstContext Context)
        {
            _Context = Context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.users = _Context.Users;
            return View();
        }

        
    }
}
