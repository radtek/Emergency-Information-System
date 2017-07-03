using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 影像类型。
    /// </summary>
    /// <remarks>表示抢救室影像项的影像类型。需人工添加记录。</remarks>
    [Table("ImageCategories")]
    public class ImageCategory
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="ImageCategory"/>。
        /// </summary>
        public ImageCategory()
        {
        }

        #endregion





        #region 实体属性

        /// <summary>
        /// 影像类型ID。
        /// </summary>
        [Key]
        public virtual int ImageCategoryId { get; set; }





        /// <summary>
        /// 影像类型名称。
        /// </summary>
        [Display(Name = "影像类型")]
        public virtual string ImageCategoryName { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }

        #endregion
    }
}