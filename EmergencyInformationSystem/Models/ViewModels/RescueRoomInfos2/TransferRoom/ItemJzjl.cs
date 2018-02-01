using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using TrasenLib;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos2.TransferRoom
{
    public class ItemJzjl
    {
        public ItemJzjl(MZYS_JZJL JZJL, Guid generalRoomInfoId)
        {
            this.GeneralRoomInfoId = generalRoomInfoId;

            var dbTrasen = new TrasenDbContext("TrasenConnection");

            this.ORIGIN_JZID = JZJL.JZID;

            this.FirstDoctorName = dbTrasen.JC_EMPLOYEE_PROPERTY.Where(c => c.EMPLOYEE_ID == JZJL.JSYSDM).FirstOrDefault()?.NAME;
            this.DiagnosisNameOrigin = JZJL.ZDMC;
            this.ReceiveTime = JZJL.JSSJ;

            var db2 = new Domains2.Entities.EiSDbContext();
            this.ExistRoomName = db2.GeneralRoomInfos.FirstOrDefault(c => c.JZID == JZJL.JZID)?.Room.RoomName;
        }





        public Guid ORIGIN_JZID { get; set; }

        public Guid GeneralRoomInfoId { get; set; }

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