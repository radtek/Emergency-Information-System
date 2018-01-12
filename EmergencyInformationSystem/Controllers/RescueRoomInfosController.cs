using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 抢救室病例控制器。
    /// </summary>
    public class RescueRoomInfosController : Controller
    {
        /// <summary>
        /// 一览。
        /// </summary>
        /// <param name="route">导航对象</param>
        public ActionResult Index([Bind()]Models.ViewModels.RescueRoomInfos.Index.Route route)
        {
            var targetV = new Models.ViewModels.RescueRoomInfos.Index.Index(route);
            var targetW = new Models.ViewModels.RescueRoomInfos.Index.SelectionWorker(route);

            ViewBag.GreenPathCategoryId = targetW.GreenPathCategories;
            ViewBag.InRescueRoomWayId = targetW.InRescueRoomWays;
            ViewBag.DestinationId = targetW.Destinations;
            ViewBag.IsRescue = targetW.IsRescues;
            ViewBag.IsLeave = targetW.IsLeaves;

            return View(targetV);
        }

        /// <summary>
        /// 详情。
        /// </summary>
        /// <param name="id">抢救室病例ID。</param>
        public ActionResult Details(Guid id)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            var target = db.RescueRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            var targetV = new Models.ViewModels.RescueRoomInfos.Details.Details(target);

            return View(targetV);
        }

        /// <summary>
        /// 新增1。
        /// </summary>
        /// <remarks>定位病人。</remarks>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 新增1 执行。
        /// </summary>
        /// <param name="targetV">提交对象。</param>
        /// <remarks>跳转到Create2。</remarks>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind()]Models.ViewModels.RescueRoomInfos.Create.Create targetV)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Create2", new { targetV.OutPatientNumber });
            }

            return View(targetV);
        }

        /// <summary>
        /// 新增2。
        /// </summary>
        /// <param name="outPatientNumber">卡号。</param>
        /// <remarks>定位接诊记录。</remarks>
        public ActionResult Create2(string outPatientNumber)
        {
            var targetV = new Models.ViewModels.RescueRoomInfos.Create.Create2(outPatientNumber);

            return View(targetV);
        }

        /// <summary>
        /// 新增3。
        /// </summary>
        /// <param name="JZID">门诊医师接诊记录ID。</param>
        public ActionResult Create3(Guid JZID)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            //查找是否已存在相同JZID的记录。若存在，则跳转到Details。
            var targetDump = db.RescueRoomInfos.Where(c => c.JZID == JZID).FirstOrDefault();
            if (targetDump != null)
                return RedirectToAction("Details", new { id = targetDump.RescueRoomInfoId });

            var targetV = new Models.ViewModels.RescueRoomInfos.Create.Create3(JZID);

            //无留观室记录时，跳转到下一步。
            if (targetV.ListObserveRoomInfos.Count() != 0)
                return View(targetV);
            else
                return RedirectToAction("Create4", new { JZID });
        }

        /// <summary>
        /// 新增4。
        /// </summary>
        /// <param name="JZID">门诊医师接诊记录ID。</param>
        /// <param name="previousObserveRoomInfoId">关联的留观室病例ID。</param>
        /// <returns>表单。</returns>
        public ActionResult Create4(Guid JZID, Guid? previousObserveRoomInfoId)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            //查找是否已存在相同JZID的记录。若存在，则跳转到Details。
            //**不需查找，已添加索引**
            //var targetDump = db.RescueRoomInfos.Where(c => c.JZID == JZID).FirstOrDefault();
            //if (targetDump != null)
            //    return RedirectToAction("Details", new { id = targetDump.RescueRoomInfoId });

            var targetV = new Models.ViewModels.RescueRoomInfos.Create.Create4(JZID, previousObserveRoomInfoId);

            var target = targetV.GetReturn();

            if (targetV.PreviousObserveRoomInfoId != null)
            {
                var previousObserveRoomInfo = db.ObserveRoomInfos.Find(targetV.PreviousObserveRoomInfoId);
                target.PreviousObserveRoomInfo = previousObserveRoomInfo;
            }

            db.RescueRoomInfos.Add(target);
            db.SaveChanges();

            return RedirectToAction("Edit", new { id = target.RescueRoomInfoId });
        }

        /// <summary>
        /// 编辑。
        /// </summary>
        /// <param name="id">抢救室病例ID。</param>
        public ActionResult Edit(Guid id)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            var target = db.RescueRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            var targetV = new Models.ViewModels.RescueRoomInfos.Edit.Edit(target);
            var targetW = new Models.ViewModels.RescueRoomInfos.Edit.SelectionWorker(targetV);

            ViewBag.BedId = targetW.Beds;
            ViewBag.InRescueRoomWayId = targetW.InRescueRoomWays;
            ViewBag.GreenPathCategoryId = targetW.GreenPathCategories;
            ViewBag.RescueResultId = targetW.RescueResults;
            ViewBag.DestinationId = targetW.Destinations;
            ViewBag.CriticalLevelId = targetW.CriticalLevels;
            ViewBag.DestinationFirstId = targetW.DestinationFirsts;
            ViewBag.DestinationSecondId = targetW.DestinationSeconds;
            ViewBag.TransferReasonId = targetW.TransferReasons;

            return View(targetV);
        }

        /// <summary>
        /// 编辑 执行。
        /// </summary>
        /// <param name="targetV">提交实例。</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind()]Models.ViewModels.RescueRoomInfos.Edit.Edit targetV)
        {
            if (ModelState.IsValid)
            {
                var db = new Models.Domains.Entities.EiSDbContext();

                var target = db.RescueRoomInfos.Find(targetV.RescueRoomInfoId);
                if (target == null)
                    return HttpNotFound();

                targetV.GetReturn(target);

                Models.BusinessModels.TrasenInformationConvertor.FromEmployeeNumberToName(target);

                db.SaveChanges();

                return RedirectToAction("Details", new { id = targetV.RescueRoomInfoId });
            }

            var targetW = new Models.ViewModels.RescueRoomInfos.Edit.SelectionWorker(targetV);

            ViewBag.BedId = targetW.Beds;
            ViewBag.InRescueRoomWayId = targetW.InRescueRoomWays;
            ViewBag.GreenPathCategoryId = targetW.GreenPathCategories;
            ViewBag.RescueResultId = targetW.RescueResults;
            ViewBag.DestinationId = targetW.Destinations;
            ViewBag.CriticalLevelId = targetW.CriticalLevels;
            ViewBag.DestinationFirstId = targetW.DestinationFirsts;
            ViewBag.DestinationSecondId = targetW.DestinationSeconds;
            ViewBag.TransferReasonId = targetW.TransferReasons;

            return View(targetV);
        }





        /// <summary>
        /// 眉栏。
        /// </summary>
        /// <param name="id">抢救室病例ID。</param>
        public ActionResult Header(Guid id)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            var target = db.RescueRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            var targetV = new Models.ViewModels.RescueRoomInfos.Header.Header(target);

            return PartialView(targetV);
        }
    }
}