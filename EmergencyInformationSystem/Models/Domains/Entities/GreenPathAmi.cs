using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 绿色通道-急性心肌梗死。
    /// </summary>
    /// <remarks>绿色通道-急性心肌梗死。表示抢救室病例的绿色通道-急性心肌梗死的信息。</remarks>
    [Table("GreenPathAmis")]
    public class GreenPathAmi
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="GreenPathAmi"/>。
        /// </summary>
        public GreenPathAmi()
        {
        }

        #endregion





        #region 实体属性

        /// <summary>
        /// 绿色通道-急性心肌梗死ID。
        /// </summary>
        [Key]
        public virtual Guid GreenPathAmiId { get; set; }





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
        /// 首次心电图时间。
        /// </summary>
        [Display(Name = "首次心电图时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public virtual DateTime? EcgFirstTime { get; set; }

        /// <summary>
        /// 再次心电图时间。
        /// </summary>
        [Display(Name = "再次心电图时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public virtual DateTime? EcgSecondTime { get; set; }

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
        /// 是否滞留。
        /// </summary>
        [Display(Name = "滞留")]
        public virtual bool IsHeldUp { get; set; }

        /// <summary>
        /// 存在问题。
        /// </summary>
        [Display(Name = "存在问题")]
        public virtual string Problem { get; set; }





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

        /// <summary>
        /// 是否完成通道。
        /// </summary>
        public bool IsFinished
        {
            get
            {
                return this.FinishPathTime.HasValue;
            }
        }

        #endregion
    }
}