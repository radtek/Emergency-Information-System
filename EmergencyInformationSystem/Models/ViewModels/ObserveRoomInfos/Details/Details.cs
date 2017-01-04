using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Details
{
    /// <summary>
    /// 留观室——详情。
    /// </summary>
    public class Details
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Details"/> class.
        /// </summary>
        /// <param name="observeRoomInfo">原留观室病例。</param>
        public Details(ObserveRoomInfo observeRoomInfo)
        {
            this.ObserveRoomInfoId = observeRoomInfo.ObserveRoomInfoId;

            this.InDepartmentTime = observeRoomInfo.InDepartmentTime;
            this.BedNameFull = observeRoomInfo.BedNameFull;
            this.FirstNurseName = observeRoomInfo.FirstNurseName;
            this.InObserveRoomWayNameFull = observeRoomInfo.InObserveRoomWayNameFull;
            this.AdditionalDiagnosis = observeRoomInfo.AdditionalDiagnosis;

            this.DestinationFirstName = observeRoomInfo.DestinationFirstName;
            this.DestinationFirstTime = observeRoomInfo.DestinationFirstTime;
            this.DestinationFirstContact = observeRoomInfo.DestinationFirstContact;
            this.DestinationSecondName = observeRoomInfo.DestinationSecondName;

            this.OutDepartmentTime = observeRoomInfo.OutDepartmentTime;
            this.During = observeRoomInfo.During;
            this.DestinationNameFull = observeRoomInfo.DestinationNameFull;
            this.HandleNurse = observeRoomInfo.HandleNurse;
            this.DiagnosisName = observeRoomInfo.DiagnosisName;
            this.IsLeaveName = observeRoomInfo.IsLeaveName;
        }





        /// <summary>
        /// 留观室病例ID。
        /// </summary>
        public Guid ObserveRoomInfoId { get; set; }





        /// <summary>
        /// 入室时间。
        /// </summary>        
        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }

        /// <summary>
        /// 床位名称-完整。
        /// </summary>
        [Display(Name = "床位")]
        public string BedNameFull { get; set; }

        /// <summary>
        /// 首诊护士姓名。
        /// </summary>
        [Display(Name = "首诊护士")]
        public string FirstNurseName { get; set; }

        /// <summary>
        /// 进入抢救室方式名称-完整。
        /// </summary>
        [Display(Name = "入室方式")]
        public string InObserveRoomWayNameFull { get; set; }

        /// <summary>
        /// 补充诊断。
        /// </summary>
        [Display(Name = "补充诊断")]
        public string AdditionalDiagnosis { get; set; }





        /// <summary>
        /// 预约首选科室名称——去向名称。
        /// </summary>
        [Display(Name = "预约首选科室")]
        public string DestinationFirstName { get; set; }

        /// <summary>
        /// 预约首选科室预约时间。
        /// </summary>        
        [Display(Name = "预约首选时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? DestinationFirstTime { get; set; }

        /// <summary>
        /// 预约首选科室联系人。
        /// </summary>
        [Display(Name = "预约首选医师")]
        public string DestinationFirstContact { get; set; }

        /// <summary>
        /// 预约次选科室名称——去向名称。
        /// </summary>
        [Display(Name = "预约次选科室")]
        public string DestinationSecondName { get; set; }





        /// <summary>
        /// 离室时间。
        /// </summary>
        [Display(Name = "离室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? OutDepartmentTime { get; set; }

        /// <summary>
        /// 停留时长。
        /// </summary>
        [Display(Name = "停留时长")]
        public TimeSpan? During { get; set; }

        /// <summary>
        /// 去向名称-完整。
        /// </summary>
        [Display(Name = "去向")]
        public string DestinationNameFull { get; set; }

        /// <summary>
        /// 经手护士。
        /// </summary>
        [Display(Name = "经手护士")]
        public string HandleNurse { get; set; }

        /// <summary>
        /// 离室诊断名称。
        /// </summary>
        [Display(Name = "离室诊断")]
        public string DiagnosisName { get; set; }

        /// <summary>
        /// 是否已离室名称。
        /// </summary>
        [Display(Name = "离室")]
        public string IsLeaveName { get; set; }
    }
}