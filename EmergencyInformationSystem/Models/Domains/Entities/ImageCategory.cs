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
    [Table("ImageCategories")]
    public class ImageCategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageCategory"/> class.
        /// </summary>
        public ImageCategory()
        {

        }





        /// <summary>
        /// 影像类型ID。
        /// </summary>
        public virtual int ImageCategoryId { get; set; }





        /// <summary>
        /// 影像类型名称。
        /// </summary>
        [Display(Name = "影像类型")]
        public virtual string ImageCategoryName { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }
    }
}