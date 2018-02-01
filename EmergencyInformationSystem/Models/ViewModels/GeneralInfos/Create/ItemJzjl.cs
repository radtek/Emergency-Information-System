using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using TrasenLib;

namespace EmergencyInformationSystem.Models.ViewModels.GeneralInfos.Create
{
    public class ItemJzjl
    {
        public ItemJzjl(MZYS_JZJL JZJL, Guid roomId, Guid? preGeneralRoomInfoId)
        {
            this.RoomId = roomId;
            this.PreGeneralRoomInfoId = preGeneralRoomInfoId;

            var dbTrasen = new TrasenDbContext("TrasenConnection");

            this.ORIGIN_JZID = JZJL.JZID;

            this.FirstDoctorName = dbTrasen.JC_EMPLOYEE_PROPERTY.Where(c => c.EMPLOYEE_ID == JZJL.JSYSDM).FirstOrDefault()?.NAME;
            this.DiagnosisNameOrigin = JZJL.ZDMC;
            this.ReceiveTime = JZJL.JSSJ;

            var db3 = new Domains3.Entities.EiSDbContext();
            this.ExistRoomName = db3.GeneralRoomInfos.FirstOrDefault(c => c.JZID == JZJL.JZID)?.Room.RoomName;
        }





        public Guid RoomId { get; set; }

        public Guid? PreGeneralRoomInfoId { get; set; }





        public Guid ORIGIN_JZID { get; set; }

        public string ExistRoomName { get; set; }





        [Display(Name = "接诊医师")]
        public string FirstDoctorName { get; set; }

        [Display(Name = "诊断名称")]
        public string DiagnosisNameOrigin { get; set; }

        [Display(Name = "接诊时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? ReceiveTime { get; set; }
    }
}