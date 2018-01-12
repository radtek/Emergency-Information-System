using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 抢救室治疗项定义项。
    /// </summary>
    /// <remarks>抢救室治疗项定义项。用于处理需要提取为抢救室治疗项的项目。</remarks>
    [Table("RescueRoomTreatmentRecordDefinitions")]
    public class RescueRoomTreatmentRecordDefinition
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="RescueRoomTreatmentRecordDefinition"/>。
        /// </summary>
        public RescueRoomTreatmentRecordDefinition()
        {
        }

        #endregion





        #region 实体属性

        /// <summary>
        /// 抢救室治疗项定义项ID。
        /// </summary>
        [Key]
        public virtual Guid RescueRoomTreatmentRecordDefinitionId { get; set; }





        /// <summary>
        /// 治疗代码。
        /// </summary>
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string TreatmentCode { get; set; }

        /// <summary>
        /// 治疗名称。
        /// </summary>
        public virtual string TreatmentName { get; set; }

        /// <summary>
        /// 绿色通道代码名称。
        /// </summary>
        public virtual string GreenPathCode { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }

        #endregion
    }
}