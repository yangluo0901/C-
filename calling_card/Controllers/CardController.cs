using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace calling_card.Controllers
{
    public class CardController : Controller
    {
        [HttpGet]
        [Route("{first_name}/{last_name}/{age}/{color}")]
        public JsonResult Print(string first_name, string last_name, int age, string color)
        {
            var printout = new {
                first_name = first_name,
                last_name = last_name,
                age = age,
                color = color 
            };
            return Json(printout);
        }
    }
}