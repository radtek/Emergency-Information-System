using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains2.Entities
{
    [Table("Rooms")]
    public class Room
    {
        public Room()
        {
            this.GeneralRoomInfos = new List<GeneralRoomInfo>();
        }





        [Key]
        public virtual Guid RoomId { get; set; }





        [Required(AllowEmptyStrings = false)]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string RoomName { get; set; }

        public virtual RoomCode RoomCode { get; set; }

        public virtual string ControllerName { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        public virtual IEnumerable<GeneralRoomInfo> GeneralRoomInfos { get; set; }
    }
}