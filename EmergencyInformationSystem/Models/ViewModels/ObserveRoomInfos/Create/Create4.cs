using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using TrasenLib;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Create
{
    /// <summary>
    /// 留观室——新增4。
    /// </summary>
    public class Create4
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Create4"/> class.
        /// </summary>
        public Create4(Guid JZID, int? previousRescueRoomInfoId)
        {
            this.PreviousRescueRoomInfoId = previousRescueRoomInfoId;
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

        public Create4()
        {

        }





        public int? PreviousRescueRoomInfoId { get; set; }





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





        public Models.Domains.Entities.ObserveRoomInfo GetReturn()
        {
            var target = new Models.Domains.Entities.ObserveRoomInfo();

            target.ObserveRoomInfoId = Guid.NewGuid();

            target.PatientName = this.PatientName;
            target.OutPatientNumber = this.OutPatientNumber;
            target.Sex = this.Sex;
            target.BirthDate = this.BirthDate;
            target.DiagnosisNameOrigin = this.DiagnosisNameOrigin;
            target.ReceiveTime = this.ReceiveTime;
            target.FirstDoctorName = this.FirstDoctorName;

            target.InDepartmentTime = DateTime.Now;
            target.BedId = 1;
            target.InObserveRoomWayId = 1;
            target.DestinationFirstId = 1;
            target.DestinationSecondId = 1;
            target.DestinationId = 1;
            target.TransferReasonId = 1;

            target.KDJID = this.KDJID;
            target.BRXXID = this.BRXXID;
            target.GHXXID = this.GHXXID;
            target.JZID = this.JZID;

            target.UpdateTime = DateTime.Now;

            return target;
        }
    }
}