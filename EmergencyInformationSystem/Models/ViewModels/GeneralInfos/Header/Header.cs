using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.GeneralInfos.Header
{
    public class Header
    {
        public Header(Guid id)
        {
            var db3 = new Domains3.Entities.EiSDbContext();
            var target = db3.GeneralRoomInfos.Find(id);
            if (target == null)
                throw new ArgumentException("id Not Exist.", "id");

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