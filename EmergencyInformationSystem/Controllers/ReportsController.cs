using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EmergencyInformationSystem.Models.Domains.Entities;
using EmergencyInformationSystem.Models.ViewModels.Reports.IndexHandOver;
using EmergencyInformationSystem.Models.ViewModels.Reports.IndexDay;
using EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsMonth;
using EmergencyInformationSystem.Models.ViewModels.Reports.IndexRescue;
using EmergencyInformationSystem.Models.ViewModels.Reports.IndexGreenPath;
using EmergencyInformationSystem.Models.ViewModels.Reports.IndexDuring;
using EmergencyInformationSystem.Models.ViewModels.Reports.IndexDestination;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 报表控制器。
    /// </summary>
    public class ReportsController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportsController"/> class.
        /// </summary>
        public ReportsController()
        {
            db = new EiSDbContext();
        }





        /// <summary>
        /// EiS数据上下文。
        /// </summary>
        private EiSDbContext db;





        /// <summary>
        /// 报表中心主界面。
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }





        /// <summary>
        /// 交班表。
        /// </summary>
        public ActionResult IndexHandOver()
        {
            var targetV = new IndexHandOver(db);

            return View(targetV);
        }





        /// <summary>
        /// 日报表。
        /// </summary>
        /// <param name="time">指定的时间。只使用其中日期部分。</param>
        public ActionResult IndexDay(DateTime? time)
        {
            if (time == null)
                time = DateTime.Now;

            var targetV = new IndexDay(time.Value, db);

            return View(targetV);
        }





        /// <summary>
        /// 月报表。
        /// </summary>
        /// <param name="time">指定的时间，只使用其中日期部分。</param>
        public ActionResult StatisticsMonth(DateTime? time)
        {
            if (time == null)
                time = DateTime.Now;

            var targetV = new StatisticsMonth(time.Value, db);

            return View(targetV);
        }

        /// <summary>
        /// 月报表抢救项表。
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="isRescue">if set to <c>true</c> [is rescue].</param>
        /// <param name="rescueResultId">The rescue result identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult IndexRescue(DateTime time, bool isRescue, int? rescueResultId)
        {
            var targetV = new IndexRescue(time, isRescue, rescueResultId, db);

            return View(targetV);
        }

        /// <summary>
        /// 月报表绿色通道项表。
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="isGreenPath">if set to <c>true</c> [is green path].</param>
        /// <param name="greenPathCategoryId">The green path category identifier.</param>
        /// <param name="greenPathCategoryRemarks">The green path category remarks.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult IndexGreenPath(DateTime time, bool? isGreenPath, int? greenPathCategoryId, string greenPathCategoryRemarks)
        {
            var targetV = new IndexGreenPath(time, isGreenPath, greenPathCategoryId, greenPathCategoryRemarks, db);

            return View(targetV);
        }

        /// <summary>
        /// Indexes the during.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="duringHours">The during hours.</param>
        /// <param name="duringMin">The during minimum.</param>
        /// <param name="duringMax">The during maximum.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult IndexDuring(DateTime time, int? duringHours, int? duringMin, int? duringMax)
        {
            var targetV = new IndexDuring(time, duringHours, duringMin, duringMax, db);

            return View(targetV);
        }

        /// <summary>
        /// Indexes the destination.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="isClassifiedToInDepartment">if set to <c>true</c> [is classified to in department].</param>
        /// <param name="isClassifiedToOutDepartment">if set to <c>true</c> [is classified to out department].</param>
        /// <param name="isClassifiedLeave">if set to <c>true</c> [is classified leave].</param>
        /// <param name="isClassifiedToOther">if set to <c>true</c> [is classified to other].</param>
        /// <param name="destinationId">The destination identifier.</param>
        /// <param name="destinationRemarks">The destination remarks.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult IndexDestination(DateTime time, bool? isClassifiedToInDepartment, bool? isClassifiedToOutDepartment, bool? isClassifiedLeave, bool? isClassifiedToOther, int? destinationId, string destinationRemarks)
        {
            var targetV = new IndexDestination(time, isClassifiedToInDepartment, isClassifiedToOutDepartment, isClassifiedLeave, isClassifiedToOther, destinationId, destinationRemarks, db);

            return View(targetV);
        }
    }
}