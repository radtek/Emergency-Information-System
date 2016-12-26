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
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="observeRoomInfo">留观室病例。</param>
        public Item(ObserveRoomInfo observeRoomInfo)
        {
            this.ObserveRoomInfoId = observeRoomInfo.ObserveRoomInfoId;

            this.PatientName = observeRoomInfo.PatientName;
            this.OutPatientNumber = observeRoomInfo.OutPatientNumber;
            this.DiagnosisNameOrigin = observeRoomInfo.DiagnosisNameOrigin;
            this.InDepartmentTime = observeRoomInfo.InDepartmentTime;
            this.BedNameFull = observeRoomInfo.BedNameFull;
            this.DestinationFirstName = observeRoomInfo.DestinationFirstName;
            this.DestinationSecondName = observeRoomInfo.DestinationSecondName;
        }





        public Guid ObserveRoomInfoId { get; set; }





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

        [Display(Name = "预约首选科室")]
        public string DestinationFirstName { get; set; }

        [Display(Name = "预约次选科室")]
        public string DestinationSecondName { get; set; }
    }
}