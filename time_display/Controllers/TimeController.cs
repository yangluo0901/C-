using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
namespace time_display.Controllers
{
    public class TimeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Time()
        {   
            DateTime currenttime = DateTime.Now;
            string str1 = currenttime.ToString("MMM dd, yyyy");
            string str2 = currenttime.ToString("hh:mm tt");
            ViewBag.str1 = str1;
            ViewBag.str2 = str2;
            return View("index");
        }
    }
}