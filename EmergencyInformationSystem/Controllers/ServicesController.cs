using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Controllers
{
    public class ServicesController : Controller
    {
        public JsonResult GetInRescueRoomWay(int id)
        {
            var db = new EiSDbContext();

            var target = db.InRescueRoomWays.Find(id);

            return Json(target);
        }

        public JsonResult GetInObserveRoomWay(int id)
        {
            var db = new EiSDbContext();

            var target = db.InObserveRoomWays.Find(id);

            return Json(target);
        }

        public JsonResult GetGreenPathCategory(int id)
        {
            var db = new EiSDbContext();

            var target = db.GreenPathCategories.Find(id);

            return Json(target);
        }

        public JsonResult GetDestination(int id)
        {
            var db = new EiSDbContext();

            var target = db.Destinations.Find(id);

            return Json(target);
        }
    }
}