using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TrasenLib;

using EmergencyInformationSystem.Models.Domains.Entities;
using EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Index;
using EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Details;
using EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Create;
using EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Header;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 抢救室病例控制器。
    /// </summary>
    public class RescueRoomInfosController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RescueRoomInfosController"/> class.
        /// </summary>
        public RescueRoomInfosController()
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
        /// <param name="greenPathCategoryId">绿色通道类型ID。</param>
        /// <param name="isRescue">是否抢救。</param>
        /// <param name="isLeave">是否已离室。</param>       
        /// <param name="patientName">患者姓名。</param>
        /// <param name="outPatientNumber">卡号。</param>
        /// <param name="page">页码。</param>
        /// <param name="perPage">每页项目数。</param>
        public ActionResult Index(DateTime? inTimeStart = null, DateTime? inTimeEnd = null, DateTime? outTimeStart = null, DateTime? outTimeEnd = null, int? greenPathCategoryId = null, bool? isRescue = null, bool? isLeave = null, string patientName = "", string outPatientNumber = "", int page = 1, int perPage = 20)
        {
            var targetV = new Index(inTimeStart, inTimeEnd, outTimeStart, outTimeEnd, greenPathCategoryId, isRescue, isLeave, patientName, outPatientNumber, page, perPage, db);

            ViewBag.GreenPathCategoryId = new SelectList(db.GreenPathCategories, "GreenPathCategoryId", "GreenPathCategoryName", greenPathCategoryId);
            ViewBag.IsRescue = new SelectList(new List<SelectListItem>
            {
                new SelectListItem {Text="是",Value="True" },
                new SelectListItem {Text="否",Value="False" }
            }, "Value", "Text");
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
        public ActionResult Details(int id)
        {
            var target = db.RescueRoomInfos.Find(id);
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
            var targetDump = db.RescueRoomInfos.Where(c => c.JZID == JZID).FirstOrDefault();
            if (targetDump != null)
                return RedirectToAction("Details", new { id = targetDump.RescueRoomInfoId });

            var target = (new Create3()).GetRescueRoomInfo(outPatientNumber, JZID, GHXXID, BRXXID, KDJID, dbTrasen);

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForRescueRoom), "BedId", "BedName");
            ViewBag.InRescueRoomWayId = new SelectList(db.InRescueRoomWays, "InRescueRoomWayId", "InRescueRoomWayName");
            ViewBag.GreenPathCategoryId = new SelectList(db.GreenPathCategories, "GreenPathCategoryId", "GreenPathCategoryName");
            ViewBag.RescueResultId = new SelectList(db.RescueResults, "RescueResultId", "RescueResultName");
            ViewBag.DestinationId = new SelectList(db.Destinations, "DestinationId", "DestinationName");
            ViewBag.CriticalLevelId = new SelectList(db.CriticalLevels, "CriticalLevelId", "CriticalLevelName");
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription), "DestinationId", "DestinationName");
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription), "DestinationId", "DestinationName");

            return View(target);
        }

        /// <summary>
        /// 新增3——执行。
        /// </summary>
        /// <param name="rescueRoomInfo">提交实例。</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create3([Bind()]RescueRoomInfo rescueRoomInfo)
        {
            //查找是否已存在相同JZID的记录。若存在，则跳转到Details。
            var targetDump = db.RescueRoomInfos.Where(c => c.JZID == rescueRoomInfo.JZID).FirstOrDefault();
            if (targetDump != null)
                return RedirectToAction("Details", new { id = targetDump.RescueRoomInfoId });

            //1-入室时间不能晚于当前时间。
            if (rescueRoomInfo.InDepartmentTime > DateTime.Now)
                ModelState.AddModelError("InDepartmentTime", "入室时间不能晚于当前时间。");
            //2-入室方式必填。
            if (db.InRescueRoomWays.Find(rescueRoomInfo.InRescueRoomWayId).IsUseForEmpty)
                ModelState.AddModelError("InRescueRoomWayId", "不可为空。");
            //3-首诊护士必填。
            if (string.IsNullOrEmpty(rescueRoomInfo.FirstNurseName))
                ModelState.AddModelError("FirstNurseName", "不可为空。");
            //4-入室方式为允许附加数据才可以有附加数据。
            if (!db.InRescueRoomWays.Find(rescueRoomInfo.InRescueRoomWayId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.InRescueRoomWayRemarks))
                ModelState.AddModelError("InRescueRoomWayRemarks", "与入院方式不匹配。");
            //5-入室方式为允许附加数据，必须有具体名称。
            if (db.InRescueRoomWays.Find(rescueRoomInfo.InRescueRoomWayId).IsHasAdditionalInfo && string.IsNullOrEmpty(rescueRoomInfo.InRescueRoomWayRemarks))
                ModelState.AddModelError("InRescueRoomWayRemarks", "必须有具体名称。");
            //6-有抢救才能有抢救结果。
            if (!rescueRoomInfo.IsRescue && !db.RescueResults.Find(rescueRoomInfo.RescueResultId).IsUseForEmpty)
                ModelState.AddModelError("RescueResultId", "与抢救不匹配。");
            //7-离室时，有抢救则必须有抢救结果。
            if (rescueRoomInfo.IsLeave && rescueRoomInfo.IsRescue && db.RescueResults.Find(rescueRoomInfo.RescueResultId).IsUseForEmpty)
                ModelState.AddModelError("RescueResultId", "离室时有抢救必须有抢救结果。");
            //8-绿色通道为允许附加数据才可以有附加数据。
            if (!db.GreenPathCategories.Find(rescueRoomInfo.GreenPathCategoryId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.GreenPathCategoryRemarks))
                ModelState.AddModelError("GreenPathCategoryRemarks", "与绿色通道病种不匹配。");
            //9-绿色通道为允许附加数据,必须有具体名称。
            if (db.GreenPathCategories.Find(rescueRoomInfo.GreenPathCategoryId).IsHasAdditionalInfo && string.IsNullOrEmpty(rescueRoomInfo.GreenPathCategoryRemarks))
                ModelState.AddModelError("GreenPathCategoryRemarks", "必须有具体名称。");
            //10-有预约首选科室，必须有预约首选时间。
            if (!db.Destinations.Find(rescueRoomInfo.DestinationFirstId).IsUseForEmpty && !rescueRoomInfo.DestinationFirstTime.HasValue)
                ModelState.AddModelError("DestinationFirstTime", "有预约首选科室时必填。");
            //11-预约首选时间不能早于入室时间。
            if (rescueRoomInfo.DestinationFirstTime.HasValue && rescueRoomInfo.DestinationFirstTime.Value < rescueRoomInfo.InDepartmentTime)
                ModelState.AddModelError("DestinationFirstTime", "不能早于入室时间。");
            //12-有预约首选科室，必须有预约首选医师。
            if (!db.Destinations.Find(rescueRoomInfo.DestinationFirstId).IsUseForEmpty && string.IsNullOrEmpty(rescueRoomInfo.DestinationFirstContact))
                ModelState.AddModelError("DestinationFirstContact", "有预约首选科室时必填。");
            //12-有预约次选科室，必须有预约首选科室。
            if (!db.Destinations.Find(rescueRoomInfo.DestinationSecondId).IsUseForEmpty && db.Destinations.Find(rescueRoomInfo.DestinationFirstId).IsUseForEmpty)
                ModelState.AddModelError("DestinationSecondId", "必须先填写预约首选科室。");
            //13-有离室时间，必须有去向。
            if (rescueRoomInfo.IsLeave && db.Destinations.Find(rescueRoomInfo.DestinationId).IsUseForEmpty)
                ModelState.AddModelError("DestinationId", "离室时必填。");
            //14-有离室时间，必须有经手护士。
            if (rescueRoomInfo.IsLeave && string.IsNullOrEmpty(rescueRoomInfo.HandleNurse))
                ModelState.AddModelError("HandleNurse", "离室时必填。");
            //15-离室时间必须不早于入室时间。
            if (rescueRoomInfo.OutDepartmentTime.HasValue && rescueRoomInfo.InDepartmentTime > rescueRoomInfo.OutDepartmentTime)
                ModelState.AddModelError("OutDepartmentTime", "不能早于入室时间。");
            //16-去向为允许附加数据才可以填写去向详细。
            if (!db.Destinations.Find(rescueRoomInfo.DestinationId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.DestinationRemarks))
                ModelState.AddModelError("DestinationRemarks", "与去向不匹配。");
            //17-去向为允许附加数据,必须填写去向详细。
            if (db.Destinations.Find(rescueRoomInfo.DestinationId).IsHasAdditionalInfo && string.IsNullOrEmpty(rescueRoomInfo.DestinationRemarks))
                ModelState.AddModelError("DestinationRemarks", "必须有具体名称。");

            if (ModelState.IsValid)
            {
                rescueRoomInfo.UpdateTime = DateTime.Now;

                db.RescueRoomInfos.Add(rescueRoomInfo);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = rescueRoomInfo.RescueRoomInfoId });
            }

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForRescueRoom), "BedId", "BedName");
            ViewBag.InRescueRoomWayId = new SelectList(db.InRescueRoomWays, "InRescueRoomWayId", "InRescueRoomWayName");
            ViewBag.GreenPathCategoryId = new SelectList(db.GreenPathCategories, "GreenPathCategoryId", "GreenPathCategoryName");
            ViewBag.RescueResultId = new SelectList(db.RescueResults, "RescueResultId", "RescueResultName");
            ViewBag.DestinationId = new SelectList(db.Destinations, "DestinationId", "DestinationName");
            ViewBag.CriticalLevelId = new SelectList(db.CriticalLevels, "CriticalLevelId", "CriticalLevelName");
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription), "DestinationId", "DestinationName");
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription), "DestinationId", "DestinationName");

            return View(rescueRoomInfo);
        }

        /// <summary>
        /// 编辑。
        /// </summary>
        /// <param name="id">主ID。</param>
        public ActionResult Edit(int id)
        {
            var target = db.RescueRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForRescueRoom), "BedId", "BedName", target.BedId);
            ViewBag.InRescueRoomWayId = new SelectList(db.InRescueRoomWays, "InRescueRoomWayId", "InRescueRoomWayName", target.InRescueRoomWayId);
            ViewBag.GreenPathCategoryId = new SelectList(db.GreenPathCategories, "GreenPathCategoryId", "GreenPathCategoryName", target.GreenPathCategoryId);
            ViewBag.RescueResultId = new SelectList(db.RescueResults, "RescueResultId", "RescueResultName", target.RescueResultId);
            ViewBag.DestinationId = new SelectList(db.Destinations, "DestinationId", "DestinationName", target.DestinationId);
            ViewBag.CriticalLevelId = new SelectList(db.CriticalLevels, "CriticalLevelId", "CriticalLevelName", target.CriticalLevelId);
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
        public ActionResult Edit([Bind()]RescueRoomInfo rescueRoomInfo)
        {
            //1-入室时间不能晚于当前时间。
            if (rescueRoomInfo.InDepartmentTime > DateTime.Now)
                ModelState.AddModelError("InDepartmentTime", "入室时间不能晚于当前时间。");
            //2-入室方式必填。
            if (db.InRescueRoomWays.Find(rescueRoomInfo.InRescueRoomWayId).IsUseForEmpty)
                ModelState.AddModelError("InRescueRoomWayId", "不可为空。");
            //3-首诊护士必填。
            if (string.IsNullOrEmpty(rescueRoomInfo.FirstNurseName))
                ModelState.AddModelError("FirstNurseName", "不可为空。");
            //4-入室方式为允许附加数据才可以有附加数据。。
            if (!db.InRescueRoomWays.Find(rescueRoomInfo.InRescueRoomWayId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.InRescueRoomWayRemarks))
                ModelState.AddModelError("InRescueRoomWayRemarks", "与入院方式不匹配。");
            //5-入室方式为允许附加数据，必须有具体名称。
            if (db.InRescueRoomWays.Find(rescueRoomInfo.InRescueRoomWayId).IsHasAdditionalInfo && string.IsNullOrEmpty(rescueRoomInfo.InRescueRoomWayRemarks))
                ModelState.AddModelError("InRescueRoomWayRemarks", "必须有具体名称。");
            //6-有抢救才能有抢救结果。
            if (!rescueRoomInfo.IsRescue && !db.RescueResults.Find(rescueRoomInfo.RescueResultId).IsUseForEmpty)
                ModelState.AddModelError("RescueResultId", "与抢救不匹配。");
            //7-离室时，有抢救则必须有抢救结果。
            if (rescueRoomInfo.IsLeave && rescueRoomInfo.IsRescue && db.RescueResults.Find(rescueRoomInfo.RescueResultId).IsUseForEmpty)
                ModelState.AddModelError("RescueResultId", "离室时有抢救必须有抢救结果。");
            //8-绿色通道为允许附加数据才可以有附加数据。
            if (!db.GreenPathCategories.Find(rescueRoomInfo.GreenPathCategoryId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.GreenPathCategoryRemarks))
                ModelState.AddModelError("GreenPathCategoryRemarks", "与绿色通道病种不匹配。");
            //9-绿色通道为允许附加数据,必须有具体名称。
            if (db.GreenPathCategories.Find(rescueRoomInfo.GreenPathCategoryId).IsHasAdditionalInfo && string.IsNullOrEmpty(rescueRoomInfo.GreenPathCategoryRemarks))
                ModelState.AddModelError("GreenPathCategoryRemarks", "必须有具体名称。");
            //10-有预约首选科室，必须有预约首选时间。
            if (!db.Destinations.Find(rescueRoomInfo.DestinationFirstId).IsUseForEmpty && !rescueRoomInfo.DestinationFirstTime.HasValue)
                ModelState.AddModelError("DestinationFirstTime", "有预约首选科室时必填。");
            //11-预约首选时间不能早于入室时间。
            if (rescueRoomInfo.DestinationFirstTime.HasValue && rescueRoomInfo.DestinationFirstTime.Value < rescueRoomInfo.InDepartmentTime)
                ModelState.AddModelError("DestinationFirstTime", "不能早于入室时间。");
            //12-有预约首选科室，必须有预约首选医师。
            if (!db.Destinations.Find(rescueRoomInfo.DestinationFirstId).IsUseForEmpty && string.IsNullOrEmpty(rescueRoomInfo.DestinationFirstContact))
                ModelState.AddModelError("DestinationFirstContact", "有预约首选科室时必填。");
            //12-有预约次选科室，必须有预约首选科室。
            if (!db.Destinations.Find(rescueRoomInfo.DestinationSecondId).IsUseForEmpty && db.Destinations.Find(rescueRoomInfo.DestinationFirstId).IsUseForEmpty)
                ModelState.AddModelError("DestinationSecondId", "必须先填写预约首选科室。");
            //13-有离室时间，必须有去向。
            if (rescueRoomInfo.IsLeave && db.Destinations.Find(rescueRoomInfo.DestinationId).IsUseForEmpty)
                ModelState.AddModelError("DestinationId", "离室时必填。");
            //14-有离室时间，必须有经手护士。
            if (rescueRoomInfo.IsLeave && string.IsNullOrEmpty(rescueRoomInfo.HandleNurse))
                ModelState.AddModelError("HandleNurse", "离室时必填。");
            //15-离室时间必须不早于入室时间。
            if (rescueRoomInfo.OutDepartmentTime.HasValue && rescueRoomInfo.InDepartmentTime > rescueRoomInfo.OutDepartmentTime)
                ModelState.AddModelError("OutDepartmentTime", "不能早于入室时间。");
            //16-去向为允许附加数据才可以填写去向详细。
            if (!db.Destinations.Find(rescueRoomInfo.DestinationId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.DestinationRemarks))
                ModelState.AddModelError("DestinationRemarks", "与去向不匹配。");
            //17-去向为允许附加数据,必须填写去向详细。
            if (db.Destinations.Find(rescueRoomInfo.DestinationId).IsHasAdditionalInfo && string.IsNullOrEmpty(rescueRoomInfo.DestinationRemarks))
                ModelState.AddModelError("DestinationRemarks", "必须有具体名称。");

            if (ModelState.IsValid)
            {
                var target = db.RescueRoomInfos.Find(rescueRoomInfo.RescueRoomInfoId);
                if (target == null)
                    return HttpNotFound();

                target.InDepartmentTime = rescueRoomInfo.InDepartmentTime;
                target.BedId = rescueRoomInfo.BedId;
                target.FirstNurseName = rescueRoomInfo.FirstNurseName;
                target.InRescueRoomWayId = rescueRoomInfo.InRescueRoomWayId;
                target.InRescueRoomWayRemarks = rescueRoomInfo.InRescueRoomWayRemarks;

                target.CriticalLevelId = rescueRoomInfo.CriticalLevelId;
                target.IsRescue = rescueRoomInfo.IsRescue;
                target.RescueResultId = rescueRoomInfo.RescueResultId;
                target.GreenPathCategoryId = rescueRoomInfo.GreenPathCategoryId;
                target.GreenPathCategoryRemarks = rescueRoomInfo.GreenPathCategoryRemarks;
                target.Antibiotic = rescueRoomInfo.Antibiotic;
                target.Remarks = rescueRoomInfo.Remarks;

                target.DestinationFirstId = rescueRoomInfo.DestinationFirstId;
                target.DestinationFirstTime = rescueRoomInfo.DestinationFirstTime;
                target.DestinationFirstContact = rescueRoomInfo.DestinationFirstContact;
                target.DestinationSecondId = rescueRoomInfo.DestinationSecondId;

                target.OutDepartmentTime = rescueRoomInfo.OutDepartmentTime;
                target.DestinationId = rescueRoomInfo.DestinationId;
                target.DestinationRemarks = rescueRoomInfo.DestinationRemarks;
                target.HandleNurse = rescueRoomInfo.HandleNurse;
                target.DiagnosisName = rescueRoomInfo.DiagnosisName;

                target.TimeStamp = rescueRoomInfo.TimeStamp;
                target.UpdateTime = DateTime.Now;

                db.SaveChanges();

                return RedirectToAction("Details", new { id = rescueRoomInfo.RescueRoomInfoId });
            }

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForRescueRoom), "BedId", "BedName", rescueRoomInfo.BedId);
            ViewBag.InRescueRoomWayId = new SelectList(db.InRescueRoomWays, "InRescueRoomWayId", "InRescueRoomWayName", rescueRoomInfo.InRescueRoomWayId);
            ViewBag.GreenPathCategoryId = new SelectList(db.GreenPathCategories, "GreenPathCategoryId", "GreenPathCategoryName", rescueRoomInfo.GreenPathCategoryId);
            ViewBag.RescueResultId = new SelectList(db.RescueResults, "RescueResultId", "RescueResultName", rescueRoomInfo.RescueResultId);
            ViewBag.DestinationId = new SelectList(db.Destinations, "DestinationId", "DestinationName", rescueRoomInfo.DestinationId);
            ViewBag.CriticalLevelId = new SelectList(db.CriticalLevels, "CriticalLevelId", "CriticalLevelName", rescueRoomInfo.CriticalLevelId);
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription), "DestinationId", "DestinationName", rescueRoomInfo.DestinationFirstId);
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription), "DestinationId", "DestinationName", rescueRoomInfo.DestinationSecondId);

            return View(rescueRoomInfo);
        }





        /// <summary>
        /// 眉栏。
        /// </summary>
        /// <param name="id">主ID。</param>
        public ActionResult Header(int id)
        {
            var target = db.RescueRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            var targetV = new Header(target);

            return PartialView(targetV);
        }
    }
}