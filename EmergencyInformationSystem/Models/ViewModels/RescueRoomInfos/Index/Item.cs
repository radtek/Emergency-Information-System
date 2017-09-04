using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Index
{
    /// <summary>
    /// 列表项。
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="origin">原抢救室病例。</param>
        public Item(RescueRoomInfo origin)
        {
            this.RescueRoomInfoId = origin.RescueRoomInfoId;
            this.IsLeave = origin.OutDepartmentTime.HasValue;

            this.PatientName = origin.PatientName;
            this.OutPatientNumber = origin.OutPatientNumber;
            this.Sex = origin.Sex;
            this.ReceiveAgeName = origin.ReceiveAgeName;
            this.DiagnosisNameOrigin = origin.DiagnosisNameOrigin;
            this.ReceiveTime = origin.ReceiveTime;
            this.FirstDoctorName = origin.FirstDoctorName;

            this.InDepartmentTime = origin.InDepartmentTime;
            this.BedNameFull = origin.BedNameFull;
            this.FirstNurseName = origin.FirstNurseName;
            this.InRescueRoomWayNameFull = origin.InRescueRoomWayNameFull;
            this.AdditionalDiagnosis = origin.AdditionalDiagnosis;

            this.CriticalLevelName = origin.CriticalLevel.CriticalLevelName;
            this.RescueResultNameFull = origin.RescueResultNameFull;
            this.GreenPathCategoryNameFull = origin.GreenPathCategoryNameFull;
            this.Antibiotic = origin.Antibiotic;
            this.Remarks = origin.Remarks;

            this.DestinationFirstName = origin.DestinationFirstName;
            this.DestinationFirstTime = origin.DestinationFirstTime;
            this.DestinationFirstContact = origin.DestinationFirstContact;
            this.DestinationSecondName = origin.DestinationSecondName;

            this.OutDepartmentTime = origin.OutDepartmentTime;
            this.During = origin.During;
            this.DestinationNameFull = origin.DestinationNameFull;
            this.HandleNurse = origin.HandleNurse;
            this.DiagnosisName = origin.DiagnosisName;
        }





        /// <summary>
        /// 抢救室病例ID。
        /// </summary>
        public int RescueRoomInfoId { get; set; }

        /// <summary>
        /// 是否已离室。
        /// </summary>
        public bool IsLeave { get; set; }





        /// <summary>
        /// 患者姓名。
        /// </summary>
        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        /// <summary>
        /// 卡号。
        /// </summary>
        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        /// <summary>
        /// 性别。
        /// </summary>
        [Display(Name = "性别")]
        public string Sex { get; set; }

        /// <summary>
        /// 就诊年龄名称。
        /// </summary>
        [Display(Name = "就诊年龄")]
        public string ReceiveAgeName { get; set; }

        /// <summary>
        /// 急诊选择接诊诊断名称。
        /// </summary>
        [Display(Name = "入室诊断")]
        public string DiagnosisNameOrigin { get; set; }

        /// <summary>
        /// 急诊选择接诊时间。
        /// </summary>
        [Display(Name = "接诊时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? ReceiveTime { get; set; }

        /// <summary>
        /// 急诊选择接诊医师姓名。
        /// </summary>
        [Display(Name = "首诊医师")]
        public string FirstDoctorName { get; set; }





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
    }
}