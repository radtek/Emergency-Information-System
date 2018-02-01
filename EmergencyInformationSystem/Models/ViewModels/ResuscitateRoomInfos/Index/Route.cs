using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.ResuscitateRoomInfos.Index
{
    public class Route : RouteBase
    {
        public Route(DateTime? inDepartmentTimeStart, DateTime? inDepartmentTimeEnd, DateTime? outDepartmentTimeStart, DateTime? outDepartmentTimeEnd, Guid? greenPathCategoryId, bool? isRescue, bool? isLeave, string patientName, string outPatientNumber, Guid? inRoomWayId, Guid? destinationId, int page, int perpage, int count) : base(page, perpage, count)
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
            this.InRoomWayId = inRoomWayId;
            this.DestinationId = destinationId;
        }

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
        public Guid? InRoomWayId { get; set; }

        [Display(Name = "去向")]
        public Guid? DestinationId { get; set; }





        public Route GetRoute(int page)
        {
            return new Route(this.InDepartmentTimeStart, this.InDepartmentTimeEnd, this.OutDepartmentTimeStart, this.OutDepartmentTimeEnd, this.GreenPathCategoryId, this.IsRescue, this.IsLeave, this.PatientName, this.OutPatientNumber, this.InRoomWayId, this.DestinationId, page, this.PerPage, this.Count);
        }
    }
}