using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 重症监护单元室。
    /// </summary>
    public class IntensiveCareRoomInfosController : Controller
    {
        public ActionResult Index([Bind()]Models.ViewModels.IntensiveCareRoomInfos.Index.Route route)
        {
            var targetV = new Models.ViewModels.IntensiveCareRoomInfos.Index.Index(route);
            var targetW = new Models.ViewModels.IntensiveCareRoomInfos.Index.SelectionWorker(route);

            ViewBag.GreenPathCategoryId = targetW.GreenPathCategories;
            ViewBag.InRoomWayId = targetW.InRoomWays;
            ViewBag.DestinationId = targetW.Destinations;
            ViewBag.IsRescue = targetW.IsRescues;
            ViewBag.IsLeave = targetW.IsLeaves;

            return View(targetV);
        }
    }
}