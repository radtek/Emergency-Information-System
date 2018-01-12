using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Index
{
    /// <summary>
    /// 导航。
    /// </summary>
    public class Route : RouteBase
    {
        /// <summary>
        /// 初始化。
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
        /// <param name="perpage">每页项目数。</param>
        /// <param name="count">项目总数。</param>
        public Route(DateTime? inDepartmentTimeStart, DateTime? inDepartmentTimeEnd, DateTime? outDepartmentTimeStart, DateTime? outDepartmentTimeEnd, Guid? greenPathCategoryId, bool? isRescue, bool? isLeave, string patientName, string outPatientNumber, Guid? inRescueRoomWayId, Guid? destinationId, int page, int perpage, int count) : base(page, perpage, count)
        {
            this.InDepartmentTimeStart = inDepartmentTimeStart;
            this.InDepartmentTimeEnd = inDepartmentTimeEnd;
            this.OutDepartmentTimeStart = outDepartmentTimeStart;
            this.OutDepartmentTimeEnd = outDepartmentTimeEnd;
            this.GreenPathCategoryId = greenPathCategoryId;
            this.IsRescue = isRescue;
            this.IsLeave = isLeave;
            this.PatientName = patientName;
            this.OutPatientNumber = outPatientNumber;
            this.InRescueRoomWayId = inRescueRoomWayId;
            this.DestinationId = destinationId;
        }

        /// <summary>
        /// 初始化。
        /// </summary>
        public Route() : base(0, 0, 0)
        {

        }





        [Display(Name = "入室时间起点")]
        public DateTime? InDepartmentTimeStart { get; set; }

        [Display(Name = "入室时间结点")]
        public DateTime? InDepartmentTimeEnd { get; set; }

        [Display(Name = "离室时间起点")]
        public DateTime? OutDepartmentTimeStart { get; set; }

        [Display(Name = "离室时间结点")]
        public DateTime? OutDepartmentTimeEnd { get; set; }

        [Display(Name = "绿色通道")]
        public Guid? GreenPathCategoryId { get; set; }

        [Display(Name = "抢救")]
        public bool? IsRescue { get; set; }

        [Display(Name = "离室")]
        public bool? IsLeave { get; set; }

        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        [Display(Name = "入室方式")]
        public Guid? InRescueRoomWayId { get; set; }

        [Display(Name = "去向")]
        public Guid? DestinationId { get; set; }





        /// <summary>
        /// 获取指定页码导航。
        /// </summary>
        /// <param name="page">页码。</param>
        /// <returns>指定页码的、其余字段不变的导航对象。</returns>
        public Route GetRoute(int page)
        {
            return new Route(this.InDepartmentTimeStart, this.InDepartmentTimeEnd, this.OutDepartmentTimeStart, this.OutDepartmentTimeEnd, this.GreenPathCategoryId, this.IsRescue, this.IsLeave, this.PatientName, this.OutPatientNumber, this.InRescueRoomWayId, this.DestinationId, page, this.PerPage, this.Count);
        }
    }
}