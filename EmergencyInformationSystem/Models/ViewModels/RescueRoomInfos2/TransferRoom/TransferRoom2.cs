using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos2.TransferRoom
{
    public class TransferRoom2
    {
        public TransferRoom2()
        {

        }





        public Guid GeneralRoomInfoId { get; set; }

        public Guid JZID { get; set; }





        [Display(Name = "室")]
        public Guid RoomId { get; set; }





        public Domains2.Entities.GeneralRoomInfo GetReturn()
        {
            var dbTrasen = new TrasenLib.TrasenDbContext("TrasenConnection");
            var MZYS_JZJL = dbTrasen.MZYS_JZJL.Where(c => c.JZID == this.JZID).FirstOrDefault();
            var BRXX = dbTrasen.VI_YY_BRXX.Where(c => c.BRXXID == MZYS_JZJL.BRXXID).FirstOrDefault();
            var GHXX = dbTrasen.VI_MZ_GHXX.Where(c => c.GHXXID == MZYS_JZJL.GHXXID).FirstOrDefault();
            var YY_KDJB = dbTrasen.YY_KDJB.Where(c => c.BRXXID == MZYS_JZJL.BRXXID).FirstOrDefault();
            var JC_SEXCODE = dbTrasen.JC_SEXCODE.Where(c => c.CODE == BRXX.XB).FirstOrDefault();
            var JC_EMPLOYEE_PROPERTY = dbTrasen.JC_EMPLOYEE_PROPERTY.Where(c => c.EMPLOYEE_ID == MZYS_JZJL.JSYSDM).FirstOrDefault();
            if (MZYS_JZJL == null || BRXX == null || GHXX == null || YY_KDJB == null)
                throw new ArgumentException("JZID无效");

            var db2 = new Domains2.Entities.EiSDbContext();
            var targetOld = db2.GeneralRoomInfos.Find(this.GeneralRoomInfoId);

            var target = new Domains2.Entities.GeneralRoomInfo();

            target.GeneralRoomInfoId = Guid.NewGuid();
            target.RoomId = this.RoomId;
            target.PreGeneralRoomInfoId = this.GeneralRoomInfoId;

            target.PatientName = BRXX?.BRXM;
            target.OutPatientNumber = YY_KDJB?.KH;
            target.Sex = JC_SEXCODE?.NAME;
            target.BirthDate = BRXX?.CSRQ;
            target.DiagnosisNameOrigin = MZYS_JZJL?.ZDMC;
            target.ReceiveTime = MZYS_JZJL?.JSSJ;
            target.FirstDoctorName = JC_EMPLOYEE_PROPERTY?.NAME;

            target.InDepartmentTime = DateTime.Now;

            target.InRoomWayId = new Guid("793396fb-5298-4c33-9782-0c3f39439709");
            target.AdditionalDiagnosis = targetOld.AdditionalDiagnosis;

            target.CriticalLevelId = targetOld.CriticalLevelId;
            target.IsRescue = targetOld.IsRescue;
            target.RescueResultId = targetOld.RescueResultId;
            target.Antibiotic = targetOld.Antibiotic;
            target.Remarks = targetOld.Remarks;

            target.DestinationFirstId = targetOld.DestinationFirstId;
            target.DestinationFirstTime = targetOld.DestinationFirstTime;
            target.DestinationFirstContact = targetOld.DestinationFirstContact;
            target.DestinationSecondId = targetOld.DestinationSecondId;

            target.KDJID = YY_KDJB.KDJID;
            target.BRXXID = BRXX.BRXXID;
            target.GHXXID = GHXX.GHXXID;
            target.JZID = this.JZID;

            target.UpdateTime = DateTime.Now;

            return target;
        }
    }
}