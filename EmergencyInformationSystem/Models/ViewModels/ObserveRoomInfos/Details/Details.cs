using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Details
{
    /// <summary>
    /// 留观室——详情。
    /// </summary>
    public class Details
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="target">原留观室病例。</param>
        public Details(Models.Domains.Entities.ObserveRoomInfo target)
        {
            this.ObserveRoomInfoId = target.ObserveRoomInfoId;

            this.InDepartmentTime = target.InDepartmentTime;
            this.BedNameFull = target.BedNameFull;
            this.FirstNurseName = target.FirstNurseName;
            this.InObserveRoomWayNameFull = target.InObserveRoomWayNameFull;
            this.AdditionalDiagnosis = target.AdditionalDiagnosis;

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





        public Guid ObserveRoomInfoId { get; set; }





        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }

        [Display(Name = "床位")]
        public string BedNameFull { get; set; }

        [Display(Name = "首诊护士")]
        public string FirstNurseName { get; set; }

        [Display(Name = "入室方式")]
        public string InObserveRoomWayNameFull { get; set; }

        [Display(Name = "补充诊断")]
        public string AdditionalDiagnosis { get; set; }





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