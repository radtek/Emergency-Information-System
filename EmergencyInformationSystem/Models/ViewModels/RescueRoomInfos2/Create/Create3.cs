using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using TrasenLib;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos2.Create
{
    public class Create3
    {
        public Create3(Guid JZID, Guid? preGeneralRoomInfoId)
        {
            this.PreGeneralRoomInfoId = preGeneralRoomInfoId;
            this.JZID = JZID;

            var dbTrasen = new TrasenDbContext("TrasenConnection");
            var MZYS_JZJL = dbTrasen.MZYS_JZJL.Where(c => c.JZID == JZID).FirstOrDefault();
            var BRXX = dbTrasen.VI_YY_BRXX.Where(c => c.BRXXID == MZYS_JZJL.BRXXID).FirstOrDefault();
            var GHXX = dbTrasen.VI_MZ_GHXX.Where(c => c.GHXXID == MZYS_JZJL.GHXXID).FirstOrDefault();
            var YY_KDJB = dbTrasen.YY_KDJB.Where(c => c.BRXXID == MZYS_JZJL.BRXXID).FirstOrDefault();
            var JC_SEXCODE = dbTrasen.JC_SEXCODE.Where(c => c.CODE == BRXX.XB).FirstOrDefault();
            var JC_EMPLOYEE_PROPERTY = dbTrasen.JC_EMPLOYEE_PROPERTY.Where(c => c.EMPLOYEE_ID == MZYS_JZJL.JSYSDM).FirstOrDefault();
            if (MZYS_JZJL == null || BRXX == null || GHXX == null || YY_KDJB == null)
                throw new ArgumentException("JZID无效");

            this.PatientName = BRXX?.BRXM;
            this.OutPatientNumber = YY_KDJB?.KH;
            this.Sex = JC_SEXCODE?.NAME;
            this.BirthDate = BRXX?.CSRQ;
            this.DiagnosisNameOrigin = MZYS_JZJL?.ZDMC;
            this.ReceiveTime = MZYS_JZJL?.JSSJ;
            this.FirstDoctorName = JC_EMPLOYEE_PROPERTY?.NAME;

            this.KDJID = YY_KDJB.KDJID;
            this.BRXXID = BRXX.BRXXID;
            this.GHXXID = GHXX.GHXXID;
        }

        public Create3()
        {

        }





        public Guid? PreGeneralRoomInfoId { get; set; }





        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        [Display(Name = "性别")]
        public string Sex { get; set; }

        [Display(Name = "出生日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "入室诊断")]
        public string DiagnosisNameOrigin { get; set; }

        [Display(Name = "接诊时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? ReceiveTime { get; set; }

        [Display(Name = "首诊医师")]
        public string FirstDoctorName { get; set; }





        public Guid? KDJID { get; set; }

        public Guid? BRXXID { get; set; }

        public Guid? GHXXID { get; set; }

        public Guid? JZID { get; set; }





        public Domains2.Entities.GeneralRoomInfo GetReturn()
        {
            var target = new Domains2.Entities.GeneralRoomInfo();

            target.GeneralRoomInfoId = Guid.NewGuid();
            target.RoomId = new Guid("866067fe-e038-407c-9fdc-16ca017b7b6a");
            target.PreGeneralRoomInfoId = this.PreGeneralRoomInfoId;

            target.PatientName = this.PatientName;
            target.OutPatientNumber = this.OutPatientNumber;
            target.Sex = this.Sex;
            target.BirthDate = this.BirthDate;
            target.DiagnosisNameOrigin = this.DiagnosisNameOrigin;
            target.ReceiveTime = this.ReceiveTime;
            target.FirstDoctorName = this.FirstDoctorName;

            target.InDepartmentTime = DateTime.Now;

            target.KDJID = this.KDJID;
            target.BRXXID = this.BRXXID;
            target.GHXXID = this.GHXXID;
            target.JZID = this.JZID;

            target.UpdateTime = DateTime.Now;

            return target;
        }
    }
}