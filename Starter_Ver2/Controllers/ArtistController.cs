using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson(); 
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }
        [HttpGet]
        [Route("all_artists")]
        public JsonResult All_Artists()
        {
            return Json(allArtists);
        }
        [HttpGet]
        [Route("artists/name/{name}")]
        public JsonResult Artists_name(string name)
        {
            List<Artist> artists = allArtists.Where(entry=> entry.ArtistName==name).ToList();
            return Json(artists);
        }
        [HttpGet]
        [Route("artists/realname/{realname}")]
        public JsonResult Artists_realname(string realname)
        {
            List<Artist> artists = allArtists.Where(entry=> entry.RealName==realname).ToList();
            return Json(artists);
        }
        [HttpGet]
        [Route("artists/hometown/{hometown}")]
        public JsonResult Artists_hometown(string hometown)
        {
            List<Artist> artists = allArtists.Where(entry=> entry.Hometown == hometown).ToList();
            return Json(artists);
        }
        [HttpGet]
        [Route("artists/groupid/{groupid}")]
        public JsonResult Artists_groupid(int groupid)
        {
            List<Artist> artists = allArtists.Where(entry=> entry.GroupId == groupid).ToList();
            return Json(artists);
        }
      
    }    

}