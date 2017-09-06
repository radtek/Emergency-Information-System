using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 留观室病例控制器。
    /// </summary>
    public class ObserveRoomInfosController : Controller
    {
        /// <summary>
        /// 一览。
        /// </summary>
        /// <param name="route">导航对象</param>
        public ActionResult Index([Bind()]Models.ViewModels.ObserveRoomInfos.Index.Route route)
        {
            var targetV = new Models.ViewModels.ObserveRoomInfos.Index.Index(route);
            var targetW = new Models.ViewModels.ObserveRoomInfos.Index.SelectionWorker(route);

            ViewBag.IsLeave = targetW.IsLeaves;

            return View(targetV);
        }

        /// <summary>
        /// 详情。
        /// </summary>
        /// <param name="id">留观室病例ID。</param>
        public ActionResult Details(Guid id)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            var target = db.ObserveRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            var targetV = new Models.ViewModels.ObserveRoomInfos.Details.Details(target);

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
        /// <param name="create">提交对象。</param>
        /// <remarks>跳转到Create2。</remarks>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind()]Models.ViewModels.ObserveRoomInfos.Create.Create create)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Create2", new { create.OutPatientNumber });
            }

            return View(create);
        }

        /// <summary>
        /// 新增2。
        /// </summary>
        /// <param name="outPatientNumber">卡号。</param>
        /// <remarks>定位接诊记录。</remarks>
        public ActionResult Create2(string outPatientNumber)
        {
            var targetV = new Models.ViewModels.ObserveRoomInfos.Create.Create2(outPatientNumber);

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
            var targetDump = db.ObserveRoomInfos.Where(c => c.JZID == JZID).FirstOrDefault();
            if (targetDump != null)
                return RedirectToAction("Details", new { id = targetDump.ObserveRoomInfoId });

            var targetV = new Models.ViewModels.ObserveRoomInfos.Create.Create3(JZID);

            //无抢救室记录时，跳转到下一步。
            if (targetV.ListRescueRoomInfos.Count() != 0)
                return View(targetV);
            else
                return RedirectToAction("Create4", new { JZID });
        }

        /// <summary>
        /// 新增4。
        /// </summary>
        /// <param name="JZID">门诊医师接诊记录ID。</param>
        /// <param name="previousRescueRoomInfoId">关联的抢救室病例ID。</param>
        /// <returns>表单。</returns>
        public ActionResult Create4(Guid JZID, int? previousRescueRoomInfoId)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            //查找是否已存在相同JZID的记录。若存在，则跳转到Details。
            var targetDump = db.ObserveRoomInfos.Where(c => c.JZID == JZID).FirstOrDefault();
            if (targetDump != null)
                return RedirectToAction("Details", new { id = targetDump.ObserveRoomInfoId });

            var targetV = new Models.ViewModels.ObserveRoomInfos.Create.Create4(JZID, previousRescueRoomInfoId);

            var target = targetV.GetReturn();

            if (targetV.PreviousRescueRoomInfoId != null)
            {
                var previousRescueRoomInfo = db.RescueRoomInfos.Find(targetV.PreviousRescueRoomInfoId);
                target.PreviousRescueRoomInfo = previousRescueRoomInfo;
            }

            db.ObserveRoomInfos.Add(target);
            db.SaveChanges();

            return RedirectToAction("Edit", new { id = target.ObserveRoomInfoId });
        }

        /// <summary>
        /// 编辑。
        /// </summary>
        /// <param name="id">留观室病例ID。</param>
        public ActionResult Edit(Guid id)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            var target = db.ObserveRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            var targetV = new Models.ViewModels.ObserveRoomInfos.Edit.Edit(target);
            var targetW = new Models.ViewModels.ObserveRoomInfos.Edit.SelectionWorker(targetV);

            ViewBag.BedId = targetW.Beds;
            ViewBag.InObserveRoomWayId = targetW.InObserveRoomWays;
            ViewBag.DestinationId = targetW.Destinations;
            ViewBag.DestinationFirstId = targetW.DestinationFirsts;
            ViewBag.DestinationSecondId = targetW.DestinationSeconds;
            ViewBag.TransferReasonId = targetW.TransferReasons;

            return View(targetV);
        }

        /// <summary>
        /// 编辑 执行。
        /// </summary>
        /// <param name="observeRoomInfo">提交实例。</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind()]Models.ViewModels.ObserveRoomInfos.Edit.Edit targetV)
        {
            if (ModelState.IsValid)
            {
                var db = new Models.Domains.Entities.EiSDbContext();

                var target = db.ObserveRoomInfos.Find(targetV.ObserveRoomInfoId);
                if (target == null)
                    return HttpNotFound();

                targetV.GetReturn(target);

                Models.BusinessModels.TrasenInformationConvertor.FromEmployeeNumberToName(target);

                db.SaveChanges();

                return RedirectToAction("Details", new { id = targetV.ObserveRoomInfoId });
            }

            var targetW = new Models.ViewModels.ObserveRoomInfos.Edit.SelectionWorker(targetV);

            ViewBag.BedId = targetW.Beds;
            ViewBag.InObserveRoomWayId = targetW.InObserveRoomWays;
            ViewBag.DestinationId = targetW.Destinations;
            ViewBag.DestinationFirstId = targetW.DestinationFirsts;
            ViewBag.DestinationSecondId = targetW.DestinationSeconds;
            ViewBag.TransferReasonId = targetW.TransferReasons;

            return View(targetV);
        }





        /// <summary>
        /// 眉栏。
        /// </summary>
        /// <param name="id">留观室病例ID。</param>
        public ActionResult Header(Guid id)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            var target = db.ObserveRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            var targetV = new Models.ViewModels.ObserveRoomInfos.Header.Header(target);

            return PartialView(targetV);
        }
    }
}