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
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="rescueRoomInfo">原留观室病例。</param>
        public Item(ObserveRoomInfo observeRoomInfo)
        {
            this.ObserveRoomInfoId = observeRoomInfo.ObserveRoomInfoId;
            this.IsLeave = observeRoomInfo.IsLeave;

            this.PatientName = observeRoomInfo.PatientName;
            this.OutPatientNumber = observeRoomInfo.OutPatientNumber;
            this.DiagnosisNameOrigin = observeRoomInfo.DiagnosisNameOrigin;
            this.FirstDoctorName = observeRoomInfo.FirstDoctorName;
            this.InDepartmentTime = observeRoomInfo.InDepartmentTime;
            this.OutDepartmentTime = observeRoomInfo.OutDepartmentTime;
            this.During = observeRoomInfo.During;
            this.DestinationName = observeRoomInfo.Destination.DestinationName;
            this.DiagnosisName = observeRoomInfo.DiagnosisName;
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