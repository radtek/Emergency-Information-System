using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyInformationSystem.Controllers
{
    public class GeneralInfosController : Controller
    {
        [ChildActionOnly]
        public PartialViewResult RelatedIndex(Guid id)
        {
            var targetV = new Models.ViewModels.GeneralInfos.RelatedIndex.RelatedIndex(id);

            return PartialView(targetV);
        }





        public ActionResult Create(Guid roomId)
        {
            var targetV = new Models.ViewModels.GeneralInfos.Create.Create();
            targetV.RoomId = roomId;

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind()]Models.ViewModels.GeneralInfos.Create.Create targetV)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Create2", new { targetV.OutPatientNumber, targetV.RoomId });
            }

            return View(targetV);
        }

        public ActionResult Create2(string outPatientNumber, Guid roomId, Guid? preGeneralRoomInfoId)
        {
            var targetV = new Models.ViewModels.GeneralInfos.Create.Create2(outPatientNumber, roomId, preGeneralRoomInfoId);

            return View(targetV);
        }

        public ActionResult Create3(Guid JZID, Guid? preGeneralRoomInfoId, Guid roomId)
        {
            var db3 = new Models.Domains3.Entities.EiSDbContext();

            var room = db3.Rooms.Find(roomId);
            if (room == null)
                return HttpNotFound();

            var targetV = new Models.ViewModels.GeneralInfos.Create.Create3(JZID, preGeneralRoomInfoId, roomId);

            var target = targetV.GetReturn();

            db3.GeneralRoomInfos.Add(target);
            db3.SaveChanges();

            return RedirectToAction("Edit", room.ControllerName, new { id = target.GeneralRoomInfoId });
        }





        public ActionResult TransferRoom(Guid id)
        {
            var targetV = new Models.ViewModels.GeneralInfos.TransferRoom.TransferRoom(id);
            var targetW = new Models.ViewModels.GeneralInfos.TransferRoom.SelectionWorker(targetV);
            ViewBag.RoomId = targetW.Rooms;

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TransferRoom([Bind()]Models.ViewModels.GeneralInfos.TransferRoom.TransferRoom targetV)
        {
            if (ModelState.IsValid)
            {
                var db3 = new Models.Domains3.Entities.EiSDbContext();
                var target = db3.GeneralRoomInfos.Find(targetV.GeneralRoomInfoId);

                return RedirectToAction("Create2", new { target.OutPatientNumber, targetV.RoomId, preGeneralRoomInfoId = targetV.GeneralRoomInfoId });
            }

            var targetW = new Models.ViewModels.GeneralInfos.TransferRoom.SelectionWorker(targetV);
            ViewBag.RoomId = targetW.Rooms;

            return View(targetV);
        }





        [ChildActionOnly]
        public ActionResult Header(Guid id)
        {
            var targetV = new Models.ViewModels.GeneralInfos.Header.Header(id);

            return PartialView(targetV);
        }
    }
}