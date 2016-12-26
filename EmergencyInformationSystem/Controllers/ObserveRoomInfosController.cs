using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EmergencyInformationSystem.Models.Domains.Entities;
using EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Index;
using EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Details;
using EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Create;
using EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Header;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 留观室病例控制器。
    /// </summary>
    public class ObserveRoomInfosController : Controller
    {
        /// <summary>
        /// 留观室病例。
        /// </summary>
        /// <param name="inDepartmentTimeStart">入室时间起点。</param>
        /// <param name="inDepartmentTimeEnd">入室时间结点。</param>
        /// <param name="outDepartmentTimeStart">离室时间起点。</param>
        /// <param name="outDepartmentTimeEnd">离室时间结点。</param>       
        /// <param name="isLeave">是否离室。</param>       
        /// <param name="patientName">患者姓名。</param>
        /// <param name="outPatientNumber">卡号。</param>
        /// <param name="page">页码。</param>
        /// <param name="perPage">每页项目数。</param>
        public ActionResult Index(DateTime? inDepartmentTimeStart, DateTime? inDepartmentTimeEnd, DateTime? outDepartmentTimeStart, DateTime? outDepartmentTimeEnd, bool? isLeave, string patientName, string outPatientNumber, int page = 1, int perPage = 20)
        {
            var targetV = new Index(inDepartmentTimeStart, inDepartmentTimeEnd, outDepartmentTimeStart, outDepartmentTimeEnd, isLeave, patientName, outPatientNumber, page, perPage);

            ViewBag.IsLeave = new SelectList(new List<SelectListItem>
            {
                new SelectListItem {Text="是",Value="true" },
                new SelectListItem {Text="否",Value="false" }
            }, "Value", "Text");

            return View(targetV);
        }

        /// <summary>
        /// 详情。
        /// </summary>
        /// <param name="id">留观室病例ID。</param>
        public ActionResult Details(Guid id)
        {
            var db = new EiSDbContext();

            var target = db.ObserveRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            var targetV = new Details(target);

            return View(targetV);
        }

        /// <summary>
        /// 新增1。
        /// </summary>
        /// <remarks>定位病人。</remarks>
        public ActionResult Create()
        {
            var target = new Create();

            return View(target);
        }

        /// <summary>
        /// 新增1 执行。
        /// </summary>
        /// <param name="create">提交对象。</param>
        /// <remarks>跳转到Create2。</remarks>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind()]Create create)
        {
            var dbTrasen = new TrasenLib.TrasenDbContext("TrasenConnection");

            if (!dbTrasen.YY_KDJB.Any(c => c.KH == create.OutPatientNumber))
                ModelState.AddModelError("outPatientNumber", "卡号不存在");

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
            var targetV = new Create2(outPatientNumber);

            return View(targetV);
        }

        /// <summary>
        /// 新增3。
        /// </summary>
        /// <param name="outPatientNumber">卡号。</param>
        /// <param name="JZID">门诊医师接诊记录ID。</param>
        /// <param name="GHXXID">挂号信息ID。</param>
        /// <param name="BRXXID">病人信息ID。</param>
        /// <param name="KDJID">卡登记ID。</param>
        public ActionResult Create3(string outPatientNumber, Guid JZID, Guid GHXXID, Guid BRXXID, Guid KDJID)
        {
            var db = new EiSDbContext();

            //查找是否已存在相同JZID的记录。若存在，则跳转到Details。
            var targetDump = db.ObserveRoomInfos.Where(c => c.JZID == JZID).FirstOrDefault();
            if (targetDump != null)
                return RedirectToAction("Details", new { id = targetDump.ObserveRoomInfoId });

            var targetV = new Create3(outPatientNumber, JZID, GHXXID, BRXXID, KDJID);

            //无抢救室记录时，跳转到下一步。
            if (targetV.ListRescueRoomInfos.Count() != 0)
                return View(targetV);
            else
                return RedirectToAction("Create4", new { outPatientNumber, JZID, GHXXID, BRXXID, KDJID });
        }

        /// <summary>
        /// 新增4。
        /// </summary>
        /// <param name="outPatientNumber">卡号。</param>
        /// <param name="JZID">门诊医师接诊记录ID。</param>
        /// <param name="GHXXID">挂号信息ID。</param>
        /// <param name="BRXXID">病人信息ID。</param>
        /// <param name="KDJID">卡登记ID。</param>
        /// <param name="previousRescueRoomInfoId">关联的抢救室病例ID。</param>
        public ActionResult Create4(string outPatientNumber, Guid JZID, Guid GHXXID, Guid BRXXID, Guid KDJID, int? previousRescueRoomInfoId)
        {
            var db = new EiSDbContext();

            //查找是否已存在相同JZID的记录。若存在，则跳转到Details。
            var targetDump = db.ObserveRoomInfos.Where(c => c.JZID == JZID).FirstOrDefault();
            if (targetDump != null)
                return RedirectToAction("Details", new { id = targetDump.ObserveRoomInfoId });

            var target = (new Create4()).GetObserveRoomInfo(outPatientNumber, JZID, GHXXID, BRXXID, KDJID);

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForObserveRoom), "BedId", "BedName");
            ViewBag.InObserveRoomWayId = new SelectList(db.InObserveRoomWays, "InObserveRoomWayId", "InObserveRoomWayName");
            ViewBag.DestinationId = new SelectList(db.Destinations.Where(c => c.IsUseForObserveRoom).OrderBy(c => c.Priority2), "DestinationId", "DestinationName");
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName");
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName");

            ViewBag.PreviousRescueRoomInfoId = previousRescueRoomInfoId;

            return View(target);
        }

        /// <summary>
        /// 新增4 执行。
        /// </summary>
        /// <param name="observeRoomInfo">提交实例。</param>
        /// <param name="previousRescueRoomInfoId">关联的抢救室病例ID。</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create4([Bind()]ObserveRoomInfo observeRoomInfo, int? previousRescueRoomInfoId)
        {
            var db = new EiSDbContext();

            //查找是否已存在相同JZID的记录。若存在，则跳转到Details。
            var targetDump = db.ObserveRoomInfos.Where(c => c.JZID == observeRoomInfo.JZID).FirstOrDefault();
            if (targetDump != null)
                return RedirectToAction("Details", new { id = targetDump.ObserveRoomInfoId });

            //1-入室时间不能晚于当前时间。
            if (observeRoomInfo.InDepartmentTime > DateTime.Now)
                ModelState.AddModelError("InDepartmentTime", "入室时间不能晚于当前时间。");
            //2-入室方式必填。
            if (db.InObserveRoomWays.Find(observeRoomInfo.InObserveRoomWayId).IsUseForEmpty)
                ModelState.AddModelError("InObserveRoomWayId", "不可为空。");
            //3-首诊护士必填。
            if (string.IsNullOrEmpty(observeRoomInfo.FirstNurseName))
                ModelState.AddModelError("FirstNurseName", "不可为空。");
            //4-入室方式为允许附加数据才可以有附加数据。
            //if (!db.InObserveRoomWays.Find(observeRoomInfo.InObserveRoomWayId).IsHasAdditionalInfo && !string.IsNullOrEmpty(observeRoomInfo.InObserveRoomWayRemarks))
            //    ModelState.AddModelError("InObserveRoomWayRemarks", "与入院方式不匹配。");
            //5-入室方式为允许附加数据，必须有具体名称。
            if (db.InObserveRoomWays.Find(observeRoomInfo.InObserveRoomWayId).IsHasAdditionalInfo && string.IsNullOrEmpty(observeRoomInfo.InObserveRoomWayRemarks))
                ModelState.AddModelError("InObserveRoomWayRemarks", "必须有具体名称。");
            //6-有预约首选科室，必须有预约首选时间。
            if (!db.Destinations.Find(observeRoomInfo.DestinationFirstId).IsUseForEmpty && !observeRoomInfo.DestinationFirstTime.HasValue)
                ModelState.AddModelError("DestinationFirstTime", "有预约首选科室时必填。");
            //7-预约首选时间不能早于入室时间。
            if (observeRoomInfo.DestinationFirstTime.HasValue && observeRoomInfo.DestinationFirstTime.Value < observeRoomInfo.InDepartmentTime)
                ModelState.AddModelError("DestinationFirstTime", "不能早于入室时间。");
            //8-有预约首选科室，必须有预约首选医师。
            if (!db.Destinations.Find(observeRoomInfo.DestinationFirstId).IsUseForEmpty && string.IsNullOrEmpty(observeRoomInfo.DestinationFirstContact))
                ModelState.AddModelError("DestinationFirstContact", "有预约首选科室时必填。");
            //9-有预约次选科室，必须有预约首选科室。
            if (!db.Destinations.Find(observeRoomInfo.DestinationSecondId).IsUseForEmpty && db.Destinations.Find(observeRoomInfo.DestinationFirstId).IsUseForEmpty)
                ModelState.AddModelError("DestinationSecondId", "必须先填写预约首选科室。");
            //10-有离室时间，必须有去向。
            //if (observeRoomInfo.IsLeave && db.Destinations.Find(observeRoomInfo.DestinationId).IsUseForEmpty)
            //    ModelState.AddModelError("DestinationId", "离室时必填。");
            //11-有离室时间，必须有经手护士。
            //if (observeRoomInfo.IsLeave && string.IsNullOrEmpty(observeRoomInfo.HandleNurse))
            //    ModelState.AddModelError("HandleNurse", "离室时必填。");
            //12-离室时间必须不早于入室时间。
            if (observeRoomInfo.OutDepartmentTime.HasValue && observeRoomInfo.InDepartmentTime > observeRoomInfo.OutDepartmentTime)
                ModelState.AddModelError("OutDepartmentTime", "不能早于入室时间。");
            //13-去向为允许附加数据才可以填写去向详细。
            //if (!db.Destinations.Find(observeRoomInfo.DestinationId).IsHasAdditionalInfo && !string.IsNullOrEmpty(observeRoomInfo.DestinationRemarks))
            //    ModelState.AddModelError("DestinationRemarks", "与去向不匹配。");
            //14-去向为允许附加数据,必须填写去向详细。
            if (db.Destinations.Find(observeRoomInfo.DestinationId).IsHasAdditionalInfo && string.IsNullOrEmpty(observeRoomInfo.DestinationRemarks))
                ModelState.AddModelError("DestinationRemarks", "必须有具体名称。");
            //15-有去向，必须有离室时间。
            if (!db.Destinations.Find(observeRoomInfo.DestinationId).IsUseForEmpty && !observeRoomInfo.OutDepartmentTime.HasValue)
                ModelState.AddModelError("OutDepartmentTime", "必须有离室时间。");
            //16-有去向，必须有经手护士。
            if (!db.Destinations.Find(observeRoomInfo.DestinationId).IsUseForEmpty && string.IsNullOrEmpty(observeRoomInfo.HandleNurse))
                ModelState.AddModelError("HandleNurse", "离室时必填。");

            if (ModelState.IsValid)
            {
                observeRoomInfo.ObserveRoomInfoId = Guid.NewGuid();
                observeRoomInfo.UpdateTime = DateTime.Now;

                if (previousRescueRoomInfoId.HasValue)
                {
                    observeRoomInfo.PreviousRescueRoomInfo = db.RescueRoomInfos.Find(previousRescueRoomInfoId);
                }

                Models.BusinessModels.TrasenInformationConvertor.FromEmployeeNumberToName(observeRoomInfo);

                db.ObserveRoomInfos.Add(observeRoomInfo);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = observeRoomInfo.ObserveRoomInfoId });
            }

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForObserveRoom), "BedId", "BedName");
            ViewBag.InObserveRoomWayId = new SelectList(db.InObserveRoomWays, "InObserveRoomWayId", "InObserveRoomWayName");
            ViewBag.DestinationId = new SelectList(db.Destinations.Where(c => c.IsUseForObserveRoom).OrderBy(c => c.Priority2), "DestinationId", "DestinationName");
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName");
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName");

            ViewBag.PreviousRescueRoomInfoId = previousRescueRoomInfoId;

            return View(observeRoomInfo);
        }

        /// <summary>
        /// 编辑。
        /// </summary>
        /// <param name="id">留观室病例ID。</param>
        public ActionResult Edit(Guid id)
        {
            var db = new EiSDbContext();

            var target = db.ObserveRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForObserveRoom), "BedId", "BedName", target.BedId);
            ViewBag.InObserveRoomWayId = new SelectList(db.InObserveRoomWays, "InObserveRoomWayId", "InObserveRoomWayName", target.InObserveRoomWayId);
            ViewBag.DestinationId = new SelectList(db.Destinations.Where(c => c.IsUseForObserveRoom).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", target.DestinationId);
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", target.DestinationFirstId);
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", target.DestinationSecondId);

            return View(target);
        }

        /// <summary>
        /// 编辑 执行。
        /// </summary>
        /// <param name="observeRoomInfo">提交实例。</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind()]ObserveRoomInfo observeRoomInfo)
        {
            var db = new EiSDbContext();

            //1-入室时间不能晚于当前时间。
            if (observeRoomInfo.InDepartmentTime > DateTime.Now)
                ModelState.AddModelError("InDepartmentTime", "入室时间不能晚于当前时间。");
            //2-入室方式必填。
            if (db.InObserveRoomWays.Find(observeRoomInfo.InObserveRoomWayId).IsUseForEmpty)
                ModelState.AddModelError("InObserveRoomWayId", "不可为空。");
            //3-首诊护士必填。
            if (string.IsNullOrEmpty(observeRoomInfo.FirstNurseName))
                ModelState.AddModelError("FirstNurseName", "不可为空。");
            //4-入室方式为允许附加数据才可以有附加数据。
            //if (!db.InObserveRoomWays.Find(observeRoomInfo.InObserveRoomWayId).IsHasAdditionalInfo && !string.IsNullOrEmpty(observeRoomInfo.InObserveRoomWayRemarks))
            //    ModelState.AddModelError("InObserveRoomWayRemarks", "与入院方式不匹配。");
            //5-入室方式为允许附加数据，必须有具体名称。
            if (db.InObserveRoomWays.Find(observeRoomInfo.InObserveRoomWayId).IsHasAdditionalInfo && string.IsNullOrEmpty(observeRoomInfo.InObserveRoomWayRemarks))
                ModelState.AddModelError("InObserveRoomWayRemarks", "必须有具体名称。");
            //6-有预约首选科室，必须有预约首选时间。
            if (!db.Destinations.Find(observeRoomInfo.DestinationFirstId).IsUseForEmpty && !observeRoomInfo.DestinationFirstTime.HasValue)
                ModelState.AddModelError("DestinationFirstTime", "有预约首选科室时必填。");
            //7-预约首选时间不能早于入室时间。
            if (observeRoomInfo.DestinationFirstTime.HasValue && observeRoomInfo.DestinationFirstTime.Value < observeRoomInfo.InDepartmentTime)
                ModelState.AddModelError("DestinationFirstTime", "不能早于入室时间。");
            //8-有预约首选科室，必须有预约首选医师。
            if (!db.Destinations.Find(observeRoomInfo.DestinationFirstId).IsUseForEmpty && string.IsNullOrEmpty(observeRoomInfo.DestinationFirstContact))
                ModelState.AddModelError("DestinationFirstContact", "有预约首选科室时必填。");
            //9-有预约次选科室，必须有预约首选科室。
            if (!db.Destinations.Find(observeRoomInfo.DestinationSecondId).IsUseForEmpty && db.Destinations.Find(observeRoomInfo.DestinationFirstId).IsUseForEmpty)
                ModelState.AddModelError("DestinationSecondId", "必须先填写预约首选科室。");
            //10-有离室时间，必须有去向。
            //if (observeRoomInfo.IsLeave && db.Destinations.Find(observeRoomInfo.DestinationId).IsUseForEmpty)
            //    ModelState.AddModelError("DestinationId", "离室时必填。");
            //11-有离室时间，必须有经手护士。
            //if (observeRoomInfo.IsLeave && string.IsNullOrEmpty(observeRoomInfo.HandleNurse))
            //    ModelState.AddModelError("HandleNurse", "离室时必填。");
            //12-离室时间必须不早于入室时间。
            if (observeRoomInfo.OutDepartmentTime.HasValue && observeRoomInfo.InDepartmentTime > observeRoomInfo.OutDepartmentTime)
                ModelState.AddModelError("OutDepartmentTime", "不能早于入室时间。");
            //13-去向为允许附加数据才可以填写去向详细。
            //if (!db.Destinations.Find(observeRoomInfo.DestinationId).IsHasAdditionalInfo && !string.IsNullOrEmpty(observeRoomInfo.DestinationRemarks))
            //    ModelState.AddModelError("DestinationRemarks", "与去向不匹配。");
            //14-去向为允许附加数据,必须填写去向详细。
            if (db.Destinations.Find(observeRoomInfo.DestinationId).IsHasAdditionalInfo && string.IsNullOrEmpty(observeRoomInfo.DestinationRemarks))
                ModelState.AddModelError("DestinationRemarks", "必须有具体名称。");
            //15-有去向，必须有离室时间。
            if (!db.Destinations.Find(observeRoomInfo.DestinationId).IsUseForEmpty && !observeRoomInfo.OutDepartmentTime.HasValue)
                ModelState.AddModelError("OutDepartmentTime", "必须有离室时间。");
            //16-有去向，必须有经手护士。
            if (!db.Destinations.Find(observeRoomInfo.DestinationId).IsUseForEmpty && string.IsNullOrEmpty(observeRoomInfo.HandleNurse))
                ModelState.AddModelError("HandleNurse", "离室时必填。");

            if (ModelState.IsValid)
            {
                var target = db.ObserveRoomInfos.Find(observeRoomInfo.ObserveRoomInfoId);
                if (target == null)
                    return HttpNotFound();

                target.InDepartmentTime = observeRoomInfo.InDepartmentTime;
                target.BedId = observeRoomInfo.BedId;
                target.FirstNurseName = observeRoomInfo.FirstNurseName;
                target.InObserveRoomWayId = observeRoomInfo.InObserveRoomWayId;
                target.InObserveRoomWayRemarks = observeRoomInfo.InObserveRoomWayRemarks;

                target.DestinationFirstId = observeRoomInfo.DestinationFirstId;
                target.DestinationFirstTime = observeRoomInfo.DestinationFirstTime;
                target.DestinationFirstContact = observeRoomInfo.DestinationFirstContact;
                target.DestinationSecondId = observeRoomInfo.DestinationSecondId;

                target.OutDepartmentTime = observeRoomInfo.OutDepartmentTime;
                target.DestinationId = observeRoomInfo.DestinationId;
                target.DestinationRemarks = observeRoomInfo.DestinationRemarks;
                target.HandleNurse = observeRoomInfo.HandleNurse;
                target.DiagnosisName = observeRoomInfo.DiagnosisName;

                target.TimeStamp = observeRoomInfo.TimeStamp;
                target.UpdateTime = DateTime.Now;

                Models.BusinessModels.TrasenInformationConvertor.FromEmployeeNumberToName(target);

                db.SaveChanges();

                return RedirectToAction("Details", new { id = observeRoomInfo.ObserveRoomInfoId });
            }

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForObserveRoom), "BedId", "BedName", observeRoomInfo.BedId);
            ViewBag.InObserveRoomWayId = new SelectList(db.InObserveRoomWays, "InObserveRoomWayId", "InObserveRoomWayName", observeRoomInfo.InObserveRoomWayId);
            ViewBag.DestinationId = new SelectList(db.Destinations.Where(c => c.IsUseForObserveRoom).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", observeRoomInfo.DestinationId);
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", observeRoomInfo.DestinationFirstId);
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", observeRoomInfo.DestinationSecondId);

            return View(observeRoomInfo);
        }





        /// <summary>
        /// 眉栏。
        /// </summary>
        /// <param name="id">留观室病例ID。</param>
        public ActionResult Header(Guid id)
        {
            var db = new EiSDbContext();

            var target = db.ObserveRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            var targetV = new Header(target);

            return PartialView(targetV);
        }








        public JsonResult CheckInObserveRoomWayIdForIsHasAdditionalInfo(int id)
        {
            var db = new EiSDbContext();

            var target = db.InObserveRoomWays.Find(id);

            if (target == null || !target.IsHasAdditionalInfo)
            {
                var result = new { result = false };
                return Json(result);
            }
            else
            {
                var result = new { result = true };
                return Json(result);
            }
        }

        public JsonResult CheckDestinationFirstIdForIsUseForEmpty(int id)
        {
            var db = new EiSDbContext();

            var target = db.Destinations.Find(id);

            if (target == null || !target.IsUseForEmpty)
            {
                var result = new { result = false };
                return Json(result);
            }
            else
            {
                var result = new { result = true };
                return Json(result);
            }
        }

        public JsonResult CheckDestinationIdForIsHasAdditionalInfo(int id)
        {
            var db = new EiSDbContext();

            var target = db.Destinations.Find(id);

            if (target == null || !target.IsHasAdditionalInfo)
            {
                var result = new { result = false };
                return Json(result);
            }
            else
            {
                var result = new { result = true };
                return Json(result);
            }
        }

        public JsonResult CheckDestinationIdForIsUseForEmpty(int id)
        {
            var db = new EiSDbContext();

            var target = db.Destinations.Find(id);

            if (target == null || !target.IsUseForEmpty)
            {
                var result = new { result = false };
                return Json(result);
            }
            else
            {
                var result = new { result = true };
                return Json(result);
            }
        }
    }
}