using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.GeneralInfos.TransferRoom
{
    public class SelectionWorker
    {
        public SelectionWorker(TransferRoom targetV)
        {
            var db3 = new Domains3.Entities.EiSDbContext();

            var targetOld = db3.GeneralRoomInfos.Find(targetV.GeneralRoomInfoId);

            this.Rooms = new System.Web.Mvc.SelectList(db3.Rooms.Where(c => c.RoomId != targetOld.RoomId), "RoomId", "RoomName", targetV.RoomId);
        }





        public System.Web.Mvc.SelectList Rooms { get; set; }
    }
}