using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Index
{
    /// <summary>
    /// 列表项。
    /// </summary>
    public class Item
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="observeRoomInfo">原留观室病例。</param>
        public Item(ObserveRoomInfo observeRoomInfo)
        {
            this.ObserveRoomInfoId = observeRoomInfo.ObserveRoomInfoId;
            this.IsLeave = observeRoomInfo.OutDepartmentTime.HasValue;

            this.PatientName = observeRoomInfo.PatientName;
            this.OutPatientNumber = observeRoomInfo.OutPatientNumber;
            this.Sex = observeRoomInfo.Sex;
            this.ReceiveAgeName = observeRoomInfo.ReceiveAgeName;
            this.DiagnosisNameOrigin = observeRoomInfo.DiagnosisNameOrigin;
            this.ReceiveTime = observeRoomInfo.ReceiveTime;
            this.FirstDoctorName = observeRoomInfo.FirstDoctorName;

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
        }





        public Guid ObserveRoomInfoId { get; set; }

        public bool IsLeave { get; set; }





        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        [Display(Name = "性别")]
        public string Sex { get; set; }

        [Display(Name = "就诊年龄")]
        public string ReceiveAgeName { get; set; }

        [Display(Name = "入室诊断名称")]
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

        [Display(Name = "去向")]
        public string DestinationNameFull { get; set; }

        [Display(Name = "经手护士")]
        public string HandleNurse { get; set; }

        [Display(Name = "离室诊断")]
        public string DiagnosisName { get; set; }
    }
}