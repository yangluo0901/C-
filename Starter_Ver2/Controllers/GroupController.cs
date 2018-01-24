using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }
        [Route("groups")]
        public JsonResult All_Groups()
        {
            return Json(allGroups);
        }
        [Route("groups/name/{groupname}")]
        public JsonResult Groups(string groupname)
        {
            List<Group> groups = allGroups.Where(entry=> entry.GroupName ==groupname).ToList();
            return Json(groups);
        }
        [Route("groups/groupid/{groupid}")]
        public JsonResult Groups(int groupid)
        {
            List<Group> groups = allGroups.Where(entry=> entry. Id ==groupid).ToList();
            return Json(groups);
        }


    }
}