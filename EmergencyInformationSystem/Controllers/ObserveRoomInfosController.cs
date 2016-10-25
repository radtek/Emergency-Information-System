using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TrasenLib;

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
        /// Initializes a new instance of the <see cref="ObserveRoomInfosController"/> class.
        /// </summary>
        public ObserveRoomInfosController()
        {
            this.db = new EiSDbContext();
            this.dbTrasen = new TrasenDbContext("TrasenConnection");
        }





        /// <summary>
        /// Trasen数据上下文。
        /// </summary>
        private TrasenDbContext dbTrasen;

        /// <summary>
        /// EiS数据上下文。
        /// </summary>
        private EiSDbContext db;





        /// <summary>
        /// 一览。
        /// </summary>
        /// <param name="inTimeStart">入室时间开始点。</param>
        /// <param name="inTimeEnd">入室时间结束点。</param>
        /// <param name="outTimeStart">离室时间开始点。</param>
        /// <param name="outTimeEnd">离室时间结束点。</param>       
        /// <param name="isLeave">是否已离室。</param>       
        /// <param name="patientName">患者姓名。</param>
        /// <param name="outPatientNumber">卡号。</param>
        /// <param name="page">页码。</param>
        /// <param name="perPage">每页项目数。</param>
        public ActionResult Index(DateTime? inTimeStart = null, DateTime? inTimeEnd = null, DateTime? outTimeStart = null, DateTime? outTimeEnd = null, bool? isLeave = null, string patientName = "", string outPatientNumber = "", int page = 1, int perPage = 20)
        {
            var targetV = new Index(inTimeStart, inTimeEnd, outTimeStart, outTimeEnd, isLeave, patientName, outPatientNumber, page, perPage, db);

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
        /// <param name="id">主ID。</param>
        public ActionResult Details(Guid id)
        {
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
        /// 新增1——执行。
        /// </summary>
        /// <remarks>跳转到Create2。</remarks>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind()]Create create)
        {
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
            var targetV = new Create2(outPatientNumber, dbTrasen);

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
        /// <returns>表单。</returns>
        public ActionResult Create3(string outPatientNumber, Guid JZID, Guid GHXXID, Guid BRXXID, Guid KDJID)
        {
            //查找是否已存在相同JZID的记录。若存在，则跳转到Details。
            var targetDump = db.ObserveRoomInfos.Where(c => c.JZID == JZID).FirstOrDefault();
            if (targetDump != null)
                return RedirectToAction("Details", new { id = targetDump.ObserveRoomInfoId });

            var target = (new Create3()).GetObserveRoomInfo(outPatientNumber, JZID, GHXXID, BRXXID, KDJID, dbTrasen);

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForObserveRoom), "BedId", "BedName");
            ViewBag.InObserveRoomWayId = new SelectList(db.InObserveRoomWays, "InObserveRoomWayId", "InObserveRoomWayName");
            ViewBag.DestinationId = new SelectList(db.Destinations, "DestinationId", "DestinationName");
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription), "DestinationId", "DestinationName");
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription), "DestinationId", "DestinationName");

            return View(target);
        }

        /// <summary>
        /// 新增3——执行。
        /// </summary>
        /// <param name="observeRoomInfo">提交实例。</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create3([Bind()]ObserveRoomInfo observeRoomInfo)
        {
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
            if (!db.InObserveRoomWays.Find(observeRoomInfo.InObserveRoomWayId).IsHasAdditionalInfo && !string.IsNullOrEmpty(observeRoomInfo.InObserveRoomWayRemarks))
                ModelState.AddModelError("InObserveRoomWayRemarks", "与入院方式不匹配。");
            //5-入室方式为允许附加数据，必须有具体名称。
            if (db.InObserveRoomWays.Find(observeRoomInfo.InObserveRoomWayId).IsHasAdditionalInfo && string.IsNullOrEmpty(observeRoomInfo.InObserveRoomWayRemarks))
                ModelState.AddModelError("InObserveRoomWayRemarks", "必须有具体名称。");
            //10-有预约首选科室，必须有预约首选时间。
            if (!db.Destinations.Find(observeRoomInfo.DestinationFirstId).IsUseForEmpty && !observeRoomInfo.DestinationFirstTime.HasValue)
                ModelState.AddModelError("DestinationFirstTime", "有预约首选科室时必填。");
            //11-预约首选时间不能早于入室时间。
            if (observeRoomInfo.DestinationFirstTime.HasValue && observeRoomInfo.DestinationFirstTime.Value < observeRoomInfo.InDepartmentTime)
                ModelState.AddModelError("DestinationFirstTime", "不能早于入室时间。");
            //12-有预约首选科室，必须有预约首选医师。
            if (!db.Destinations.Find(observeRoomInfo.DestinationFirstId).IsUseForEmpty && string.IsNullOrEmpty(observeRoomInfo.DestinationFirstContact))
                ModelState.AddModelError("DestinationFirstContact", "有预约首选科室时必填。");
            //12-有预约次选科室，必须有预约首选科室。
            if (!db.Destinations.Find(observeRoomInfo.DestinationSecondId).IsUseForEmpty && db.Destinations.Find(observeRoomInfo.DestinationFirstId).IsUseForEmpty)
                ModelState.AddModelError("DestinationSecondId", "必须先填写预约首选科室。");
            //13-有离室时间，必须有去向。
            if (observeRoomInfo.IsLeave && db.Destinations.Find(observeRoomInfo.DestinationId).IsUseForEmpty)
                ModelState.AddModelError("DestinationId", "离室时必填。");
            //14-有离室时间，必须有经手护士。
            if (observeRoomInfo.IsLeave && string.IsNullOrEmpty(observeRoomInfo.HandleNurse))
                ModelState.AddModelError("HandleNurse", "离室时必填。");
            //15-离室时间必须不早于入室时间。
            if (observeRoomInfo.OutDepartmentTime.HasValue && observeRoomInfo.InDepartmentTime > observeRoomInfo.OutDepartmentTime)
                ModelState.AddModelError("OutDepartmentTime", "不能早于入室时间。");
            //16-去向为允许附加数据才可以填写去向详细。
            if (!db.Destinations.Find(observeRoomInfo.DestinationId).IsHasAdditionalInfo && !string.IsNullOrEmpty(observeRoomInfo.DestinationRemarks))
                ModelState.AddModelError("DestinationRemarks", "与去向不匹配。");
            //17-去向为允许附加数据,必须填写去向详细。
            if (db.Destinations.Find(observeRoomInfo.DestinationId).IsHasAdditionalInfo && string.IsNullOrEmpty(observeRoomInfo.DestinationRemarks))
                ModelState.AddModelError("DestinationRemarks", "必须有具体名称。");

            if (ModelState.IsValid)
            {
                observeRoomInfo.ObserveRoomInfoId = Guid.NewGuid();
                observeRoomInfo.UpdateTime = DateTime.Now;

                db.ObserveRoomInfos.Add(observeRoomInfo);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = observeRoomInfo.ObserveRoomInfoId });
            }

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForObserveRoom), "BedId", "BedName");
            ViewBag.InObserveRoomWayId = new SelectList(db.InObserveRoomWays, "InObserveRoomWayId", "InObserveRoomWayName");
            ViewBag.DestinationId = new SelectList(db.Destinations, "DestinationId", "DestinationName");
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription), "DestinationId", "DestinationName");
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription), "DestinationId", "DestinationName");

            return View(observeRoomInfo);
        }

        /// <summary>
        /// 编辑。
        /// </summary>
        /// <param name="id">主ID。</param>
        public ActionResult Edit(Guid id)
        {
            var target = db.ObserveRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForObserveRoom), "BedId", "BedName", target.BedId);
            ViewBag.InObserveRoomWayId = new SelectList(db.InObserveRoomWays, "InObserveRoomWayId", "InObserveRoomWayName", target.InObserveRoomWayId);
            ViewBag.DestinationId = new SelectList(db.Destinations, "DestinationId", "DestinationName", target.DestinationId);
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription), "DestinationId", "DestinationName", target.DestinationFirstId);
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription), "DestinationId", "DestinationName", target.DestinationSecondId);

            return View(target);
        }

        /// <summary>
        /// 编辑——执行。
        /// </summary>
        /// <param name="rescueRoomInfo">提交实例。</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind()]ObserveRoomInfo observeRoomInfo)
        {
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
            if (!db.InObserveRoomWays.Find(observeRoomInfo.InObserveRoomWayId).IsHasAdditionalInfo && !string.IsNullOrEmpty(observeRoomInfo.InObserveRoomWayRemarks))
                ModelState.AddModelError("InObserveRoomWayRemarks", "与入院方式不匹配。");
            //5-入室方式为允许附加数据，必须有具体名称。
            if (db.InObserveRoomWays.Find(observeRoomInfo.InObserveRoomWayId).IsHasAdditionalInfo && string.IsNullOrEmpty(observeRoomInfo.InObserveRoomWayRemarks))
                ModelState.AddModelError("InObserveRoomWayRemarks", "必须有具体名称。");
            //10-有预约首选科室，必须有预约首选时间。
            if (!db.Destinations.Find(observeRoomInfo.DestinationFirstId).IsUseForEmpty && !observeRoomInfo.DestinationFirstTime.HasValue)
                ModelState.AddModelError("DestinationFirstTime", "有预约首选科室时必填。");
            //11-预约首选时间不能早于入室时间。
            if (observeRoomInfo.DestinationFirstTime.HasValue && observeRoomInfo.DestinationFirstTime.Value < observeRoomInfo.InDepartmentTime)
                ModelState.AddModelError("DestinationFirstTime", "不能早于入室时间。");
            //12-有预约首选科室，必须有预约首选医师。
            if (!db.Destinations.Find(observeRoomInfo.DestinationFirstId).IsUseForEmpty && string.IsNullOrEmpty(observeRoomInfo.DestinationFirstContact))
                ModelState.AddModelError("DestinationFirstContact", "有预约首选科室时必填。");
            //12-有预约次选科室，必须有预约首选科室。
            if (!db.Destinations.Find(observeRoomInfo.DestinationSecondId).IsUseForEmpty && db.Destinations.Find(observeRoomInfo.DestinationFirstId).IsUseForEmpty)
                ModelState.AddModelError("DestinationSecondId", "必须先填写预约首选科室。");
            //13-有离室时间，必须有去向。
            if (observeRoomInfo.IsLeave && db.Destinations.Find(observeRoomInfo.DestinationId).IsUseForEmpty)
                ModelState.AddModelError("DestinationId", "离室时必填。");
            //14-有离室时间，必须有经手护士。
            if (observeRoomInfo.IsLeave && string.IsNullOrEmpty(observeRoomInfo.HandleNurse))
                ModelState.AddModelError("HandleNurse", "离室时必填。");
            //15-离室时间必须不早于入室时间。
            if (observeRoomInfo.OutDepartmentTime.HasValue && observeRoomInfo.InDepartmentTime > observeRoomInfo.OutDepartmentTime)
                ModelState.AddModelError("OutDepartmentTime", "不能早于入室时间。");
            //16-去向为允许附加数据才可以填写去向详细。
            if (!db.Destinations.Find(observeRoomInfo.DestinationId).IsHasAdditionalInfo && !string.IsNullOrEmpty(observeRoomInfo.DestinationRemarks))
                ModelState.AddModelError("DestinationRemarks", "与去向不匹配。");
            //17-去向为允许附加数据,必须填写去向详细。
            if (db.Destinations.Find(observeRoomInfo.DestinationId).IsHasAdditionalInfo && string.IsNullOrEmpty(observeRoomInfo.DestinationRemarks))
                ModelState.AddModelError("DestinationRemarks", "必须有具体名称。");

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

                db.SaveChanges();

                return RedirectToAction("Details", new { id = observeRoomInfo.ObserveRoomInfoId });
            }

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForObserveRoom), "BedId", "BedName", observeRoomInfo.BedId);
            ViewBag.InObserveRoomWayId = new SelectList(db.InObserveRoomWays, "InObserveRoomWayId", "InObserveRoomWayName", observeRoomInfo.InObserveRoomWayId);
            ViewBag.DestinationId = new SelectList(db.Destinations, "DestinationId", "DestinationName", observeRoomInfo.DestinationId);
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription), "DestinationId", "DestinationName", observeRoomInfo.DestinationFirstId);
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription), "DestinationId", "DestinationName", observeRoomInfo.DestinationSecondId);

            return View(observeRoomInfo);
        }

        /// <summary>
        /// 眉栏。
        /// </summary>
        /// <param name="id">主ID。</param>
        public ActionResult Header(Guid id)
        {
            var target = db.ObserveRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            var targetV = new Header(target);

            return PartialView(targetV);
        }
    }
}