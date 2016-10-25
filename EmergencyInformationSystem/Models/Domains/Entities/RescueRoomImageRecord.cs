using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 抢救室影像项。
    /// </summary>
    [Table("RescueRoomImageRecords")]
    public class RescueRoomImageRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RescueRoomImageRecord"/> class.
        /// </summary>
        public RescueRoomImageRecord()
        {

        }





        /// <summary>
        /// 抢救室影像项ID。
        /// </summary>
        [Key]
        public virtual Guid RescueRoomImageRecordId { get; set; }





        /// <summary>
        /// 归属的抢救室病例ID。
        /// </summary>
        [ForeignKey("RescueRoomInfo")]
        public virtual int RescueRoomInfoId { get; set; }





        /// <summary>
        /// 登记时间。
        /// </summary>
        [Display(Name = "登记时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public virtual DateTime? BookTime { get; set; }

        /// <summary>
        /// 检查时间。
        /// </summary>
        [Display(Name = "检查时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public virtual DateTime? CheckTime { get; set; }

        /// <summary>
        /// 报告时间。
        /// </summary>
        [Display(Name = "报告时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public virtual DateTime? ReportTime { get; set; }

        /// <summary>
        /// 检查部位。
        /// </summary>
        [Display(Name = "检查部位")]
        public virtual string Part { get; set; }

        /// <summary>
        /// 检查项目。
        /// </summary>
        [Display(Name = "检查项目")]
        public virtual string Category { get; set; }

        /// <summary>
        /// 影像类型ID。
        /// </summary>
        /// <remarks>原始字段本地解析。</remarks>
        [ForeignKey("ImageCategory")]
        public virtual int ImageCategoryId { get; set; }





        /// <summary>
        /// “PACS系统”“ID”。
        /// </summary>
        public virtual string BOOKID { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        /// <summary>
        /// 归属的抢救室病例。
        /// </summary>
        public virtual RescueRoomInfo RescueRoomInfo { get; set; }

        /// <summary>
        /// 影像类型。
        /// </summary>
        public virtual ImageCategory ImageCategory { get; set; }
    }
}