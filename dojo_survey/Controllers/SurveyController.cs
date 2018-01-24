using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace dojo_survey.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult index()
        {
            return View("index");
        }
        
        [HttpPost]
        [Route("result")]
        public IActionResult result(string name, string location, string language, string comment)
        {
            ViewBag.name=name;
            ViewBag.location=location;
            ViewBag.language=language;
            ViewBag.comment=comment;
            return View("result");
        }
    }
}