using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos2.TransferRoom
{
    public class SelectionWorker
    {
        public SelectionWorker(TransferRoom2 targetV)
        {
            var db2 = new Domains2.Entities.EiSDbContext();

            var targetOld = db2.GeneralRoomInfos.Find(targetV.GeneralRoomInfoId);

            this.Rooms = new System.Web.Mvc.SelectList(db2.Rooms.Where(c => c.RoomId != targetOld.RoomId), "RoomId", "RoomName", targetV.RoomId);
        }





        public System.Web.Mvc.SelectList Rooms { get; set; }
    }
}