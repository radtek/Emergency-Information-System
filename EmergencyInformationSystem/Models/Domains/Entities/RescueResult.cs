using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 抢救效果。
    /// </summary>
    /// <remarks>表示抢救室病例进行抢救后的结果。</remarks>
    [Table("RescueResults")]
    public class RescueResult
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="RescueResult"/>。
        /// </summary>
        public RescueResult()
        {
        }

        #endregion





        #region 实体属性

        /// <summary>
        /// 抢救效果ID。
        /// </summary>
        [Key]
        public virtual int RescueResultId { get; set; }





        /// <summary>
        /// 抢救效果名称。
        /// </summary>
        [Display(Name = "抢救效果")]
        public virtual string RescueResultName { get; set; }

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