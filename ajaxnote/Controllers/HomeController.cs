using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ajaxnote.Models;

namespace ajaxnote.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            string query = $@"SELECT * FROM notes";
            List<Dictionary<string, object>> result = DbConnector.Query(query);
            ViewBag.notes = result;
            return View();
        }

        [HttpGet("/test")]
        public IActionResult Test()
        {
            return View("Test");
        }
    }
}
