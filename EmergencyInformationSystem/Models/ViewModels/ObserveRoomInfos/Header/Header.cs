using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Header
{
    /// <summary>
    /// 眉栏。
    /// </summary>
    public class Header
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="target">留观室病例。</param>
        public Header(Models.Domains.Entities.ObserveRoomInfo target)
        {
            this.PatientName = target.PatientName;
            this.OutPatientNumber = target.OutPatientNumber;
            this.Sex = target.Sex;
            this.ReceiveAgeName = target.ReceiveAgeName;
            this.DiagnosisNameOrigin = target.DiagnosisNameOrigin;
            this.ReceiveTime = target.ReceiveTime;
            this.FirstDoctorName = target.FirstDoctorName;
        }





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
    }
}