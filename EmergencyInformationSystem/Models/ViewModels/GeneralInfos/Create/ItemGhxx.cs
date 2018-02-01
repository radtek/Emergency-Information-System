using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using TrasenLib;

namespace EmergencyInformationSystem.Models.ViewModels.GeneralInfos.Create
{
    public class ItemGhxx
    {
        public ItemGhxx(VI_MZ_GHXX GHXX, Guid roomId, Guid? preGeneralRoomInfoId)
        {
            this.RoomId = roomId;
            this.PreGeneralRoomInfoId = preGeneralRoomInfoId;

            var dbTrasen = new TrasenDbContext("TrasenConnection");

            this.RegisterTime = GHXX.GHSJ;

            var listJZJL = dbTrasen.MZYS_JZJL.Where(c => c.GHXXID == GHXX.GHXXID).OrderByDescending(c => c.JSSJ).ThenBy(c => c.JZID).ToList();

            this.ListJzjl = listJZJL.Select(c => new ItemJzjl(c, this.RoomId, this.PreGeneralRoomInfoId)).ToList();
        }





        public Guid RoomId { get; set; }

        public Guid? PreGeneralRoomInfoId { get; set; }





        [Display(Name = "挂号时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? RegisterTime { get; set; }





        public List<ItemJzjl> ListJzjl { get; set; }
    }
}