﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Index
{
    /// <summary>
    /// 列表项。
    /// </summary>
    public class Item
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="target">原抢救室病例。</param>
        public Item(Models.Domains.Entities.RescueRoomInfo target)
        {
            this.RescueRoomInfoId = target.RescueRoomInfoId;
            this.IsLeave = target.OutDepartmentTime.HasValue;

            this.PatientName = target.PatientName;
            this.OutPatientNumber = target.OutPatientNumber;
            this.Sex = target.Sex;
            this.ReceiveAgeName = target.ReceiveAgeName;
            this.DiagnosisNameOrigin = target.DiagnosisNameOrigin;
            this.ReceiveTime = target.ReceiveTime;
            this.FirstDoctorName = target.FirstDoctorName;

            this.InDepartmentTime = target.InDepartmentTime;
            this.BedNameFull = target.BedNameFull;
            this.FirstNurseName = target.FirstNurseName;
            this.InRescueRoomWayNameFull = target.InRescueRoomWayNameFull;
            this.AdditionalDiagnosis = target.AdditionalDiagnosis;

            this.CriticalLevelName = target.CriticalLevel?.CriticalLevelName;
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
            this.DestinationNameFull = target.DestinationNameFull;
            this.HandleNurse = target.HandleNurse;
            this.DiagnosisName = target.DiagnosisName;
        }

        public Item()
        {

        }





        public Guid RescueRoomInfoId { get; set; }

        public bool IsLeave { get; set; }





        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        [Display(Name = "性别")]
        public string Sex { get; set; }

        [Display(Name = "就诊年龄")]
        public string ReceiveAgeName { get; set; }

        [Display(Name = "入室诊断")]
        public string DiagnosisNameOrigin { get; set; }

        [Display(Name = "接诊时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? ReceiveTime { get; set; }

        [Display(Name = "首诊医师")]
        public string FirstDoctorName { get; set; }





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

        [Display(Name = "去向")]
        public string DestinationNameFull { get; set; }

        [Display(Name = "经手护士")]
        public string HandleNurse { get; set; }

        [Display(Name = "离室诊断")]
        public string DiagnosisName { get; set; }
    }
}