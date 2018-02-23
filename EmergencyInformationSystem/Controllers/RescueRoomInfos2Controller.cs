﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 抢救室。
    /// </summary>
    public class RescueRoomInfos2Controller : Controller
    {
        public ActionResult Index([Bind()]Models.ViewModels.RescueRoomInfos2.Index.Route route)
        {
            var targetV = new Models.ViewModels.RescueRoomInfos2.Index.Index(route);
            var targetW = new Models.ViewModels.RescueRoomInfos2.Index.SelectionWorker(route);

            ViewBag.GreenPathCategoryId = targetW.GreenPathCategories;
            ViewBag.InRoomWayId = targetW.InRoomWays;
            ViewBag.DestinationId = targetW.Destinations;
            ViewBag.IsRescue = targetW.IsRescues;
            ViewBag.IsLeave = targetW.IsLeaves;

            return View(targetV);
        }

        public ActionResult Details(Guid id)
        {
            var targetV = new Models.ViewModels.RescueRoomInfos2.Details.Details(id);

            return View(targetV);
        }

        public ActionResult Edit(Guid id)
        {
            var targetV = new Models.ViewModels.RescueRoomInfos2.Edit.Edit(id);
            var targetW = new Models.ViewModels.RescueRoomInfos2.Edit.SelectionWorker(targetV);

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
        public ActionResult Edit([Bind()]Models.ViewModels.RescueRoomInfos2.Edit.Edit targetV)
        {
            if (ModelState.IsValid)
            {
                var db3 = new Models.Domains3.Entities.EiSDbContext();

                var target = db3.GeneralRoomInfos.FirstOrDefault(c => c.GeneralRoomInfoId == targetV.GeneralRoomInfoId && c.Room.IsRescueRoom);
                if (target == null)
                    return HttpNotFound();

                targetV.GetReturn(target);

                Models.BusinessModels.TrasenInformationConvertor.FromEmployeeNumberToName(target);

                db3.SaveChanges();

                return RedirectToAction("Details", new { id = targetV.GeneralRoomInfoId });
            }

            var targetW = new Models.ViewModels.RescueRoomInfos2.Edit.SelectionWorker(targetV);
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





        public ActionResult TransferRoom(Guid id)
        {
            var db2 = new Models.Domains2.Entities.EiSDbContext();
            var target = db2.GeneralRoomInfos.FirstOrDefault(c => c.GeneralRoomInfoId == id && (c.Room.RoomCode & Models.Domains2.Entities.RoomCode.RescueRoom) == Models.Domains2.Entities.RoomCode.RescueRoom);

            if (target == null)
                return HttpNotFound(); //仅验证

            var targetV = new Models.ViewModels.RescueRoomInfos2.TransferRoom.TransferRoom(id);

            return View(targetV);
        }

        public ActionResult TransferRoom2(Guid id, Guid JZID)
        {
            var db2 = new Models.Domains2.Entities.EiSDbContext();
            var target = db2.GeneralRoomInfos.FirstOrDefault(c => c.GeneralRoomInfoId == id && (c.Room.RoomCode & Models.Domains2.Entities.RoomCode.RescueRoom) == Models.Domains2.Entities.RoomCode.RescueRoom);

            if (target == null)
                return HttpNotFound(); //仅验证

            var targetV = new Models.ViewModels.RescueRoomInfos2.TransferRoom.TransferRoom2();
            targetV.GeneralRoomInfoId = id;
            targetV.JZID = JZID;

            var targetW = new Models.ViewModels.RescueRoomInfos2.TransferRoom.SelectionWorker(targetV);
            ViewBag.RoomId = targetW.Rooms;

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TransferRoom2([Bind()]Models.ViewModels.RescueRoomInfos2.TransferRoom.TransferRoom2 targetV)
        {
            if (ModelState.IsValid)
            {
                var db2 = new Models.Domains2.Entities.EiSDbContext();

                var target = db2.GeneralRoomInfos.FirstOrDefault(c => c.GeneralRoomInfoId == targetV.GeneralRoomInfoId && (c.Room.RoomCode & Models.Domains2.Entities.RoomCode.RescueRoom) == Models.Domains2.Entities.RoomCode.RescueRoom);

                if (target == null)
                    return HttpNotFound(); //仅验证

                target = targetV.GetReturn();

                db2.GeneralRoomInfos.Add(target);
                db2.SaveChanges();

                return RedirectToAction("Edit", new { id = target.GeneralRoomInfoId });
            }

            var targetW = new Models.ViewModels.RescueRoomInfos2.TransferRoom.SelectionWorker(targetV);
            ViewBag.RoomId = targetW.Rooms;

            return View(targetV);
        }
    }
}