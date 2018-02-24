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
        public HomeController(DbConnector dbconnector)
        {
            _dbconnector = dbconnector;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.results = _dbconnector.Query("SELECT * From users");
            return View();
        }
    }
        
}
