using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restauranter.Models;

namespace restauranter.Controllers
{
    public class HomeController : Controller
    {
        private FirstContext _Context;
        
        public HomeController(FirstContext Context)
        {
            _Context = Context;
        }
        [HttpGet("")]
        public IActionResult Index(View view)
        {
            
            return View();
        }
        [HttpPost("/add_review")]
        public IActionResult Add(View view)
        {
            _Context.views.Add(view);
            _Context.SaveChanges();
            List<View> views = _Context.views.ToList();
            return View("Show" ,views);
        }

        
    }
}
