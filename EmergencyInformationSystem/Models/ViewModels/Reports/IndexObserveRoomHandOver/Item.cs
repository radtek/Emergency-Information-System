﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexObserveRoomHandOver
{
    /// <summary>
    /// 留观室交班表列表项。
    /// </summary>
    public class Item
    {
        public Item(ObserveRoomInfo target)
        {
            this.ObserveRoomInfoId = target.ObserveRoomInfoId;

            this.PatientName = target.PatientName;
            this.OutPatientNumber = target.OutPatientNumber;
            this.Sex = target.Sex;
            this.ReceiveAgeName = target.ReceiveAgeName;
            this.DiagnosisNameOrigin = target.DiagnosisNameOrigin;
            this.InDepartmentTime = target.InDepartmentTime;
            this.BedNameFull = target.BedNameFull;
            this.DestinationFirstName = target.DestinationFirstName;
            this.DestinationSecondName = target.DestinationSecondName;
        }





        public Guid ObserveRoomInfoId { get; set; }





        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        [Display(Name = "性别")]
        public string Sex { get; set; }

        [Display(Name = "就诊年龄")]
        public string ReceiveAgeName { get; set; }

        [Display(Name = "入室诊断")]
        public string DiagnosisNameOrigin { get; set; }

        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }

        [Display(Name = "床位号")]
        public string BedNameFull { get; set; }

        [Display(Name = "预约首选科室")]
        public string DestinationFirstName { get; set; }

        [Display(Name = "预约次选科室")]
        public string DestinationSecondName { get; set; }
    }
}