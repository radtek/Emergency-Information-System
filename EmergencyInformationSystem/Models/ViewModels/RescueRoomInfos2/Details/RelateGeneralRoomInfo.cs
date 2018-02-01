using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos2.Details
{
    public class RelateGeneralRoomInfo
    {
        public RelateGeneralRoomInfo(Domains2.Entities.GeneralRoomInfo target, bool isCurrent = false)
        {
            this.GeneralRoomInfoId = target.GeneralRoomInfoId;
            this.IsCurrent = isCurrent;

            this.RoomName = target.Room.RoomName;
            this.InDepartmentTime = target.InDepartmentTime;
            this.OutDepartmentTime = target.OutDepartmentTime;
            this.During = target.During;
        }





        public Guid GeneralRoomInfoId { get; set; }

        public bool IsCurrent { get; set; }





        [Display(Name = "室")]
        public string RoomName { get; set; }

        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }

        [Display(Name = "离室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? OutDepartmentTime { get; set; }

        [Display(Name = "停留时长")]
        [DisplayFormat(DataFormatString = "{0:g}")]
        public TimeSpan? During { get; set; }
    }
}