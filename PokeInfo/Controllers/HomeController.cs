using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PokeInfo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("pokeinfo/{id}")]
        public IActionResult Index(int id)
        {
            Pokemon instance = new Pokemon();
            WebRequest.GetPokeInfoAsync(id,pokemon =>{
                 instance = pokemon;
            }).Wait();
            ViewBag.pokemon = instance;
            return View();
        }
    }
}
