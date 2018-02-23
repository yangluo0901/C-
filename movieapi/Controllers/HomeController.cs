using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movieapi.Models;

namespace movieapi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            string query = $@"SELECT * FROM  history ORDER BY created_at DESC";
            List<Dictionary<string,object>> result = DbConnector.Query(query);
            ViewBag.history = result;
            return View();
        }

        [HttpPost("search")]
        public IActionResult Search(string name)
        {

            Console.WriteLine("name is"+ name);
            Movie instance = new Movie();
            WebRequest.GetInfoForMovies(name, movie=>{
                instance=movie;
            }).Wait();
            Console.WriteLine(" API finished!");
            Console.WriteLine(instance.Name);

            string save_query = $@"INSERT INTO history (name,rate,released_date,created_at)
                                VALUES ('{instance.Name}','{instance.Rate}','{instance.Released_date}',NOW())";
            DbConnector.Execute(save_query);
            return RedirectToAction("Index");
        }
    }   
}
