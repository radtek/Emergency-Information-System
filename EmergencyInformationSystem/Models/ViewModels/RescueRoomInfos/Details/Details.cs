using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Details
{
    /// <summary>
    /// 抢救室——详情。
    /// </summary>
    public class Details
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="target">原抢救室病例。</param>
        public Details(Models.Domains.Entities.RescueRoomInfo target)
        {
            this.RescueRoomInfoId = target.RescueRoomInfoId;
            this.GreenPathActionName = target.GreenPathActionName;
            this.GreenPathId = target.GreenPathId;

            this.InDepartmentTime = target.InDepartmentTime;
            this.BedNameFull = target.BedNameFull;
            this.FirstNurseName = target.FirstNurseName;
            this.InRescueRoomWayNameFull = target.InRescueRoomWayNameFull;
            this.AdditionalDiagnosis = target.AdditionalDiagnosis;

            this.CriticalLevelName = target.CriticalLevel.CriticalLevelName;
            this.RescueResultNameFull = target.RescueResultNameFull;
            this.GreenPathCategoryNameFull = target.GreenPathCategoryNameFull;
            this.Antibiotic = target.Antibiotic;
            this.Remarks = target.Remarks;

            this.DestinationFirstName = target.DestinationFirstName;
            this.DestinationFirstTime = target.DestinationFirstTime;
            this.DestinationFirstContact = target.DestinationFirstContact;
            this.DestinationSecondName = target.DestinationSecondName;

            this.OutDepartmentTime = target.OutDepartmentTime;
            this.During = target.During;
            this.DuringDetained = target.DuringDetained;
            this.DestinationNameFull = target.DestinationNameFull;
            this.HandleNurse = target.HandleNurse;
            this.DiagnosisName = target.DiagnosisName;
            this.IsLeaveName = target.IsLeaveName;
        }





        public int RescueRoomInfoId { get; set; }

        public string GreenPathActionName { get; set; }

        public Guid? GreenPathId { get; set; }





        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }

        [Display(Name = "床位")]
        public string BedNameFull { get; set; }

        [Display(Name = "首诊护士")]
        public string FirstNurseName { get; set; }

        [Display(Name = "入室方式")]
        public string InRescueRoomWayNameFull { get; set; }

        [Display(Name = "补充诊断")]
        public string AdditionalDiagnosis { get; set; }





        [Display(Name = "危重等级")]
        public string CriticalLevelName { get; set; }

        [Display(Name = "抢救")]
        public string RescueResultNameFull { get; set; }

        [Display(Name = "绿色通道")]
        public string GreenPathCategoryNameFull { get; set; }

        [Display(Name = "抗生素")]
        public string Antibiotic { get; set; }

        [Display(Name = "备注")]
        public string Remarks { get; set; }





        [Display(Name = "预约首选科室")]
        public string DestinationFirstName { get; set; }

        [Display(Name = "预约首选时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? DestinationFirstTime { get; set; }

        [Display(Name = "预约首选医师")]
        public string DestinationFirstContact { get; set; }

        [Display(Name = "预约次选科室")]
        public string DestinationSecondName { get; set; }





        [Display(Name = "离室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? OutDepartmentTime { get; set; }

        [Display(Name = "停留时长")]
        public TimeSpan? During { get; set; }

        [Display(Name = "连续滞留时长")]
        public TimeSpan DuringDetained { get; set; }

        [Display(Name = "去向")]
        public string DestinationNameFull { get; set; }

        [Display(Name = "经手护士")]
        public string HandleNurse { get; set; }

        [Display(Name = "离室诊断")]
        public string DiagnosisName { get; set; }

        [Display(Name = "离室")]
        public string IsLeaveName { get; set; }
    }
}