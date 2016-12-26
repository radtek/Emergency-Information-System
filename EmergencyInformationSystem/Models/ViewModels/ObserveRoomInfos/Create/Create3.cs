using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Create
{
    public class Create3
    {
        public Create3(string outPatientNumber, Guid JZID, Guid GHXXID, Guid BRXXID, Guid KDJID)
        {
            var db = new EiSDbContext();

            this.OutPatientNumber = outPatientNumber;
            this.JZID = JZID;
            this.GHXXID = GHXXID;
            this.BRXXID = BRXXID;
            this.KDJID = KDJID;

            this.ListRescueRoomInfos = db.RescueRoomInfos.Where(c => c.OutPatientNumber == outPatientNumber && c.OutDepartmentTime.HasValue && c.OutDepartmentTime <= DateTime.Now).OrderByDescending(c => c.OutDepartmentTime).Take(1).ToList().Select(c => new ItemRescueRoomInfo(c, outPatientNumber, JZID, GHXXID, BRXXID, KDJID)).ToList();
        }





        public string OutPatientNumber { get; set; }

        public Guid JZID { get; set; }

        public Guid GHXXID { get; set; }

        public Guid BRXXID { get; set; }

        public Guid KDJID { get; set; }





        public List<ItemRescueRoomInfo> ListRescueRoomInfos { get; set; }
    }
}