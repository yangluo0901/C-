using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ajaxnote.Models;

namespace ajaxnote.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            string query = $@"SELECT * FROM notes";
            List<Dictionary<string, object>> result = DbConnector.Query(query);
            ViewBag.notes = result;
            return View();
        }

        [HttpPost("addnote")]
        public IActionResult AddNote(AddNote Note)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("I am here");
                string add_query = $@"INSERT INTO notes (note,created_at,updated_at) 
                        VALUES ('{Note.title}',NOW(),NOW())";
                DbConnector.Execute(add_query);
                return RedirectToAction("Index");
            }
            return View("Index",Note);
            
        }

        
        [HttpPost("updatenote")]
        public IActionResult UpdateNote(UpdateNote Note)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("I am here");
                string update_query = $@"UPDATE notes SET description='{Note.description}', updated_at=Now()
                                        WHERE  id = '{Note.id}'";
                DbConnector.Execute(update_query);
                return RedirectToAction("Index");
            }
            return View("Index",Note);
            
        }

         
        [HttpPost("delete/{noteid}")]
        public IActionResult Delete(int noteid)
        {   
            Console.WriteLine(noteid);
            string validate_query = $@"SELECT id FROM notes where id = {noteid}";
            List<Dictionary<string,object>> result = DbConnector.Query(validate_query);
            Console.WriteLine("deleting...");
            
            if (result.Count != 0)
            {
                string delete_query = $@"DELETE FROM notes
                                        WHERE  id = '{noteid}'";
                DbConnector.Execute(delete_query);
                
            }
            else{
                ViewBag.errormessage = "This note does not exist !";
            }
            return RedirectToAction("Index");
        }
    }
}
