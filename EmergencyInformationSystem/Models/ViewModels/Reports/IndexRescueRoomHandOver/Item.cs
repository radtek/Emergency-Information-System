using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexRescueRoomHandOver
{
    /// <summary>
    /// 抢救室交班表列表项。
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

            this.PatientName = rescueRoomInfo.PatientName;
            this.OutPatientNumber = rescueRoomInfo.OutPatientNumber;
            this.DiagnosisNameOrigin = rescueRoomInfo.DiagnosisNameOrigin;
            this.InDepartmentTime = rescueRoomInfo.InDepartmentTime;
            this.BedNameFull = rescueRoomInfo.BedNameFull;
            this.CriticalLevelName = rescueRoomInfo.CriticalLevel.CriticalLevelName;
            this.RescueResultNameFull = rescueRoomInfo.RescueResultNameFull;
            this.GreenPathCategoryNameFull = rescueRoomInfo.GreenPathCategoryNameFull;
            this.Antibiotic = rescueRoomInfo.Antibiotic;
            this.Remarks = rescueRoomInfo.Remarks;
            this.DestinationFirstName = rescueRoomInfo.DestinationFirstName;
            this.DestinationSecondName = rescueRoomInfo.DestinationSecondName;
        }





        public int RescueRoomInfoId { get; set; }





        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        [Display(Name = "入室诊断")]
        public string DiagnosisNameOrigin { get; set; }

        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }

        [Display(Name = "床位号")]
        public string BedNameFull { get; set; }

        [Display(Name = "危重等级")]
        public string CriticalLevelName { get; set; }

        [Display(Name = "抢救")]
        public string RescueResultNameFull { get; set; }

        [Display(Name = "绿色通道病种")]
        public string GreenPathCategoryNameFull { get; set; }

        [Display(Name = "抗生素")]
        public virtual string Antibiotic { get; set; }

        [Display(Name = "备注")]
        public string Remarks { get; set; }

        [Display(Name = "预约首选科室")]
        public string DestinationFirstName { get; set; }

        [Display(Name = "预约次选科室")]
        public string DestinationSecondName { get; set; }
    }
}