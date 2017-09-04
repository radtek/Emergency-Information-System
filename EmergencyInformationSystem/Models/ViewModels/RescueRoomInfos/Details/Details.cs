using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

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
        /// <param name="rescueRoomInfo">原抢救室病例。</param>
        public Details(RescueRoomInfo rescueRoomInfo)
        {
            this.RescueRoomInfoId = rescueRoomInfo.RescueRoomInfoId;
            this.GreenPathActionName = rescueRoomInfo.GreenPathActionName;
            this.GreenPathId = rescueRoomInfo.GreenPathId;

            this.InDepartmentTime = rescueRoomInfo.InDepartmentTime;
            this.BedNameFull = rescueRoomInfo.BedNameFull;
            this.FirstNurseName = rescueRoomInfo.FirstNurseName;
            this.InRescueRoomWayNameFull = rescueRoomInfo.InRescueRoomWayNameFull;
            this.AdditionalDiagnosis = rescueRoomInfo.AdditionalDiagnosis;

            this.CriticalLevelName = rescueRoomInfo.CriticalLevel.CriticalLevelName;
            this.RescueResultNameFull = rescueRoomInfo.RescueResultNameFull;
            this.GreenPathCategoryNameFull = rescueRoomInfo.GreenPathCategoryNameFull;
            this.Antibiotic = rescueRoomInfo.Antibiotic;
            this.Remarks = rescueRoomInfo.Remarks;

            this.DestinationFirstName = rescueRoomInfo.DestinationFirstName;
            this.DestinationFirstTime = rescueRoomInfo.DestinationFirstTime;
            this.DestinationFirstContact = rescueRoomInfo.DestinationFirstContact;
            this.DestinationSecondName = rescueRoomInfo.DestinationSecondName;

            this.OutDepartmentTime = rescueRoomInfo.OutDepartmentTime;
            this.During = rescueRoomInfo.During;
            this.DuringDetained = rescueRoomInfo.DuringDetained;
            this.DestinationNameFull = rescueRoomInfo.DestinationNameFull;
            this.HandleNurse = rescueRoomInfo.HandleNurse;
            this.DiagnosisName = rescueRoomInfo.DiagnosisName;
            this.IsLeaveName = rescueRoomInfo.IsLeaveName;
        }





        /// <summary>
        /// 抢救室病例ID。
        /// </summary>
        public int RescueRoomInfoId { get; set; }

        /// <summary>
        /// 绿色通道表格跳转响应方法名称。
        /// </summary>
        public string GreenPathActionName { get; set; }

        /// <summary>
        /// 绿色通道表格跳转ID。
        /// </summary>
        public Guid? GreenPathId { get; set; }





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
        public string InRescueRoomWayNameFull { get; set; }

        /// <summary>
        /// 补充诊断。
        /// </summary>
        [Display(Name = "补充诊断")]
        public string AdditionalDiagnosis { get; set; }





        /// <summary>
        /// 危重等级名称。
        /// </summary>
        [Display(Name = "危重等级")]
        public string CriticalLevelName { get; set; }

        /// <summary>
        /// 抢救效果名称-完整。
        /// </summary>
        [Display(Name = "抢救")]
        public string RescueResultNameFull { get; set; }

        /// <summary>
        /// 绿色通道类型名称-完整。
        /// </summary>  
        [Display(Name = "绿色通道")]
        public string GreenPathCategoryNameFull { get; set; }

        /// <summary>
        /// 抗生素。
        /// </summary>
        [Display(Name = "抗生素")]
        public string Antibiotic { get; set; }

        /// <summary>
        /// 备注。
        /// </summary>
        [Display(Name = "备注")]
        public string Remarks { get; set; }





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
        /// 连续滞留时长。
        /// </summary>
        [Display(Name = "连续滞留时长")]
        public TimeSpan DuringDetained { get; set; }

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