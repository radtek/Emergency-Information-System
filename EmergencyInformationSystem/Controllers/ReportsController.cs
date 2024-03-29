﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EmergencyInformationSystem.Models.Domains.Entities;

using EmergencyInformationSystem.Models.ViewModels.Reports.IndexRescueRoomHandOver;
using EmergencyInformationSystem.Models.ViewModels.Reports.IndexRescueRoomDay;
using EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomMonth;

using EmergencyInformationSystem.Models.ViewModels.Reports.IndexObserveRoomHandOver;
using EmergencyInformationSystem.Models.ViewModels.Reports.IndexObserveRoomDay;
using EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsObserveRoomMonth;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 报表控制器。
    /// </summary>
    public class ReportsController : Controller
    {
        /// <summary>
        /// 报表中心主界面。
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }





        /// <summary>
        /// 抢救室交班表。
        /// </summary>
        public ActionResult IndexRescueRoomHandOver()
        {
            var targetV = new IndexRescueRoomHandOver();

            return View(targetV);
        }





        /// <summary>
        /// 抢救室日报表。
        /// </summary>
        /// <param name="time">指定的日报表日期。只使用其中日期部分。</param>
        public ActionResult IndexRescueRoomDay(DateTime? time)
        {
            if (time == null)
                time = DateTime.Now;

            var targetV = new IndexRescueRoomDay(time.Value);

            return View(targetV);
        }





        /// <summary>
        /// 抢救室月报表。
        /// </summary>
        /// <param name="time">指定的月报表涵盖时间点，只使用其中日期部分。</param>
        public ActionResult StatisticsRescueRoomMonth(DateTime? time)
        {
            if (time == null)
                time = DateTime.Now;

            var targetV = new StatisticsRescueRoomMonth(time.Value);

            return View(targetV);
        }

        /// <summary>
        /// 抢救室统计项明细抢救项一览。
        /// </summary>
        /// <param name="time">指定的月报表涵盖时间点，只使用其中日期部分。</param>
        /// <param name="isRescue">是否抢救。</param>
        /// <param name="rescueResultId">抢救结果ID。</param>
        /// <param name="level">统计项级别。</param>
        public ActionResult StatisticsIndexRescueRoomRescue(DateTime time, bool isRescue, Guid? rescueResultId, int level)
        {
            var targetV = new Models.ViewModels.Reports.StatisticsIndexRescueRoomRescue.StatisticsIndexRescueRoomRescue(time, isRescue, rescueResultId, level);

            return View(targetV);
        }

        /// <summary>
        /// 抢救室统计项明细绿色通道项一览。
        /// </summary>
        /// <param name="time">指定的月报表涵盖时间点，只使用其中日期部分。</param>
        /// <param name="isGreenPath">是否绿色通道。</param>
        /// <param name="greenPathCategoryId">绿色通道类别ID。</param>
        /// <param name="greenPathCategoryRemarks">绿色通道明细。</param>
        /// <param name="level">统计项级别。</param>
        public ActionResult StatisticsIndexRescueRoomGreenPath(DateTime time, bool? isGreenPath, Guid? greenPathCategoryId, string greenPathCategoryRemarks, int level)
        {
            var targetV = new Models.ViewModels.Reports.StatisticsIndexRescueRoomGreenPath.StatisticsIndexRescueRoomGreenPath(time, isGreenPath, greenPathCategoryId, greenPathCategoryRemarks, level);

            return View(targetV);
        }

        /// <summary>
        /// 抢救室统计项明细时长项一览。
        /// </summary>
        /// <param name="time">指定的月报表涵盖时间点，只使用其中日期部分。</param>
        /// <param name="duringHours">时长。</param>
        /// <param name="duringMin">时长范围下界。</param>
        /// <param name="duringMax">时长范围上界。</param>
        /// <param name="level">统计项级别。</param>
        public ActionResult StatisticsIndexRescueRoomDuring(DateTime time, int? duringHours, int? duringMin, int? duringMax, int level)
        {
            var targetV = new Models.ViewModels.Reports.StatisticsIndexRescueRoomDuring.StatisticsIndexRescueRoomDuring(time, duringHours, duringMin, duringMax, level);

            return View(targetV);
        }

        /// <summary>
        /// 抢救室统计项明细去向项一览。
        /// </summary>
        /// <param name="time">指定的月报表涵盖时间点，只使用其中日期部分。</param>
        /// <param name="isClassifiedToInDepartment">是否分类为住院科室。</param>
        /// <param name="isClassifiedToOutDepartment">是否分类为门诊科室。</param>
        /// <param name="isClassifiedLeave">是否分类为离开。</param>
        /// <param name="isClassifiedToOther">是否分类为其他。</param>
        /// <param name="destinationId">去向ID。</param>
        /// <param name="destinationRemarks">去向明细。</param>
        /// <param name="level">统计项级别。</param>
        public ActionResult StatisticsIndexRescueRoomDestination(DateTime time, bool? isClassifiedToInDepartment, bool? isClassifiedToOutDepartment, bool? isClassifiedLeave, bool? isClassifiedToOther, Guid? destinationId, string destinationRemarks, int level)
        {
            var targetV = new Models.ViewModels.Reports.StatisticsIndexRescueRoomDestination.StatisticsIndexRescueRoomDestination(time, isClassifiedToInDepartment, isClassifiedToOutDepartment, isClassifiedLeave, isClassifiedToOther, destinationId, destinationRemarks, level);

            return View(targetV);
        }





        public ActionResult StatisticsRescueRoomGeneral(DateTime? start, DateTime? end)
        {
            if (!start.HasValue)
                start = DateTime.Today;
            if (!end.HasValue)
                end = DateTime.Today.AddDays(1);

            var targetV = new Models.ViewModels.Reports.StatisticsRescueRoomGeneral.StatisticsRescueRoomGeneral(start.Value, end.Value);

            return View(targetV);
        }

        public ActionResult StatisticsIndexRescueRoomGeneral(DateTime start, DateTime end, bool? isRescue, Guid? rescueResultId, Guid? inRescueRoomWayId, bool? inRescueRoomWayIsHasAdditionalInfo, string inRescueRoomWayRemarks, Guid? destinationId, bool? destinationIsHasAdditionalInfo, string destinationRemarks, bool? destinationIsTransfer, string transferTarget, bool? destinationIsProfessional, string professionalTarget)
        {
            var targetV = new Models.ViewModels.Reports.StatisticsIndexRescueRoomGeneral.StatisticsIndexRescueRoomGeneral(start, end, isRescue, rescueResultId, inRescueRoomWayId, inRescueRoomWayIsHasAdditionalInfo, inRescueRoomWayRemarks, destinationId, destinationIsHasAdditionalInfo, destinationRemarks, destinationIsTransfer, transferTarget, destinationIsProfessional, professionalTarget);

            return View(targetV);
        }





        /// <summary>
        /// 留观室交班表。
        /// </summary>
        public ActionResult IndexObserveRoomHandOver()
        {
            var targetV = new IndexObserveRoomHandOver();

            return View(targetV);
        }





        /// <summary>
        /// 留观室日报表。
        /// </summary>
        /// <param name="time">指定的日报表日期。只使用其中日期部分。</param>
        public ActionResult IndexObserveRoomDay(DateTime? time)
        {
            if (time == null)
                time = DateTime.Now;

            var targetV = new IndexObserveRoomDay(time.Value);

            return View(targetV);
        }





        /// <summary>
        /// 留观室月报表。
        /// </summary>
        /// <param name="time">指定的月报表涵盖时间点，只使用其中日期部分。</param>
        public ActionResult StatisticsObserveRoomMonth(DateTime? time)
        {
            if (time == null)
                time = DateTime.Now;

            var targetV = new StatisticsObserveRoomMonth(time.Value);

            return View(targetV);
        }

        /// <summary>
        /// 留观室统计项明细时长项一览。
        /// </summary>
        /// <param name="time">指定的月报表涵盖时间点，只使用其中日期部分。</param>
        /// <param name="duringHours">时长。</param>
        /// <param name="duringMin">时长范围下界。</param>
        /// <param name="duringMax">时长范围上界。</param>
        /// <param name="level">统计项级别。</param>
        public ActionResult StatisticsIndexObserveRoomDuring(DateTime time, int? duringHours, int? duringMin, int? duringMax, int level)
        {
            var targetV = new Models.ViewModels.Reports.StatisticsIndexObserveRoomDuring.StatisticsIndexObserveRoomDuring(time, duringHours, duringMin, duringMax, level);

            return View(targetV);
        }

        /// <summary>
        /// 留观室统计项明细去向项一览。
        /// </summary>
        /// <param name="time">指定的月报表涵盖时间点，只使用其中日期部分。</param>
        /// <param name="isClassifiedToInDepartment">是否分类为住院科室。</param>
        /// <param name="isClassifiedToOutDepartment">是否分类为门诊科室。</param>
        /// <param name="isClassifiedLeave">是否分类为离开。</param>
        /// <param name="isClassifiedToOther">是否分类为其他。</param>
        /// <param name="destinationId">去向ID。</param>
        /// <param name="destinationRemarks">去向明细。</param>
        /// <param name="level">统计项级别。</param>
        public ActionResult StatisticsIndexObserveRoomDestination(DateTime time, bool? isClassifiedToInDepartment, bool? isClassifiedToOutDepartment, bool? isClassifiedLeave, bool? isClassifiedToOther, Guid? destinationId, string destinationRemarks, int level)
        {
            var targetV = new Models.ViewModels.Reports.StatisticsIndexObserveRoomDestination.StatisticsIndexObserveRoomDestination(time, isClassifiedToInDepartment, isClassifiedToOutDepartment, isClassifiedLeave, isClassifiedToOther, destinationId, destinationRemarks, level);

            return View(targetV);
        }





        public ActionResult IndexSubscription()
        {
            var targetV = new Models.ViewModels.Reports.IndexSubscription.IndexSubscription();

            return View(targetV);
        }
    }
}