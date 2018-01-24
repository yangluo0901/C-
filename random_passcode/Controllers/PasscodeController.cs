using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
namespace random_passcode.Controllers
{
    public class PasscodeController : Controller{
        static int count;
        [HttpGet]
        [Route("")]
        public IActionResult index(int count , string passcode)
        {
            ViewBag.count = count;
            ViewBag.passcode = passcode;
            return View("index");
        }
        [HttpGet]
        [Route("generate")]
        public IActionResult generate()
        {
            count+=1;
            Random rand = new Random();
            string passcode = "";
            for ( int i = 0 ; i < 14; i++)
            {   
                int letter = rand.Next(0,2);
                
                if ( letter ==0 ){
                    string temp = rand.Next(0,10).ToString();
                    passcode = passcode.Insert(i,temp);
                }
                else
                {   
                    char temp =(char)('a'+rand.Next(0,25));
                    string temp1 = temp.ToString();
                    passcode = passcode = passcode.Insert(i,temp1);
                }
            }
            Console.WriteLine(passcode);
            return RedirectToAction("index", new { count = count, passcode = passcode});
        }
    }
}