using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace portfolio.Controllers
{
    public class FirstController : Controller{
        [HttpGet]
        [Route("home")]
        public IActionResult Home()
        {
            return View("home");
        }
        [HttpGet]
        [Route("products")]
        public IActionResult Products()
        {
            return View("products");
        }
        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            return View("contact");
        }
    }
}