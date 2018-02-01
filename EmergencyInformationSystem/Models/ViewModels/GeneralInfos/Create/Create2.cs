using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TrasenLib;

namespace EmergencyInformationSystem.Models.ViewModels.GeneralInfos.Create
{
    public class Create2
    {
        public Create2(string outPatientNumber, Guid roomId, Guid? preGeneralRoomInfoId)
        {
            this.RoomId = roomId;
            this.PreGeneralRoomInfoId = preGeneralRoomInfoId;

            var db3 = new Domains3.Entities.EiSDbContext();
            var room = db3.Rooms.Find(this.RoomId);
            this.RoomName = room.RoomName;

            Domains3.Entities.GeneralRoomInfo target = null;
            if (this.PreGeneralRoomInfoId != null)
            {
                target = db3.GeneralRoomInfos.Find(this.PreGeneralRoomInfoId);
            }

            var dbTrasen = new TrasenDbContext("TrasenConnection");

            var itemKDJB = dbTrasen.YY_KDJB.Where(c => c.KH == outPatientNumber).First();
            List<VI_MZ_GHXX> listGHXX;
            if (target == null)
            {
                listGHXX = dbTrasen.VI_MZ_GHXX.Where(c => c.BRXXID == itemKDJB.BRXXID).OrderByDescending(c => c.GHSJ).ThenBy(c => c.GHXXID).ToList();
            }
            else
            {
                listGHXX = dbTrasen.VI_MZ_GHXX.Where(c => c.BRXXID == itemKDJB.BRXXID && c.GHSJ >= target.ReceiveTime.Value).OrderByDescending(c => c.GHSJ).ThenBy(c => c.GHXXID).ToList();
            }

            this.ListGhxx = listGHXX.Select(c => new ItemGhxx(c, this.RoomId, this.PreGeneralRoomInfoId)).ToList();
        }





        public Guid RoomId { get; set; }

        public string RoomName { get; set; }

        public Guid? PreGeneralRoomInfoId { get; set; }





        public List<ItemGhxx> ListGhxx { get; set; }
    }
}