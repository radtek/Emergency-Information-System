using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Create
{
    public class Create3
    {
        public Create3(Guid JZID)
        {
            var db = new EiSDbContext();
            var dbTrasen = new TrasenLib.TrasenDbContext("TrasenConnection");

            var MZYS_JZJL = dbTrasen.MZYS_JZJL.Where(c => c.JZID == JZID).FirstOrDefault();
            var YY_KDJB = dbTrasen.YY_KDJB.Where(c => c.BRXXID == MZYS_JZJL.BRXXID).FirstOrDefault();

            this.JZID = JZID;

            this.ListObserveRoomInfos = db.ObserveRoomInfos.Where(c => c.OutPatientNumber == YY_KDJB.KH && c.OutDepartmentTime.HasValue && c.OutDepartmentTime <= DateTime.Now).OrderByDescending(c => c.OutDepartmentTime).Take(1).ToList().Select(c => new ItemObserveRoomInfo(c, JZID)).ToList();
        }





        public Guid JZID { get; set; }





        public List<ItemObserveRoomInfo> ListObserveRoomInfos { get; set; }
    }
}