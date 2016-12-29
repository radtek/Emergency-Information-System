using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 转院原因。
    /// </summary>
    /// <remarks>转院原因。表示各室转院病例的转院原因。</remarks>
    [Table("TransferReasons")]
    public class TransferReason
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="TransferReason"/>。
        /// </summary>
        public TransferReason()
        {
        }

        #endregion





        #region 实体属性

        /// <summary>
        /// 转院原因ID。
        /// </summary>
        [Key]
        public virtual int TransferReasonId { get; set; }





        /// <summary>
        /// 转院原因名称。
        /// </summary>
        [Display(Name = "转院原因")]
        public virtual string TransferReasonName { get; set; }

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