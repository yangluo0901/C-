using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers
{
    public class FirstController : Controller
    {
        [HttpGet]
        [Route("")]
        public JsonResult Print()
        {
            var AnonObject = new {
                                    FirstName = "Raz",
                                    LastName = "Aquato",
                                    Age = 10
                                };
            return Json(AnonObject);
        }  
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
     
}
