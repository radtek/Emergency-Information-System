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
    [Table("GreenPathCategories")]
    public class GreenPathCategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GreenPathCategory"/> class.
        /// </summary>
        public GreenPathCategory()
        {

        }





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
    }
}