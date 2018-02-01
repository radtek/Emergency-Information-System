using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TrasenLib;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos2.TransferRoom
{
    public class TransferRoom
    {
        public TransferRoom(Guid generalRoomInfoId)
        {
            var db2 = new Domains2.Entities.EiSDbContext();
            var target = db2.GeneralRoomInfos.Find(generalRoomInfoId);

            var dbTrasen = new TrasenDbContext("TrasenConnection");

            var itemKDJB = dbTrasen.YY_KDJB.Where(c => c.KH == target.OutPatientNumber).First();
            var listGHXX = dbTrasen.VI_MZ_GHXX.Where(c => c.BRXXID == itemKDJB.BRXXID && c.GHSJ >= target.ReceiveTime.Value).OrderByDescending(c => c.GHSJ).ThenBy(c => c.GHXXID).ToList();

            this.ListGhxx = listGHXX.Select(c => new ItemGhxx(c, generalRoomInfoId)).ToList();
        }





        public List<ItemGhxx> ListGhxx { get; set; }
    }
}