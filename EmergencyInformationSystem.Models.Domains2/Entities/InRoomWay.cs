using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains2.Entities
{
    [Table("InRoomWays")]
    public class InRoomWay
    {
        public InRoomWay()
        {

        }





        [Key]
        public virtual Guid InRoomWayId { get; set; }





        [Required(AllowEmptyStrings = false)]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string InRoomWayName { get; set; }

        public virtual int Priority { get; set; }

        public virtual InRoomWayCode InRoomWayCode { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }
    }
}
