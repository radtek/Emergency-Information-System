using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TrasenLib;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 抢救室会诊项控制器。
    /// </summary>
    public class RescueRoomConsultationsController : Controller
    {
        /// <summary>
        /// 一览。
        /// </summary>
        /// <param name="rescueRoomInfoId">归属的抢救室病例ID。</param>
        public ActionResult IndexPartial(int rescueRoomInfoId)
        {
            var db = new EiSDbContext();

            var target = db.RescueRoomInfos.Find(rescueRoomInfoId);
            if (target == null)
                return null;

            var query = target.RescueRoomConsultations.OrderBy(c => c.RequestTime).ToList();

            return PartialView(query);
        }

        /// <summary>
        /// 新增。
        /// </summary>
        /// <param name="rescueRoomInfoId">归属的抢救室病例ID。</param>
        /// <param name="goToGreenPath">指定跳转到绿色通道表单。（后续参数忽略）</param>
        public ActionResult Create(int rescueRoomInfoId, bool goToGreenPath = false)
        {
            var db = new EiSDbContext();

            var rescueRoomInfo = db.RescueRoomInfos.Find(rescueRoomInfoId);
            if (rescueRoomInfo == null)
                return HttpNotFound();

            var target = new RescueRoomConsultation();

            target.RescueRoomInfoId = rescueRoomInfoId;
            target.RequestTime = DateTime.Today;

            ViewBag.GoToGreenPath = goToGreenPath; //不添加视图模型的情况下实现。

            ViewBag.ConsultationDepartmentId = new SelectList(db.Destinations.Where(c => c.IsUseForConsultation).OrderBy(c => c.Priority2), "DestinationId", "DestinationName");

            return View(target);
        }

        /// <summary>
        /// 新增 执行。
        /// </summary>
        /// <param name="rescueRoomConsultation">提交实例。</param>
        /// <param name="goToGreenPath">指定跳转到绿色通道表单。（后续参数忽略）</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind()]RescueRoomConsultation rescueRoomConsultation, bool goToGreenPath = false)
        {
            var db = new EiSDbContext();

            //1.会诊到达时间不可早于会诊申请时间。
            if (rescueRoomConsultation.ArriveTime.HasValue && rescueRoomConsultation.ArriveTime.Value < rescueRoomConsultation.RequestTime)
                ModelState.AddModelError("ArriveTime", "不可早于申请时间。");
            //2.科室不能为空。
            if(db.Destinations.Find(rescueRoomConsultation.ConsultationDepartmentId).IsUseForEmpty)
                ModelState.AddModelError("ConsultationDepartmentId", "不可为空。");

            if (ModelState.IsValid)
            {
                rescueRoomConsultation.RescueRoomConsultationId = Guid.NewGuid();
                rescueRoomConsultation.UpdateTime = DateTime.Now;

                Models.BusinessModels.TrasenInformationConvertor.FromEmployeeNumberToName(rescueRoomConsultation);

                db.RescueRoomConsultations.Add(rescueRoomConsultation);
                db.SaveChanges();

                //处理返回页面
                if (goToGreenPath == true)
                {
                    var rescueRoomInfo = db.RescueRoomInfos.Find(rescueRoomConsultation.RescueRoomInfoId);

                    return RedirectToAction(rescueRoomInfo.GreenPathActionName, "GreenPaths", new { id = rescueRoomInfo.GreenPathId });
                }

                return RedirectToAction("Details", "RescueRoomInfos", new { id = rescueRoomConsultation.RescueRoomInfoId });
            }

            ViewBag.GoToGreenPath = goToGreenPath; //不添加视图模型的情况下实现。

            ViewBag.ConsultationDepartmentId = new SelectList(db.Destinations.Where(c => c.IsUseForConsultation).OrderBy(c => c.Priority2), "DestinationId", "DestinationName");

            return View(rescueRoomConsultation);
        }

        /// <summary>
        /// 编辑。
        /// </summary>
        /// <param name="id">会诊项ID。</param>
        /// <param name="goToGreenPath">指定跳转到绿色通道表单。（后续参数忽略）</param>
        public ActionResult Edit(Guid id, bool goToGreenPath = false)
        {
            var db = new EiSDbContext();

            var target = db.RescueRoomConsultations.Find(id);
            if (target == null)
                return HttpNotFound();

            ViewBag.GoToGreenPath = goToGreenPath;

            ViewBag.ConsultationDepartmentId = new SelectList(db.Destinations.Where(c => c.IsUseForConsultation).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", target.ConsultationDepartmentId);

            return View(target);
        }

        /// <summary>
        /// 编辑 执行。
        /// </summary>
        /// <param name="rescueRoomConsultation">提交实例。</param>
        /// <param name="goToGreenPath">指定跳转到绿色通道表单。（后续参数忽略）</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind()]RescueRoomConsultation rescueRoomConsultation, bool goToGreenPath = false)
        {
            var db = new EiSDbContext();

            //1.会诊到达时间不可早于会诊申请时间。
            if (rescueRoomConsultation.ArriveTime.HasValue && rescueRoomConsultation.ArriveTime.Value < rescueRoomConsultation.RequestTime)
                ModelState.AddModelError("ArriveTime", "不可早于申请时间。");
            //2.科室不能为空。
            if (db.Destinations.Find(rescueRoomConsultation.ConsultationDepartmentId).IsUseForEmpty)
                ModelState.AddModelError("ConsultationDepartmentId", "不可为空。");

            if (ModelState.IsValid)
            {
                var target = db.RescueRoomConsultations.Find(rescueRoomConsultation.RescueRoomConsultationId);

                target.ArriveTime = rescueRoomConsultation.ArriveTime;
                target.RequestTime = rescueRoomConsultation.RequestTime;
                target.ConsultationDoctorName = rescueRoomConsultation.ConsultationDoctorName;
                target.ConsultationDepartmentId = rescueRoomConsultation.ConsultationDepartmentId;

                target.UpdateTime = DateTime.Now;

                Models.BusinessModels.TrasenInformationConvertor.FromEmployeeNumberToName(target);

                db.SaveChanges();

                //处理返回页面
                if (goToGreenPath == true)
                {
                    var rescueRoomInfo = db.RescueRoomInfos.Find(rescueRoomConsultation.RescueRoomInfoId);

                    return RedirectToAction(rescueRoomInfo.GreenPathActionName, "GreenPaths", new { id = rescueRoomInfo.GreenPathId });
                }

                return RedirectToAction("Details", "RescueRoomInfos", new { id = rescueRoomConsultation.RescueRoomInfoId });
            }

            ViewBag.GoToGreenPath = goToGreenPath; //不添加视图模型的情况下实现。

            ViewBag.ConsultationDepartmentId = new SelectList(db.Destinations.Where(c => c.IsUseForConsultation).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", rescueRoomConsultation.ConsultationDepartmentId);

            return View(rescueRoomConsultation);
        }        
    }
}