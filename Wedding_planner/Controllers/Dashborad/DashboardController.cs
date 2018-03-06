using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wedding_planner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Wedding_planner.Controllers
{
   
    public class DashboardController : Controller
    {
        private WeddingContext _wcontext;
        private Person _loggedinuser{
            get{return _wcontext.users.SingleOrDefault(u=>u.user_id == HttpContext.Session.GetInt32("loggin_id"));}
        }
        public DashboardController(WeddingContext wcontext)
        {
            _wcontext = wcontext;
        }
        [HttpGet("Dashboard/{id}")]
        public IActionResult Dashboard(int id)
        {
            if (_loggedinuser != null)
            {
                ViewBag.loguser = _loggedinuser.first_name;
                Person user = _wcontext.users.SingleOrDefault(u=>u.user_id ==5);
                List<Wedding> weddings = _wcontext.weddings.Include(w=>w.holder)
                                                            .Include(w=>w.guests)
                                                                .ThenInclude(g=>g.attendantee).ToList();
                // var wedding = _wcontext.weddings.SingleOrDefault(w=>w.wedding_id == 1);
                ViewBag.logid = _loggedinuser.user_id;
                return View(weddings);
            }
            return RedirectToAction("Dashboard");
        }
    }
}