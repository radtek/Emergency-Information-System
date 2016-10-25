using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexDay
{
    /// <summary>
    /// 日报表列表项。
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="rescueRoomInfo">抢救室病例。</param>
        public Item(RescueRoomInfo rescueRoomInfo)
        {
            this.RescueRoomInfoId = rescueRoomInfo.RescueRoomInfoId;
            this.IsLeave = rescueRoomInfo.IsLeave;

            this.PatientName = rescueRoomInfo.PatientName;
            this.OutPatientNumber = rescueRoomInfo.OutPatientNumber;
            this.DiagnosisNameOrigin = rescueRoomInfo.DiagnosisNameOrigin;
            this.FirstDoctorName = rescueRoomInfo.FirstDoctorName;
            this.InDepartmentTime = rescueRoomInfo.InDepartmentTime;
            this.CriticalLevelName = rescueRoomInfo.CriticalLevel.CriticalLevelName;
            this.RescueResultNameFull = rescueRoomInfo.RescueResultNameFull;
            this.GreenPathCategoryNameFull = rescueRoomInfo.GreenPathCategoryNameFull;
            this.OutDepartmentTime = rescueRoomInfo.OutDepartmentTime;
            this.During = rescueRoomInfo.During;
            this.DestinationName = rescueRoomInfo.Destination.DestinationName;
            this.DiagnosisName = rescueRoomInfo.DiagnosisName;
        }





        public int RescueRoomInfoId { get; set; }

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

        [Display(Name = "危重等级")]
        public string CriticalLevelName { get; set; }

        [Display(Name = "抢救")]
        public string RescueResultNameFull { get; set; }

        [Display(Name = "绿色通道病种")]
        public string GreenPathCategoryNameFull { get; set; }

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