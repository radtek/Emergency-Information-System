using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Index
{
    /// <summary>
    /// 留观室——一览。
    /// </summary>
    public class Index
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Index"/> class.
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
        /// <param name="db">数据源。</param>
        public Index(DateTime? inTimeStart, DateTime? inTimeEnd, DateTime? outTimeStart, DateTime? outTimeEnd, bool? isLeave, string patientName, string outPatientNumber, int page, int perPage, EiSDbContext db)
        {
            var query = db.ObserveRoomInfos.AsEnumerable();

            if (inTimeStart != null)
                query = query.Where(c => inTimeStart.Value <= c.InDepartmentTime);
            if (inTimeEnd != null)
                query = query.Where(c => c.InDepartmentTime < inTimeEnd);
            if (outTimeStart != null)
                query = query.Where(c => outTimeStart.Value <= c.OutDepartmentTime);
            if (outTimeEnd != null)
                query = query.Where(c => c.OutDepartmentTime < outTimeEnd);
            if (isLeave != null)
                query = query.Where(c => c.IsLeave == isLeave);
            if (!string.IsNullOrEmpty(patientName))
                query = query.Where(c => c.PatientName == patientName);
            if (!string.IsNullOrEmpty(outPatientNumber))
                query = query.Where(c => c.OutPatientNumber == outPatientNumber);

            var queryCurrentPage = query.OrderByDescending(c => c.InDepartmentTime).ThenBy(c => c.ObserveRoomInfoId).Skip((page - 1) * perPage).Take(perPage);

            this.Route = new Route(inTimeStart, inTimeEnd, outTimeStart, outTimeEnd, isLeave, patientName, outPatientNumber, page, perPage, query.Count());

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