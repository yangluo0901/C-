using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using quote_dojo.Models;


namespace quote_dojo.Controllers

{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        [Route("add_page")]
        public IActionResult AddPage()
        {
            
            return View("Add");
        }
        [HttpPost]
        [Route("/add")]
        public IActionResult Add(User user)
        {
            string query = $@"INSERT INTO users (first_name, last_name, created_at, updated_at)
             VALUES ('{user.first_name}', '{user.last_name}',NOW(), NOW())";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("quote")]
        public IActionResult quote(User user, Quote quote)
        {
            
            List<Dictionary<string, object>> poster  = DbConnector.Query($"SELECT id FROM users WHERE first_name = '{user.first_name}'");
            int poster_id = (int)poster[0]["id"];
            Console.WriteLine(poster_id);
            string query = $@"INSERT INTO quotes (content, created_at, updated_at,users_id) VALUES ('{quote.content}', NOW(),NOW(), {poster_id})";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            string query = $@"SELECT users.id,first_name,last_name,content,quotes.created_at FROM quotes
                            JOIN users ON users.id = quotes.users_id";

            ViewBag.joined = DbConnector.Query(query);
            return View();
        }
    }
}
