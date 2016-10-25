using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 进入抢救室方式。
    /// </summary>
    [Table("InRescueRoomWays")]
    public class InRescueRoomWay
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InRescueRoomWay"/> class.
        /// </summary>
        public InRescueRoomWay()
        {

        }





        /// <summary>
        /// 进入抢救室方式ID。
        /// </summary>
        [Key]
        public virtual int InRescueRoomWayId { get; set; }





        /// <summary>
        /// 进入抢救室方式名称。
        /// </summary>
        [Display(Name = "入室方式")]
        public virtual string InRescueRoomWayName { get; set; }

        /// <summary>
        /// 是否有额外信息。
        /// </summary>
        public virtual bool IsHasAdditionalInfo { get; set; }

        /// <summary>
        /// 是否用于空。
        /// </summary>
        public virtual bool IsUseForEmpty { get; set; }



        

        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }
    }
}