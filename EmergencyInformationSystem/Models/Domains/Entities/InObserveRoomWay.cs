using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 进入留观室方式。
    /// </summary>
    /// <remarks>留观室专用的入室方式。</remarks>
    [Table("InObserveRoomWays")]
    public class InObserveRoomWay
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="InObserveRoomWay"/>。
        /// </summary>
        public InObserveRoomWay()
        {
        }

        #endregion





        #region 实体属性

        /// <summary>
        /// 进入留观室方式ID。
        /// </summary>
        [Key]
        public virtual int InObserveRoomWayId { get; set; }





        /// <summary>
        /// 进入留观室方式名称。
        /// </summary>
        [Display(Name = "入室方式")]
        public virtual string InObserveRoomWayName { get; set; }

        /// <summary>
        /// 是否有额外信息。
        /// </summary>
        public virtual bool IsHasAdditionalInfo { get; set; }

        /// <summary>
        /// 是否用于表示空。
        /// </summary>
        public virtual bool IsUseForEmpty { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }

        #endregion
    }
}