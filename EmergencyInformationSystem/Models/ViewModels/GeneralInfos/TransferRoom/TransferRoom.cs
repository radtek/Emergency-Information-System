using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.GeneralInfos.TransferRoom
{
    public class TransferRoom
    {
        public TransferRoom(Guid generalRoominfoId)
        {
            this.GeneralRoomInfoId = generalRoominfoId;
        }

        public TransferRoom()
        {

        }





        public Guid GeneralRoomInfoId { get; set; }





        [Display(Name = "室")]
        public Guid RoomId { get; set; }
    }
}