using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 去向。
    /// </summary>
    /// <remarks>去向。表示离室后病人的去向，包括科室和非科室。各室通用。通过指定字段标识可使用室。</remarks>
    [Table("Destinations")]
    public class Destination
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="Destination"/>。
        /// </summary>
        public Destination()
        {
        }

        #endregion





        #region 实体属性

        /// <summary>
        /// 去向ID。
        /// </summary>
        [Key]
        public virtual int DestinationId { get; set; }





        /// <summary>
        /// 去向名称。
        /// </summary>
        [Display(Name = "去向")]
        public virtual string DestinationName { get; set; }

        /// <summary>
        /// 是否用于抢救室。
        /// </summary>
        public virtual bool IsUseForRescueRoom { get; set; }

        /// <summary>
        /// 是否用于留观室。
        /// </summary>
        public virtual bool IsUseForObserveRoom { get; set; }

        /// <summary>
        /// 是否用于预约。
        /// </summary>
        public virtual bool IsUseForSubscription { get; set; }

        /// <summary>
        /// 是否用于会诊。
        /// </summary>
        public virtual bool IsUseForConsultation { get; set; }

        /// <summary>
        /// 是否属于住院科室。
        /// </summary>
        public virtual bool IsClassifiedToInDepartment { get; set; }

        /// <summary>
        /// 是否属于门诊科室。
        /// </summary>
        public virtual bool IsClassifiedToOutDepartment { get; set; }

        /// <summary>
        /// 是否属于离去。
        /// </summary>
        public virtual bool IsClassifiedLeave { get; set; }

        /// <summary>
        /// 是否属于其他科室。
        /// </summary>
        public virtual bool IsClassifiedToOther { get; set; }

        /// <summary>
        /// 是否用于表示空。
        /// </summary>
        public virtual bool IsUseForEmpty { get; set; }

        /// <summary>
        /// 优先级。
        /// </summary>
        [Obsolete]
        public virtual bool Priority { get; set; }

        /// <summary>
        /// 优先级2。
        /// </summary>
        public virtual int Priority2 { get; set; }

        /// <summary>
        /// 是否有额外信息。
        /// </summary>
        public virtual bool IsHasAdditionalInfo { get; set; }

        /// <summary>
        /// 是否去往抢救室。
        /// </summary>
        public virtual bool IsGotoRescueRoom { get; set; }

        /// <summary>
        /// 是否去往留观室。
        /// </summary>
        public virtual bool IsGotoObserveRoom { get; set; }

        /// <summary>
        /// 是否转院。
        /// </summary>
        public virtual bool IsTransfer { get; set; }

        /// <summary>
        /// 是否专科。
        /// </summary>
        public virtual bool IsProfessional { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }

        #endregion





        #region 实例属性

        /// <summary>
        /// 去向类别。
        /// </summary>
        /// <remarks>用于表示去向的类别。如果同时归属多个分类，则用“|”串联。</remarks>
        public string DestinationCategoryNameConcat
        {
            get
            {
                string name = string.Empty;

                if (this.IsClassifiedToInDepartment)
                    name += "住院";

                if (this.IsClassifiedToOutDepartment)
                {
                    if (name.Length != 0)
                        name += "|";

                    name += "门诊";
                }

                if (this.IsClassifiedLeave)
                {
                    if (name.Length != 0)
                        name += "|";

                    name += "离开";
                }

                if (this.IsClassifiedToOther)
                {
                    if (name.Length != 0)
                        name += "|";

                    name += "其他";
                }

                return name;
            }
        }

        #endregion
    }
}