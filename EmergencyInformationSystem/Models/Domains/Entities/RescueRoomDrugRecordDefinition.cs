using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 抢救室用药项定义项。
    /// </summary>
    /// <remarks>抢救室用药项定义项。用于处理需要提取为抢救室用药项的药品。</remarks>
    [Table("RescueRoomDrugRecordDefinitions")]
    public class RescueRoomDrugRecordDefinition
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="RescueRoomDrugRecordDefinition"/>。
        /// </summary>
        public RescueRoomDrugRecordDefinition()
        {
        }

        #endregion





        #region 实体属性

        /// <summary>
        /// 抢救室用药项定义项ID。
        /// </summary>
        [Key]
        public virtual int RescueRoomDrugRecordDefinitionId { get; set; }





        /// <summary>
        /// 药品代码。
        /// </summary>
        public virtual string DrugCode { get; set; }

        /// <summary>
        /// 药品名称。
        /// </summary>
        public virtual string DrugName { get; set; }

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