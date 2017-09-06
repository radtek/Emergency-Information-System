using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Header
{
    /// <summary>
    /// 眉栏。
    /// </summary>
    public class Header
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="rescueRoomInfo">抢救室病例。</param>
        public Header(RescueRoomInfo rescueRoomInfo)
        {
            this.PatientName = rescueRoomInfo.PatientName;
            this.OutPatientNumber = rescueRoomInfo.OutPatientNumber;
            this.Sex = rescueRoomInfo.Sex;
            this.ReceiveAgeName = rescueRoomInfo.ReceiveAgeName;
            this.DiagnosisNameOrigin = rescueRoomInfo.DiagnosisNameOrigin;
            this.ReceiveTime = rescueRoomInfo.ReceiveTime;
            this.FirstDoctorName = rescueRoomInfo.FirstDoctorName;
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