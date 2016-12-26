using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 危重等级。
    /// </summary>
    /// <remarks>危重等级。表示在门诊分诊时所划分的等级，即入室时的危重等级。</remarks>
    [Table("CriticalLevels")]
    public class CriticalLevel
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="CriticalLevel"/>。
        /// </summary>
        public CriticalLevel()
        {
        }

        #endregion





        #region 实体属性

        /// <summary>
        /// 危重等级ID。
        /// </summary>
        [Key]
        public virtual int CriticalLevelId { get; set; }





        /// <summary>
        /// 危重等级名称。
        /// </summary>
        [Display(Name = "危重等级")]
        public virtual string CriticalLevelName { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }

        #endregion
    }
}