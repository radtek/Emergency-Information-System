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
    /// <remarks>表示抢救室病例的绿色通道-急性心肌梗死的信息。</remarks>
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
        [Index(IsUnique = true)]
        public virtual Guid RescueRoomInfoId { get; set; }





        /// <summary>
        /// 发病时间。
        /// </summary>
        public virtual DateTime? OccurrenceTime { get; set; }





        /// <summary>
        /// 首次心电图时间。
        /// </summary>
        public virtual DateTime? EcgFirstTime { get; set; }

        /// <summary>
        /// 再次心电图时间。
        /// </summary>
        public virtual DateTime? EcgSecondTime { get; set; }

        /// <summary>
        /// 备注。
        /// </summary>
        public virtual string Remarks { get; set; }





        /// <summary>
        /// 完成通道时间。
        /// </summary>
        public virtual DateTime? FinishPathTime { get; set; }

        /// <summary>
        /// 是否滞留。
        /// </summary>
        public virtual bool IsHeldUp { get; set; }

        /// <summary>
        /// 存在问题。
        /// </summary>
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
        /// 发病到入室时长。
        /// </summary>
        //[Display(Name = "发病到入室")]
        public TimeSpan? DuringOccurrenceToInDepartment
        {
            get
            {
                if (this.OccurrenceTime.HasValue)
                    return this.RescueRoomInfo.InDepartmentTime - this.OccurrenceTime;
                else
                    return null;
            }
        }

        /// <summary>
        /// 入室到接诊时长。
        /// </summary>
        //[Display(Name = "入室到接诊")]
        public TimeSpan? DuringInDepartmentToReceive
        {
            get
            {
                if (this.RescueRoomInfo.ReceiveTime.HasValue)
                    return this.RescueRoomInfo.ReceiveTime - this.RescueRoomInfo.InDepartmentTime;
                else
                    return null;
            }
        }

        /// <summary>
        /// 入室到首次心电图时长。
        /// </summary>
        //[Display(Name = "入室到首次心电图")]
        public TimeSpan? DuringInDepartmentToEcgFirst
        {
            get
            {
                if (this.EcgFirstTime.HasValue)
                    return this.EcgFirstTime - this.RescueRoomInfo.InDepartmentTime;
                else
                    return null;
            }
        }

        /// <summary>
        /// 入室到再次心电图时长。
        /// </summary>
        public TimeSpan? DuringInDepartmentToEcgSecond
        {
            get
            {
                if (this.EcgSecondTime.HasValue)
                    return this.EcgSecondTime - this.RescueRoomInfo.InDepartmentTime;
                else
                    return null;
            }
        }

        /// <summary>
        /// 通道停留时长。
        /// </summary>
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

        /// <summary>
        /// 是否滞留名称。
        /// </summary>
        //[Display(Name = "滞留")]
        public string IsHeldUpString
        {
            get
            {
                return this.IsHeldUp ? "是" : "否";
            }
        }

        /// <summary>
        /// 通道滞留时长。
        /// </summary>
        public TimeSpan? DuringPathHeldUp
        {
            get
            {
                return this.RescueRoomInfo.OutDepartmentTime - this.FinishPathTime;
            }
        }

        #endregion
    }
}