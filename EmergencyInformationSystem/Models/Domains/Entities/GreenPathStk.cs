using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 绿色通道——急性脑卒中。
    /// </summary>
    [Table("GreenPathStks")]
    public class GreenPathStk
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GreenPathStk"/> class.
        /// </summary>
        public GreenPathStk()
        {

        }




        /// <summary>
        /// 绿色通道——急性脑卒中ID。
        /// </summary>
        [Key]
        public virtual Guid GreenPathStkId { get; set; }





        /// <summary>
        /// 归属的抢救室病例ID。
        /// </summary>
        [ForeignKey("RescueRoomInfo")]
        public virtual int RescueRoomInfoId { get; set; }





        /// <summary>
        /// 发病时间。
        /// </summary>
        [Display(Name = "发病时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public virtual DateTime? OccurrenceTime { get; set; }





        /// <summary>
        /// 备注。
        /// </summary>
        [Display(Name = "备注")]
        public virtual string Remarks { get; set; }





        /// <summary>
        /// 完成通道时间。
        /// </summary>
        [Display(Name = "完成通道时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public virtual DateTime? FinishPathTime { get; set; }

        /// <summary>
        /// 存在问题。
        /// </summary>
        [Display(Name = "存在问题")]
        public virtual string Problem { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        /// <summary>
        /// 归属的抢救室病例。
        /// </summary>
        public virtual RescueRoomInfo RescueRoomInfo { get; set; }





        /// <summary>
        /// 通道停留时长。
        /// </summary>
        [Display(Name = "通道停留时长")]
        public TimeSpan? During
        {
            get
            {
                if (this.FinishPathTime != null)
                    return this.FinishPathTime - this.RescueRoomInfo.InDepartmentTime;
                else
                    return null;
            }
        }
    }
}