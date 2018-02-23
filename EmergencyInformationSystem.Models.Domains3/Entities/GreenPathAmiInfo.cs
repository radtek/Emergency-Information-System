using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains3.Entities
{
    /// <summary>
    /// 急性心肌梗死。
    /// </summary>
    [Table("GreenPathAmiInfos")]
    public class GreenPathAmiInfo
    {
        public GreenPathAmiInfo()
        {

        }





        /// <summary>
        /// 急性心肌梗死ID。
        /// </summary>
        [Key]
        public virtual Guid GreenPathAmiInfoId { get; set; }





        /// <summary>
        /// 所属通用病例ID。
        /// </summary>
        [ForeignKey("GeneralRoomInfo")]
        [Index(IsUnique = true)]
        public virtual Guid GeneralRoomInfoId { get; set; }





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





        public virtual GeneralRoomInfo GeneralRoomInfo { get; set; }





        /// <summary>
        /// 发病到入室时长。
        /// </summary>
        public TimeSpan? DuringOccurrenceToInDepartment
        {
            get
            {
                if (this.OccurrenceTime.HasValue)
                    return this.GeneralRoomInfo.InDepartmentTime - this.OccurrenceTime;
                else
                    return null;
            }
        }

        /// <summary>
        /// 入室到接诊时长。
        /// </summary>
        public TimeSpan? DuringInDepartmentToReceive
        {
            get
            {
                if (this.GeneralRoomInfo.ReceiveTime.HasValue)
                    return this.GeneralRoomInfo.ReceiveTime - this.GeneralRoomInfo.InDepartmentTime;
                else
                    return null;
            }
        }

        /// <summary>
        /// 入室到首次心电图时长。
        /// </summary>
        public TimeSpan? DuringInDepartmentToEcgFirst
        {
            get
            {
                if (this.EcgFirstTime.HasValue)
                    return this.EcgFirstTime - this.GeneralRoomInfo.InDepartmentTime;
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
                    return this.EcgSecondTime - this.GeneralRoomInfo.InDepartmentTime;
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
                    return this.FinishPathTime - this.GeneralRoomInfo.InDepartmentTime;
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
        public string IsHeldUpString
        {
            get
            {
                return this.IsHeldUp ? "是" : "否";
            }
        }

        /// <summary>
        /// 通道滞留时长。（完成通道至离室时长）
        /// </summary>
        public TimeSpan? DuringPathHeldUp
        {
            get
            {
                return this.GeneralRoomInfo.OutDepartmentTime - this.FinishPathTime;
            }
        }
    }
}