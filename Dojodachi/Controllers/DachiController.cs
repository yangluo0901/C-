using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
namespace DojoDachi.Controllers
{
    public class DachiController : Controller{
        static Pet dojodachi;
        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            return RedirectToAction ("Index");
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            dojodachi =  new Pet();
            Console.WriteLine(dojodachi.status);
            ViewBag.fullness = dojodachi.fullness;
            ViewBag.happiness = dojodachi.happiness;
            ViewBag.energy = dojodachi.energy;
            ViewBag.meal = dojodachi.meal;
            ViewBag.status = dojodachi.status;
            return View();
        }

        [HttpGet]
        [Route("feed")]
        public JsonResult Feed()
        {   
           
            if (dojodachi.meal > 0){
                int increment =dojodachi.Feed();
                var context = new {
                    instance= dojodachi,
                    increment=increment,
                    status = dojodachi.status
                };
                
                return Json(context);
            }
            else
            {
                var context = new {
                    result = false,
                    error = "insufficient meal!",
                    status = dojodachi.status
                };
                
                return Json(context);
            }
        }
            
        [HttpGet]
        [Route("play")]
        public JsonResult Play()
        {
                
            if (dojodachi.energy >=5)
            {
                var context = new {
                    instance =dojodachi,
                    increment = dojodachi.Play(),
                    status = dojodachi.status
                };
                 return Json(context);
            }
            else
            {
                var context = new {
                    result = false,
                    error = "Insufficient energy!",
                    status = dojodachi.status
                };
                return Json(context);
            }
               
            
        }

        [HttpGet]
        [Route("/work")]
        public JsonResult Work()
        {
            if (dojodachi.energy >=5)
            {
                var context = new {
                    instance =dojodachi,
                    increment = dojodachi.Work(),
                    status = dojodachi.status
                };
                return Json(context);
            }
            else
            {
                 var context = new {
                    result = false,
                    error = "Insufficient energy!",
                    status = dojodachi.status
                };
                return Json(context);
            }
        }

        [HttpGet]
        [Route("/sleep")]
        public JsonResult Sleep()
        {
            if (dojodachi.energy >=5 && dojodachi.happiness >=5)
            {
                dojodachi.Sleep();
                var context = new {
                    instance =dojodachi,
                    status = dojodachi.status
                };
                ViewBag.status = dojodachi.status;
                return Json(context);
            }
            else
            {
                 var context = new {
                    error = "Insufficient fullness and happiness!",
                    status = dojodachi.status
                };
                ViewBag.status = dojodachi.status;
                return Json(context);
            }
        }
    }    
}