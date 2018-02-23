using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains3.Entities
{
    /// <summary>
    /// 入室方式。
    /// </summary>
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





        public virtual bool IsUseForRescueRoom { get; set; }

        public virtual bool IsUseForObserveRoom { get; set; }

        public virtual bool IsUseForResuscitateRoom { get; set; }





        /// <summary>
        /// 是否转室。
        /// </summary>
        public virtual bool IsTransferRoom { get; set; }





        public virtual bool IsHasAdditionalInfo { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }
    }
}