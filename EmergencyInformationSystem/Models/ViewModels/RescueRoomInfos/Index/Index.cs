using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Index
{
    /// <summary>
    /// 抢救室——一览。
    /// </summary>
    public class Index
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Index"/> class.
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
        /// <param name="inRescueRoomWayId">入室方式ID。</param>
        /// <param name="destinationId">去向ID。</param>
        /// <param name="page">页码。</param>
        /// <param name="perPage">每页项目数。</param>
        public Index(DateTime? inDepartmentTimeStart, DateTime? inDepartmentTimeEnd, DateTime? outDepartmentTimeStart, DateTime? outDepartmentTimeEnd, int? greenPathCategoryId, bool? isRescue, bool? isLeave, string patientName, string outPatientNumber, int? inRescueRoomWayId, int? destinationId, int page, int perPage)
        {
            var db = new EiSDbContext();

            var query = db.RescueRoomInfos.AsQueryable();

            if (inDepartmentTimeStart != null)
                query = query.Where(c => inDepartmentTimeStart.Value <= c.InDepartmentTime);
            if (inDepartmentTimeEnd != null)
                query = query.Where(c => c.InDepartmentTime < inDepartmentTimeEnd);
            if (outDepartmentTimeStart != null)
                query = query.Where(c => outDepartmentTimeStart.Value <= c.OutDepartmentTime);
            if (outDepartmentTimeEnd != null)
                query = query.Where(c => c.OutDepartmentTime < outDepartmentTimeEnd);
            if (greenPathCategoryId != null)
                query = query.Where(c => c.GreenPathCategoryId == greenPathCategoryId);
            if (isRescue != null)
                query = query.Where(c => c.IsRescue == isRescue);
            if (isLeave != null)
                query = query.Where(c => c.OutDepartmentTime.HasValue == isLeave);
            if (!string.IsNullOrEmpty(patientName))
                query = query.Where(c => c.PatientName == patientName);
            if (!string.IsNullOrEmpty(outPatientNumber))
                query = query.Where(c => c.OutPatientNumber == outPatientNumber);
            if (inRescueRoomWayId != null)
                query = query.Where(c => c.InRescueRoomWayId == inRescueRoomWayId);
            if (destinationId != null)
                query = query.Where(c => c.DestinationId == destinationId);

            var queryCurrentPage = query.OrderByDescending(c => c.InDepartmentTime).ThenBy(c => c.RescueRoomInfoId).Skip((page - 1) * perPage).Take(perPage);

            this.Route = new Route(inDepartmentTimeStart, inDepartmentTimeEnd, outDepartmentTimeStart, outDepartmentTimeEnd, greenPathCategoryId, isRescue, isLeave, patientName, outPatientNumber, inRescueRoomWayId, destinationId, page, perPage, query.Count());

            this.List = queryCurrentPage.ToList().Select(c => new Item(c)).ToList();
        }





        /// <summary>
        /// 导航。
        /// </summary>
        public Route Route { get; set; }





        /// <summary>
        /// 列表项。
        /// </summary>
        public List<Item> List { get; set; }
    }
}