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
        public ActionResult IndexPartial(Guid rescueRoomInfoId)
        {
            var targetV = new Models.ViewModels.RescueRoomConsultations.IndexPartial.IndexPartial(rescueRoomInfoId);

            return PartialView(targetV);
        }

        /// <summary>
        /// 新增。
        /// </summary>
        /// <param name="rescueRoomInfoId">归属的抢救室病例ID。</param>
        /// <param name="goToGreenPath">指定跳转到绿色通道表单。（后续参数忽略）</param>
        public ActionResult Create(Guid rescueRoomInfoId, bool goToGreenPath = false)
        {
            var db = new EiSDbContext();

            var rescueRoomInfo = db.RescueRoomInfos.Find(rescueRoomInfoId);
            if (rescueRoomInfo == null)
                return HttpNotFound();

            var targetV = new Models.ViewModels.RescueRoomConsultations.Create.Create();
            var targetW = new Models.ViewModels.RescueRoomConsultations.Create.SelectionWorker(targetV);

            targetV.RescueRoomInfoId = rescueRoomInfoId;
            targetV.RequestTime = DateTime.Today;
            targetV.GoToGreenPath = goToGreenPath;

            ViewBag.ConsultationDepartmentId = targetW.ConsultationDepartments;

            return View(targetV);
        }

        /// <summary>
        /// 新增 执行。
        /// </summary>
        /// <param name="rescueRoomConsultation">提交实例。</param>
        /// <param name="goToGreenPath">指定跳转到绿色通道表单。（后续参数忽略）</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind()]Models.ViewModels.RescueRoomConsultations.Create.Create targetV)
        {
            if (ModelState.IsValid)
            {
                var db = new EiSDbContext();

                var target = targetV.GetReturn();

                Models.BusinessModels.TrasenInformationConvertor.FromEmployeeNumberToName(target);

                db.RescueRoomConsultations.Add(target);
                db.SaveChanges();

                //处理返回页面
                if (targetV.GoToGreenPath == true)
                {
                    var rescueRoomInfo = db.RescueRoomInfos.Find(targetV.RescueRoomInfoId);

                    return RedirectToAction(rescueRoomInfo.GreenPathActionName, "GreenPaths", new { id = rescueRoomInfo.GreenPathId });
                }

                return RedirectToAction("Details", "RescueRoomInfos", new { id = targetV.RescueRoomInfoId });
            }

            var targetW = new Models.ViewModels.RescueRoomConsultations.Create.SelectionWorker(targetV);
            ViewBag.ConsultationDepartmentId = targetW.ConsultationDepartments;

            return View(targetV);
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

            var targetV = new Models.ViewModels.RescueRoomConsultations.Edit.Edit(target, goToGreenPath);
            var targetW = new Models.ViewModels.RescueRoomConsultations.Edit.SelectionWorker(targetV);

            ViewBag.ConsultationDepartmentId = targetW.ConsultationDepartments;

            return View(targetV);
        }

        /// <summary>
        /// 编辑 执行。
        /// </summary>
        /// <param name="rescueRoomConsultation">提交实例。</param>
        /// <param name="goToGreenPath">指定跳转到绿色通道表单。（后续参数忽略）</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind()]Models.ViewModels.RescueRoomConsultations.Edit.Edit targetV)
        {
            if (ModelState.IsValid)
            {
                var db = new Models.Domains.Entities.EiSDbContext();
                var target = db.RescueRoomConsultations.Find(targetV.RescueRoomConsultationId);

                targetV.GetReturn(target);

                Models.BusinessModels.TrasenInformationConvertor.FromEmployeeNumberToName(target);

                db.SaveChanges();

                //处理返回页面
                if (targetV.GoToGreenPath)
                {
                    var rescueRoomInfo = db.RescueRoomInfos.Find(targetV.RescueRoomInfoId);

                    return RedirectToAction(rescueRoomInfo.GreenPathActionName, "GreenPaths", new { id = rescueRoomInfo.GreenPathId });
                }

                return RedirectToAction("Details", "RescueRoomInfos", new { id = targetV.RescueRoomInfoId });
            }

            var targetW = new Models.ViewModels.RescueRoomConsultations.Edit.SelectionWorker(targetV);

            ViewBag.ConsultationDepartmentId = targetW.ConsultationDepartments;

            return View(targetV);
        }
    }
}