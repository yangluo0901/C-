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
                                                            .Include(w => w.guests)
                                                                .ThenInclude(g => g.attendantee).ToList();
                // var wedding = _wcontext.weddings.SingleOrDefault(w=>w.wedding_id == 1);
                ViewBag.logid = _loggedinuser.user_id;
                return View(weddings);
            }
            return RedirectToAction("Dashboard");
        }
        [HttpGet("rsvp/{wedding_id}")]
        public IActionResult RSVP(int wedding_id)
        {
            if(_loggedinuser != null)
            {
                Join join = new Join()
                {
                    wedding_id = wedding_id,
                    joiner_id  = _loggedinuser.user_id
                };
                _wcontext.Add(join);
                _wcontext.SaveChanges();
                return RedirectToAction("Dashboard", new{ id = _loggedinuser.user_id});
            }
            return RedirectToAction("Home","LogReg");
        }
        [HttpGet("unrsvp/{wedding_id}")]
        public IActionResult UNRSVP(int wedding_id)
        {
            if(_loggedinuser != null)
            {
                Join join = _wcontext.joins.SingleOrDefault(j=>(j.wedding_id == wedding_id)&&(j.join_id==_loggedinuser.user_id));

                _wcontext.Remove(join);
                _wcontext.SaveChanges();
                return RedirectToAction("Dashboard", new{ id = _loggedinuser.user_id});
            }
            return RedirectToAction("Home","LogReg");
        }
        [HttpGet("new_wedding")]
        public IActionResult NewWedding()
        {
            ViewBag.logid = _loggedinuser.user_id;
            return View();
        }
        [HttpPost("/create_wedding")]
        public IActionResult CreateWedding(Wedding wedding)
        {
            if(_loggedinuser != null)
            {
                if ( ModelState.IsValid)
                {
                    wedding.holderid = _loggedinuser.user_id;
                    _wcontext.Add(wedding);
                    _wcontext.SaveChanges();
                    return RedirectToAction("Wedding",new{ wedding_id = _loggedinuser.user_id});
                }
            }
            return RedirectToAction("NewWedding", wedding);
        }
        [HttpGet("wedding/{wedding_id}")]
        public IActionResult Wedding( int wedding_id)
        {
            Console.WriteLine(" i am insdie wedding function");
            var wedding = _wcontext.weddings.Include(w => w.guests)
                                            .SingleOrDefault(w => w.wedding_id == wedding_id);
            ViewBag.logid = _loggedinuser.user_id;
            Console.WriteLine("i am going to pass wedding to cshtml ");
            Console.WriteLine(wedding);
            return View(wedding);
        }
        [HttpGet("user/{id}")]
        public IActionResult User(int id)
        {
            Person user = _wcontext.users.Include(u => u.joinweddings)
                                        .SingleOrDefault(u => u.user_id == id);
            ViewBag.logid = _loggedinuser.user_id;
            return View();
        }
    }
}