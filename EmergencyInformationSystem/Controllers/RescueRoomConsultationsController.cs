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
        /// Initializes a new instance of the <see cref="RescueRoomConsultationsController"/> class.
        /// </summary>
        public RescueRoomConsultationsController()
        {
            this.db = new EiSDbContext();
        }





        /// <summary>
        /// EiS数据上下文。
        /// </summary>
        private EiSDbContext db;





        /// <summary>
        /// 未实现。
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 一览——嵌入。
        /// </summary>
        /// <param name="rescueRoomInfoId">归属的抢救室病例ID。</param>
        public ActionResult IndexPartial(int rescueRoomInfoId)
        {
            var target = this.db.RescueRoomInfos.Find(rescueRoomInfoId);
            if (target == null)
                return null;

            var query = target.RescueRoomConsultations.OrderBy(c => c.RequestTime).AsEnumerable();

            return PartialView(query);
        }

        /// <summary>
        /// 新增。
        /// </summary>
        /// <param name="rescueRoomInfoId">归属的抢救室病例ID。</param>
        /// <param name="goToGreenPath">为<c>true</c>时跳转到绿色通道表单。（后续参数忽略）</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Create(int rescueRoomInfoId, bool goToGreenPath = false)
        {
            var rescueRoomInfo = this.db.RescueRoomInfos.Find(rescueRoomInfoId);
            if (rescueRoomInfo == null)
                return HttpNotFound();

            var target = new RescueRoomConsultation();

            target.RescueRoomInfoId = rescueRoomInfoId;
            target.RequestTime = DateTime.Today;

            ViewBag.GoToGreenPath = goToGreenPath; //不添加视图模型的情况下实现。

            ViewBag.ConsultationDepartmentId = new SelectList(this.db.Destinations.Where(c => c.IsUseForConsultation), "DestinationId", "DestinationName");

            return View(target);
        }

        /// <summary>
        /// 新增——执行。
        /// </summary>
        /// <param name="rescueRoomConsultation">提交实例。</param>
        /// <param name="goToGreenPath">为<c>true</c>时跳转到绿色通道表单。（后续参数忽略）</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind()]RescueRoomConsultation rescueRoomConsultation, bool goToGreenPath = false)
        {
            if (rescueRoomConsultation.ArriveTime.HasValue && rescueRoomConsultation.ArriveTime.Value < rescueRoomConsultation.RequestTime)
                ModelState.AddModelError("ArriveTime", "不可早于申请时间。");

            if (ModelState.IsValid)
            {
                rescueRoomConsultation.RescueRoomConsultationId = Guid.NewGuid();
                rescueRoomConsultation.UpdateTime = DateTime.Now;

                this.db.RescueRoomConsultations.Add(rescueRoomConsultation);
                this.db.SaveChanges();

                //处理返回页面
                if (goToGreenPath == true)
                {
                    var rescueRoomInfo = this.db.RescueRoomInfos.Find(rescueRoomConsultation.RescueRoomInfoId);

                    return RedirectToAction(rescueRoomInfo.GreenPathActionName, "GreenPaths", new { id = rescueRoomInfo.GreenPathId });
                }

                return RedirectToAction("Details", "RescueRoomInfos", new { id = rescueRoomConsultation.RescueRoomInfoId });
            }

            ViewBag.GoToGreenPath = goToGreenPath; //不添加视图模型的情况下实现。

            ViewBag.ConsultationDepartmentId = new SelectList(this.db.Destinations.Where(c => c.IsUseForConsultation), "DestinationId", "DestinationName");

            return View(rescueRoomConsultation);
        }

        /// <summary>
        /// 编辑。
        /// </summary>
        /// <param name="id">主ID。</param>
        /// <param name="goToGreenPath">为<c>true</c>时跳转到绿色通道表单。（后续参数忽略）</param>
        public ActionResult Edit(Guid id, bool goToGreenPath = false)
        {
            var target = this.db.RescueRoomConsultations.Find(id);
            if (target == null)
                return HttpNotFound();

            ViewBag.GoToGreenPath = goToGreenPath; //不添加视图模型的情况下实现。

            ViewBag.ConsultationDepartmentId = new SelectList(this.db.Destinations.Where(c => c.IsUseForConsultation), "DestinationId", "DestinationName", target.ConsultationDepartmentId);

            return View(target);
        }

        /// <summary>
        /// 编辑——执行。
        /// </summary>
        /// <param name="rescueRoomConsultation">提交实例。</param>
        /// <param name="goToGreenPath">为<c>true</c>时跳转到绿色通道表单。（后续参数忽略）</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind()]RescueRoomConsultation rescueRoomConsultation, bool goToGreenPath = false)
        {
            if (rescueRoomConsultation.ArriveTime.HasValue && rescueRoomConsultation.ArriveTime.Value < rescueRoomConsultation.RequestTime)
                ModelState.AddModelError("ArriveTime", "不可早于申请时间。");

            if (ModelState.IsValid)
            {
                var target = this.db.RescueRoomConsultations.Find(rescueRoomConsultation.RescueRoomConsultationId);

                target.ArriveTime = rescueRoomConsultation.ArriveTime;
                target.RequestTime = rescueRoomConsultation.RequestTime;
                target.ConsultationDoctorName = rescueRoomConsultation.ConsultationDoctorName;
                target.ConsultationDepartmentId = rescueRoomConsultation.ConsultationDepartmentId;

                target.UpdateTime = DateTime.Now;

                this.db.SaveChanges();

                //处理返回页面
                if (goToGreenPath == true)
                {
                    var rescueRoomInfo = this.db.RescueRoomInfos.Find(rescueRoomConsultation.RescueRoomInfoId);

                    return RedirectToAction(rescueRoomInfo.GreenPathActionName, "GreenPaths", new { id = rescueRoomInfo.GreenPathId });
                }

                return RedirectToAction("Details", "RescueRoomInfos", new { id = rescueRoomConsultation.RescueRoomInfoId });
            }

            ViewBag.GoToGreenPath = goToGreenPath; //不添加视图模型的情况下实现。

            ViewBag.ConsultationDepartmentId = new SelectList(this.db.Destinations.Where(c => c.IsUseForConsultation), "DestinationId", "DestinationName", rescueRoomConsultation.ConsultationDepartmentId);

            return View(rescueRoomConsultation);
        }
    }
}