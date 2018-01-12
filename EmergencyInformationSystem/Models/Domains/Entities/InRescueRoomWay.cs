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
    /// <remarks>抢救室专用的入室方式。</remarks>
    [Table("InRescueRoomWays")]
    public class InRescueRoomWay
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="InRescueRoomWay"/>。
        /// </summary>
        public InRescueRoomWay()
        {
        }

        #endregion





        #region 实体属性

        /// <summary>
        /// 进入抢救室方式ID。
        /// </summary>
        [Key]
        public virtual Guid InRescueRoomWayId { get; set; }





        /// <summary>
        /// 进入抢救室方式名称。
        /// </summary>
        //[Display(Name = "入室方式")]
        [Required(AllowEmptyStrings = false)]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string InRescueRoomWayName { get; set; }

        /// <summary>
        /// 是否有额外信息。
        /// </summary>
        public virtual bool IsHasAdditionalInfo { get; set; }

        ///// <summary>
        ///// 是否用于表示空。
        ///// </summary>
        //public virtual bool IsUseForEmpty { get; set; }

        public virtual int Priority { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }

        #endregion
    }
}