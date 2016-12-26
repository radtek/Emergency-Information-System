using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        /// 一览。
        /// </summary>
        /// <param name="inDepartmentTimeStart">入室时间起点。</param>
        /// <param name="inDepartmentTimeEnd">入室时间结点。</param>
        /// <param name="outDepartmentTimeStart">离室时间起点。</param>
        /// <param name="outDepartmentTimeEnd">离室时间结点。</param>
        /// <param name="greenPathCategoryId">绿色通道类型ID。</param>
        /// <param name="isRescue">是否抢救。</param>
        /// <param name="isLeave">是否离室。</param>
        /// <param name="patientName">患者姓名。</param>
        /// <param name="outPatientNumber">卡号。</param>
        /// <param name="page">页码。</param>
        /// <param name="perPage">每页项目数。</param>
        public ActionResult Index(DateTime? inDepartmentTimeStart, DateTime? inDepartmentTimeEnd, DateTime? outDepartmentTimeStart, DateTime? outDepartmentTimeEnd, int? greenPathCategoryId, bool? isRescue, bool? isLeave, string patientName, string outPatientNumber, int page = 1, int perPage = 20)
        {
            var targetV = new Index(inDepartmentTimeStart, inDepartmentTimeEnd, outDepartmentTimeStart, outDepartmentTimeEnd, greenPathCategoryId, isRescue, isLeave, patientName, outPatientNumber, page, perPage);

            var db = new EiSDbContext();

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
        /// <param name="id">抢救室病例ID。</param>
        public ActionResult Details(int id)
        {
            var db = new EiSDbContext();

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
            var targetDump = db.RescueRoomInfos.Where(c => c.JZID == JZID).FirstOrDefault();
            if (targetDump != null)
                return RedirectToAction("Details", new { id = targetDump.RescueRoomInfoId });

            var targetV = new Create3(outPatientNumber, JZID, GHXXID, BRXXID, KDJID);

            //无留观室记录时，跳转到下一步。
            if (targetV.ListObserveRoomInfos.Count() != 0)
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
        /// <param name="previousObserveRoomInfoId">关联的留观室病例ID。</param>
        /// <returns>表单。</returns>
        public ActionResult Create4(string outPatientNumber, Guid JZID, Guid GHXXID, Guid BRXXID, Guid KDJID, Guid? previousObserveRoomInfoId)
        {
            var db = new EiSDbContext();

            //查找是否已存在相同JZID的记录。若存在，则跳转到Details。
            var targetDump = db.RescueRoomInfos.Where(c => c.JZID == JZID).FirstOrDefault();
            if (targetDump != null)
                return RedirectToAction("Details", new { id = targetDump.RescueRoomInfoId });

            var target = (new Create4()).GetRescueRoomInfo(outPatientNumber, JZID, GHXXID, BRXXID, KDJID);

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForRescueRoom), "BedId", "BedName");
            ViewBag.InRescueRoomWayId = new SelectList(db.InRescueRoomWays, "InRescueRoomWayId", "InRescueRoomWayName");
            ViewBag.GreenPathCategoryId = new SelectList(db.GreenPathCategories, "GreenPathCategoryId", "GreenPathCategoryName");
            ViewBag.RescueResultId = new SelectList(db.RescueResults, "RescueResultId", "RescueResultName");
            ViewBag.DestinationId = new SelectList(db.Destinations.Where(c => c.IsUseForRescueRoom).OrderBy(c => c.Priority2), "DestinationId", "DestinationName");
            ViewBag.CriticalLevelId = new SelectList(db.CriticalLevels, "CriticalLevelId", "CriticalLevelName");
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName");
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName");

            ViewBag.PreviousObserveRoomInfoId = previousObserveRoomInfoId;

            return View(target);
        }

        /// <summary>
        /// 新增4 执行。
        /// </summary>
        /// <param name="rescueRoomInfo">提交实例。</param>
        /// <param name="previousObserveRoomInfoId">关联的留观室病例ID。</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create4([Bind()]RescueRoomInfo rescueRoomInfo, Guid? previousObserveRoomInfoId)
        {
            var db = new EiSDbContext();

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
            //if (!db.InRescueRoomWays.Find(rescueRoomInfo.InRescueRoomWayId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.InRescueRoomWayRemarks))
            //    ModelState.AddModelError("InRescueRoomWayRemarks", "与入院方式不匹配。");
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
            //if (!db.GreenPathCategories.Find(rescueRoomInfo.GreenPathCategoryId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.GreenPathCategoryRemarks))
            //    ModelState.AddModelError("GreenPathCategoryRemarks", "与绿色通道病种不匹配。");
            //9-绿色通道为允许附加数据，必须有具体名称。
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
            //13-有预约次选科室，必须有预约首选科室。
            if (!db.Destinations.Find(rescueRoomInfo.DestinationSecondId).IsUseForEmpty && db.Destinations.Find(rescueRoomInfo.DestinationFirstId).IsUseForEmpty)
                ModelState.AddModelError("DestinationSecondId", "必须先填写预约首选科室。");
            //14-有离室时间，必须有去向。
            //if (rescueRoomInfo.IsLeave && db.Destinations.Find(rescueRoomInfo.DestinationId).IsUseForEmpty)
            //    ModelState.AddModelError("DestinationId", "离室时必填。");
            //15-有离室时间，必须有经手护士。
            //if (rescueRoomInfo.IsLeave && string.IsNullOrEmpty(rescueRoomInfo.HandleNurse))
            //    ModelState.AddModelError("HandleNurse", "离室时必填。");
            //16-离室时间必须不早于入室时间。
            if (rescueRoomInfo.OutDepartmentTime.HasValue && rescueRoomInfo.InDepartmentTime > rescueRoomInfo.OutDepartmentTime)
                ModelState.AddModelError("OutDepartmentTime", "不能早于入室时间。");
            //17-去向为允许附加数据才可以填写去向详细。
            //if (!db.Destinations.Find(rescueRoomInfo.DestinationId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.DestinationRemarks))
            //    ModelState.AddModelError("DestinationRemarks", "与去向不匹配。");
            //18-去向为允许附加数据,必须填写去向详细。
            if (db.Destinations.Find(rescueRoomInfo.DestinationId).IsHasAdditionalInfo && string.IsNullOrEmpty(rescueRoomInfo.DestinationRemarks))
                ModelState.AddModelError("DestinationRemarks", "必须有具体名称。");
            //19-有去向，必须有离室时间。
            if (!db.Destinations.Find(rescueRoomInfo.DestinationId).IsUseForEmpty && !rescueRoomInfo.OutDepartmentTime.HasValue)
                ModelState.AddModelError("OutDepartmentTime", "必须有离室时间。");
            //20-有去向，必须有经手护士。
            if (!db.Destinations.Find(rescueRoomInfo.DestinationId).IsUseForEmpty && string.IsNullOrEmpty(rescueRoomInfo.HandleNurse))
                ModelState.AddModelError("HandleNurse", "离室时必填。");

            if (ModelState.IsValid)
            {
                rescueRoomInfo.UpdateTime = DateTime.Now;

                if (previousObserveRoomInfoId.HasValue)
                {
                    rescueRoomInfo.PreviousObserveRoomInfo = db.ObserveRoomInfos.Find(previousObserveRoomInfoId);
                }

                Models.BusinessModels.TrasenInformationConvertor.FromEmployeeNumberToName(rescueRoomInfo);

                db.RescueRoomInfos.Add(rescueRoomInfo);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = rescueRoomInfo.RescueRoomInfoId });
            }

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForRescueRoom), "BedId", "BedName");
            ViewBag.InRescueRoomWayId = new SelectList(db.InRescueRoomWays, "InRescueRoomWayId", "InRescueRoomWayName");
            ViewBag.GreenPathCategoryId = new SelectList(db.GreenPathCategories, "GreenPathCategoryId", "GreenPathCategoryName");
            ViewBag.RescueResultId = new SelectList(db.RescueResults, "RescueResultId", "RescueResultName");
            ViewBag.DestinationId = new SelectList(db.Destinations.Where(c => c.IsUseForRescueRoom).OrderBy(c => c.Priority2), "DestinationId", "DestinationName");
            ViewBag.CriticalLevelId = new SelectList(db.CriticalLevels, "CriticalLevelId", "CriticalLevelName");
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName");
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName");

            ViewBag.PreviousObserveRoomInfoId = previousObserveRoomInfoId;

            return View(rescueRoomInfo);
        }

        /// <summary>
        /// 编辑。
        /// </summary>
        /// <param name="id">抢救室病例ID。</param>
        public ActionResult Edit(int id)
        {
            var db = new EiSDbContext();

            var target = db.RescueRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForRescueRoom), "BedId", "BedName", target.BedId);
            ViewBag.InRescueRoomWayId = new SelectList(db.InRescueRoomWays, "InRescueRoomWayId", "InRescueRoomWayName", target.InRescueRoomWayId);
            ViewBag.GreenPathCategoryId = new SelectList(db.GreenPathCategories, "GreenPathCategoryId", "GreenPathCategoryName", target.GreenPathCategoryId);
            ViewBag.RescueResultId = new SelectList(db.RescueResults, "RescueResultId", "RescueResultName", target.RescueResultId);
            ViewBag.DestinationId = new SelectList(db.Destinations.Where(c => c.IsUseForRescueRoom).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", target.DestinationId);
            ViewBag.CriticalLevelId = new SelectList(db.CriticalLevels, "CriticalLevelId", "CriticalLevelName", target.CriticalLevelId);
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", target.DestinationFirstId);
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", target.DestinationSecondId);

            return View(target);
        }

        /// <summary>
        /// 编辑 执行。
        /// </summary>
        /// <param name="rescueRoomInfo">提交实例。</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind()]RescueRoomInfo rescueRoomInfo)
        {
            var db = new EiSDbContext();

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
            //if (!db.InRescueRoomWays.Find(rescueRoomInfo.InRescueRoomWayId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.InRescueRoomWayRemarks))
            //    ModelState.AddModelError("InRescueRoomWayRemarks", "与入院方式不匹配。");
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
            //if (!db.GreenPathCategories.Find(rescueRoomInfo.GreenPathCategoryId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.GreenPathCategoryRemarks))
            //    ModelState.AddModelError("GreenPathCategoryRemarks", "与绿色通道病种不匹配。");
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
            //13-有预约次选科室，必须有预约首选科室。
            if (!db.Destinations.Find(rescueRoomInfo.DestinationSecondId).IsUseForEmpty && db.Destinations.Find(rescueRoomInfo.DestinationFirstId).IsUseForEmpty)
                ModelState.AddModelError("DestinationSecondId", "必须先填写预约首选科室。");
            //14-有离室时间，必须有去向。
            //if (rescueRoomInfo.IsLeave && db.Destinations.Find(rescueRoomInfo.DestinationId).IsUseForEmpty)
            //    ModelState.AddModelError("DestinationId", "离室时必填。");
            //15-有离室时间，必须有经手护士。
            //if (rescueRoomInfo.IsLeave && string.IsNullOrEmpty(rescueRoomInfo.HandleNurse))
            //    ModelState.AddModelError("HandleNurse", "离室时必填。");
            //16-离室时间必须不早于入室时间。
            if (rescueRoomInfo.OutDepartmentTime.HasValue && rescueRoomInfo.InDepartmentTime > rescueRoomInfo.OutDepartmentTime)
                ModelState.AddModelError("OutDepartmentTime", "不能早于入室时间。");
            //17-去向为允许附加数据才可以填写去向详细。
            //if (!db.Destinations.Find(rescueRoomInfo.DestinationId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.DestinationRemarks))
            //    ModelState.AddModelError("DestinationRemarks", "与去向不匹配。");
            //18-去向为允许附加数据,必须填写去向详细。
            if (db.Destinations.Find(rescueRoomInfo.DestinationId).IsHasAdditionalInfo && string.IsNullOrEmpty(rescueRoomInfo.DestinationRemarks))
                ModelState.AddModelError("DestinationRemarks", "必须有具体名称。");
            //19-有去向，必须有离室时间。
            if (!db.Destinations.Find(rescueRoomInfo.DestinationId).IsUseForEmpty && !rescueRoomInfo.OutDepartmentTime.HasValue)
                ModelState.AddModelError("OutDepartmentTime", "必须有离室时间。");
            //20-有去向，必须有经手护士。
            if (!db.Destinations.Find(rescueRoomInfo.DestinationId).IsUseForEmpty && string.IsNullOrEmpty(rescueRoomInfo.HandleNurse))
                ModelState.AddModelError("HandleNurse", "离室时必填。");

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

                Models.BusinessModels.TrasenInformationConvertor.FromEmployeeNumberToName(target);

                db.SaveChanges();

                return RedirectToAction("Details", new { id = rescueRoomInfo.RescueRoomInfoId });
            }

            ViewBag.BedId = new SelectList(db.Beds.Where(c => c.IsUseForRescueRoom), "BedId", "BedName", rescueRoomInfo.BedId);
            ViewBag.InRescueRoomWayId = new SelectList(db.InRescueRoomWays, "InRescueRoomWayId", "InRescueRoomWayName", rescueRoomInfo.InRescueRoomWayId);
            ViewBag.GreenPathCategoryId = new SelectList(db.GreenPathCategories, "GreenPathCategoryId", "GreenPathCategoryName", rescueRoomInfo.GreenPathCategoryId);
            ViewBag.RescueResultId = new SelectList(db.RescueResults, "RescueResultId", "RescueResultName", rescueRoomInfo.RescueResultId);
            ViewBag.DestinationId = new SelectList(db.Destinations.Where(c => c.IsUseForRescueRoom).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", rescueRoomInfo.DestinationId);
            ViewBag.CriticalLevelId = new SelectList(db.CriticalLevels, "CriticalLevelId", "CriticalLevelName", rescueRoomInfo.CriticalLevelId);
            ViewBag.DestinationFirstId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", rescueRoomInfo.DestinationFirstId);
            ViewBag.DestinationSecondId = new SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", rescueRoomInfo.DestinationSecondId);

            return View(rescueRoomInfo);
        }





        /// <summary>
        /// 眉栏。
        /// </summary>
        /// <param name="id">抢救室病例ID。</param>
        public ActionResult Header(int id)
        {
            var db = new EiSDbContext();

            var target = db.RescueRoomInfos.Find(id);
            if (target == null)
                return HttpNotFound();

            var targetV = new Header(target);

            return PartialView(targetV);
        }





        public JsonResult CheckInRescueRoomWayIdForIsHasAdditionalInfo(int id)
        {
            var db = new EiSDbContext();

            var target = db.InRescueRoomWays.Find(id);

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

        public JsonResult CheckGreenPathCategoryIdForIsHasAdditionalInfo(int id)
        {
            var db = new EiSDbContext();

            var target = db.GreenPathCategories.Find(id);

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