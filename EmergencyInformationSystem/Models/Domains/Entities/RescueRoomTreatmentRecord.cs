using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 抢救室治疗项。
    /// </summary>
    /// <remarks>抢救室治疗项。抢救室病例的治疗项。</remarks>
    [Table("RescueRoomTreatmentRecords")]
    public class RescueRoomTreatmentRecord
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="RescueRoomTreatmentRecord"/>。
        /// </summary>
        public RescueRoomTreatmentRecord()
        {
        }

        #endregion





        #region 实体属性

        /// <summary>
        /// 抢救室治疗项ID。
        /// </summary>
        [Key]
        public virtual Guid RescueRoomTreatmentRecordId { get; set; }





        /// <summary>
        /// 归属的抢救室病例ID。
        /// </summary>
        [ForeignKey("RescueRoomInfo")]
        public virtual Guid RescueRoomInfoId { get; set; }





        /// <summary>
        /// 项目代码。
        /// </summary>
        //[Display(Name = "代码")]
        public virtual string ProductCode { get; set; }

        /// <summary>
        /// 品名。
        /// </summary>
        //[Display(Name = "品名")]
        public virtual string ProductName { get; set; }

        /// <summary>
        /// 商品名。
        /// </summary>
        //[Display(Name = "商品名")]
        public virtual string GoodsName { get; set; }

        /// <summary>
        /// 用量。
        /// </summary>
        //[Display(Name = "用量")]
        public virtual decimal DosageQuantity { get; set; }

        /// <summary>
        /// 用量单位。
        /// </summary>
        //[Display(Name = "用量单位")]
        public virtual string DosageUnit { get; set; }

        /// <summary>
        /// 处方时间。
        /// </summary>
        //[Display(Name = "处方时间")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public virtual DateTime? PrescriptionTime { get; set; }

        /// <summary>
        /// 用法。
        /// </summary>
        //[Display(Name = "用法")]
        public virtual string Usage { get; set; }





        /// <summary>
        /// “创新”“处方明细ID”。
        /// </summary>
        /// <remarks>dbo.MZ_CFMXB的CFMXID。</remarks>
        [Index(IsUnique = true)]
        public virtual Guid CFMXID { get; set; }

        /// <summary>
        /// “创新”“处方ID”。
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
    }
}