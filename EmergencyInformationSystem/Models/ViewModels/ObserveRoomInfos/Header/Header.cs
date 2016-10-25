using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Header
{
    public class Header
    {
        public Header(ObserveRoomInfo observeRoomInfo)
        {
            this.PatientName = observeRoomInfo.PatientName;
            this.OutPatientNumber = observeRoomInfo.OutPatientNumber;
            this.Sex = observeRoomInfo.Sex;
            this.ReceiveAgeName = observeRoomInfo.ReceiveAgeName;
            this.DiagnosisNameOrigin = observeRoomInfo.DiagnosisNameOrigin;
            this.ReceiveTime = observeRoomInfo.ReceiveTime;
            this.FirstDoctorName = observeRoomInfo.FirstDoctorName;
        }





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
    }
}