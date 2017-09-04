using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexObserveRoomDay
{
    /// <summary>
    /// 留观室日报表列表项。
    /// </summary>
    public class Item
    {
        public Item(ObserveRoomInfo target)
        {
            this.ObserveRoomInfoId = target.ObserveRoomInfoId;
            this.IsLeave = target.OutDepartmentTime.HasValue;

            this.PatientName = target.PatientName;
            this.OutPatientNumber = target.OutPatientNumber;
            this.DiagnosisNameOrigin = target.DiagnosisNameOrigin;
            this.FirstDoctorName = target.FirstDoctorName;
            this.InDepartmentTime = target.InDepartmentTime;
            this.OutDepartmentTime = target.OutDepartmentTime;
            this.During = target.During;
            this.DestinationName = target.Destination.DestinationName;
            this.DiagnosisName = target.DiagnosisName;
        }





        public Guid ObserveRoomInfoId { get; set; }

        public bool IsLeave { get; set; }





        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        [Display(Name = "入室诊断名称")]
        public string DiagnosisNameOrigin { get; set; }

        [Display(Name = "首诊医师")]
        public string FirstDoctorName { get; set; }

        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }

        [Display(Name = "离室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? OutDepartmentTime { get; set; }

        [Display(Name = "停留时长")]
        public TimeSpan? During { get; set; }

        [Display(Name = "去向")]
        public string DestinationName { get; set; }

        [Display(Name = "离室诊断名称")]
        public string DiagnosisName { get; set; }
    }
}