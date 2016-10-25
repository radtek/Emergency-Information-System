using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 抢救室用药项。
    /// </summary>
    [Table("RescueRoomDrugRecords")]
    public class RescueRoomDrugRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RescueRoomDrugRecord"/> class.
        /// </summary>
        public RescueRoomDrugRecord()
        {

        }





        /// <summary>
        /// 抢救室用药项ID。
        /// </summary>
        [Key]
        public virtual Guid RescueRoomDrugRecordId { get; set; }





        /// <summary>
        /// 归属的抢救室病例ID。
        /// </summary>
        [ForeignKey("RescueRoomInfo")]
        public virtual int RescueRoomInfoId { get; set; }





        /// <summary>
        /// 代码。
        /// </summary>
        [Display(Name = "代码")]
        public virtual string ProductCode { get; set; }

        /// <summary>
        /// 品名。
        /// </summary>
        [Display(Name = "品名")]
        public virtual string ProductName { get; set; }

        /// <summary>
        /// 商品名。
        /// </summary>
        [Display(Name = "商品名")]
        public virtual string GoodsName { get; set; }

        /// <summary>
        /// 用量。
        /// </summary>
        [Display(Name = "用量")]
        public virtual decimal DosageQuantity { get; set; }

        /// <summary>
        /// 用量单位。
        /// </summary>
        [Display(Name = "用量单位")]
        public virtual string DosageUnit { get; set; }

        /// <summary>
        /// 处方时间。
        /// </summary>
        [Display(Name = "处方时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public virtual DateTime? PrescriptionTime { get; set; }





        /// <summary>
        /// “创新”“处方明细ID”。
        /// </summary>
        /// <remarks>dbo.MZ_CFMXB的CFMXID。</remarks>
        public virtual Guid CFMXID { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        /// <summary>
        /// 归属的抢救室病例。
        /// </summary>
        public virtual RescueRoomInfo RescueRoomInfo { get; set; }
    }
}