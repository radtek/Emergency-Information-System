using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 留观室。
    /// </summary>
    public class ObserveRoomInfos2Controller : Controller
    {
        public ActionResult Index([Bind()]Models.ViewModels.ObserveRoomInfos2.Index.Route route)
        {
            var targetV = new Models.ViewModels.ObserveRoomInfos2.Index.Index(route);
            var targetW = new Models.ViewModels.ObserveRoomInfos2.Index.SelectionWorker(route);

            ViewBag.InRoomWayId = targetW.InRoomWays;
            ViewBag.DestinationId = targetW.Destinations;
            ViewBag.IsLeave = targetW.IsLeaves;

            return View(targetV);
        }

        public ActionResult Details(Guid id)
        {
            var targetV = new Models.ViewModels.ObserveRoomInfos2.Details.Details(id);

            return View(targetV);
        }

        public ActionResult Edit(Guid id)
        {
            var targetV = new Models.ViewModels.ObserveRoomInfos2.Edit.Edit(id);
            var targetW = new Models.ViewModels.ObserveRoomInfos2.Edit.SelectionWorker(targetV);

            ViewBag.BedId = targetW.Beds;
            ViewBag.InRoomWayId = targetW.InRoomWays;
            ViewBag.DestinationId = targetW.Destinations;
            ViewBag.DestinationFirstId = targetW.DestinationFirsts;
            ViewBag.DestinationSecondId = targetW.DestinationSeconds;
            ViewBag.TransferReasonId = targetW.TransferReasons;

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind()]Models.ViewModels.ObserveRoomInfos2.Edit.Edit targetV)
        {
            if (ModelState.IsValid)
            {
                var db3 = new Models.Domains3.Entities.EiSDbContext();

                var target = db3.GeneralRoomInfos.FirstOrDefault(c => c.GeneralRoomInfoId == targetV.GeneralRoomInfoId && c.Room.IsObserveRoom);
                if (target == null)
                    return HttpNotFound();

                targetV.GetReturn(target);

                //Models.BusinessModels.TrasenInformationConvertor.FromEmployeeNumberToName(target);

                db3.SaveChanges();

                return RedirectToAction("Details", new { id = targetV.GeneralRoomInfoId });
            }

            var targetW = new Models.ViewModels.ObserveRoomInfos2.Edit.SelectionWorker(targetV);
            ViewBag.BedId = targetW.Beds;
            ViewBag.InRoomWayId = targetW.InRoomWays;
            ViewBag.DestinationId = targetW.Destinations;
            ViewBag.DestinationFirstId = targetW.DestinationFirsts;
            ViewBag.DestinationSecondId = targetW.DestinationSeconds;
            ViewBag.TransferReasonId = targetW.TransferReasons;

            return View(targetV);
        }
    }
}