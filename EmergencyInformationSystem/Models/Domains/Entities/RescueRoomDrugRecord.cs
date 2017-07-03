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
    /// <remarks>抢救室病例的用药项。</remarks>
    [Table("RescueRoomDrugRecords")]
    public class RescueRoomDrugRecord
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="RescueRoomDrugRecord"/>。
        /// </summary>
        public RescueRoomDrugRecord()
        {
        }

        #endregion





        #region 实体属性

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
        /// 项目代码。
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
        /// 用法。
        /// </summary>
        [Display(Name = "用法")]
        public virtual string Usage { get; set; }





        /// <summary>
        /// “创星”“处方明细ID”。
        /// </summary>
        /// <remarks>dbo.MZ_CFMXB的CFMXID。</remarks>
        public virtual Guid CFMXID { get; set; }

        /// <summary>
        /// “创星”“处方ID”。
        /// </summary>
        /// <remarks>dbo.MZ_CFMXB的CFID。可以用于分组——相同的为一组。</remarks>
        public virtual Guid CFID { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }

        #endregion





        #region 导航属性

        /// <summary>
        /// 归属的抢救室病例。
        /// </summary>
        public virtual RescueRoomInfo RescueRoomInfo { get; set; }

        #endregion





        #region 实例属性

        /// <summary>
        /// 用量-完整。
        /// </summary>
        [Display(Name = "用量")]
        public string DosageQuantityFull
        {
            get
            {
                return this.DosageQuantity + " " + this.DosageUnit;
            }
        }

        #endregion
    }
}