using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 床位。
    /// </summary>
    /// <remarks>
    /// 表示各室的床位。各室通用。通过指定字段标识可使用室。
    /// </remarks>
    [Table("Beds")]
    public class Bed
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="Bed"/>。
        /// </summary>
        public Bed()
        {
        }

        #endregion





        #region 实体属性

        /// <summary>
        /// 床位ID。
        /// </summary>
        [Key]
        public virtual Guid BedId { get; set; }





        /// <summary>
        /// 床位名称。
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string BedName { get; set; }

        /// <summary>
        /// 是否用于抢救室。
        /// </summary>
        public virtual bool IsUseForRescueRoom { get; set; }

        /// <summary>
        /// 是否用于留观室。
        /// </summary>
        public virtual bool IsUseForObserveRoom { get; set; }

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