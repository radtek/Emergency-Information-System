using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 创伤复苏单元。
    /// </summary>
    public class ResuscitateRoomInfosController : Controller
    {
        public ActionResult Index([Bind()]Models.ViewModels.ResuscitateRoomInfos.Index.Route route)
        {
            var targetV = new Models.ViewModels.ResuscitateRoomInfos.Index.Index(route);
            var targetW = new Models.ViewModels.ResuscitateRoomInfos.Index.SelectionWorker(route);

            ViewBag.GreenPathCategoryId = targetW.GreenPathCategories;
            ViewBag.InRoomWayId = targetW.InRoomWays;
            ViewBag.DestinationId = targetW.Destinations;
            ViewBag.IsRescue = targetW.IsRescues;
            ViewBag.IsLeave = targetW.IsLeaves;

            return View(targetV);
        }

        public ActionResult Details(Guid id)
        {
            var targetV = new Models.ViewModels.ResuscitateRoomInfos.Details.Details(id);

            return View(targetV);
        }

        public ActionResult Edit(Guid id)
        {
            var targetV = new Models.ViewModels.ResuscitateRoomInfos.Edit.Edit(id);
            var targetW = new Models.ViewModels.ResuscitateRoomInfos.Edit.SelectionWorker(targetV);

            ViewBag.BedId = targetW.Beds;
            ViewBag.InRoomWayId = targetW.InRoomWays;
            ViewBag.GreenPathCategoryId = targetW.GreenPathCategories;
            ViewBag.RescueResultId = targetW.RescueResults;
            ViewBag.DestinationId = targetW.Destinations;
            ViewBag.CriticalLevelId = targetW.CriticalLevels;
            ViewBag.DestinationFirstId = targetW.DestinationFirsts;
            ViewBag.DestinationSecondId = targetW.DestinationSeconds;
            ViewBag.TransferReasonId = targetW.TransferReasons;

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind()]Models.ViewModels.ResuscitateRoomInfos.Edit.Edit targetV)
        {
            if (ModelState.IsValid)
            {
                var db3 = new Models.Domains3.Entities.EiSDbContext();

                var target = db3.GeneralRoomInfos.FirstOrDefault(c => c.GeneralRoomInfoId == targetV.GeneralRoomInfoId && c.Room.IsResuscitateRoom);
                if (target == null)
                    return HttpNotFound();

                targetV.GetReturn(target);

                Models.BusinessModels.TrasenInformationConvertor.FromEmployeeNumberToName(target);

                db3.SaveChanges();

                return RedirectToAction("Details", new { id = targetV.GeneralRoomInfoId });
            }

            var targetW = new Models.ViewModels.ResuscitateRoomInfos.Edit.SelectionWorker(targetV);
            ViewBag.BedId = targetW.Beds;
            ViewBag.InRoomWayId = targetW.InRoomWays;
            ViewBag.GreenPathCategoryId = targetW.GreenPathCategories;
            ViewBag.RescueResultId = targetW.RescueResults;
            ViewBag.DestinationId = targetW.Destinations;
            ViewBag.CriticalLevelId = targetW.CriticalLevels;
            ViewBag.DestinationFirstId = targetW.DestinationFirsts;
            ViewBag.DestinationSecondId = targetW.DestinationSeconds;
            ViewBag.TransferReasonId = targetW.TransferReasons;

            return View(targetV);
        }
    }
}