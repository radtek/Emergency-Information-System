using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 绿色通道类型。
    /// </summary>
    /// <remarks>绿色通道类型。表示抢救室病例归属的绿色通道类型，包括空值。</remarks>
    [Table("GreenPathCategories")]
    public class GreenPathCategory
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="GreenPathCategory"/>。
        /// </summary>
        public GreenPathCategory()
        {
        }

        #endregion





        #region 实体属性
        
        /// <summary>
        /// 绿色通道类型ID。
        /// </summary>
        [Key]
        public virtual int GreenPathCategoryId { get; set; }





        /// <summary>
        /// 绿色通道类型名称。
        /// </summary>
        [Display(Name = "绿色通道")]
        public virtual string GreenPathCategoryName { get; set; }

        /// <summary>
        /// 是否有额外信息。
        /// </summary>
        public virtual bool IsHasAdditionalInfo { get; set; }

        /// <summary>
        /// 是否用于表示空。
        /// </summary>
        public virtual bool IsUseForEmpty { get; set; }

        /// <summary>
        /// 代码名称。
        /// </summary>
        /// <remarks>用于程序内部。</remarks>
        public virtual string CodeName { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }

        #endregion
    }
}