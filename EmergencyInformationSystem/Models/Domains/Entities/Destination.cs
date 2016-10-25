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
    /// <remarks>包含科室和非科室。</remarks>
    [Table("Destinations")]
    public class Destination
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Destination"/> class.
        /// </summary>
        public Destination()
        {

        }





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
        /// 是否用于空。
        /// </summary>
        public virtual bool IsUseForEmpty { get; set; }

        /// <summary>
        /// 是否有额外信息。
        /// </summary>
        public virtual bool IsHasAdditionalInfo { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        /// <summary>
        /// 用于表示的去向分类。
        /// </summary>
        /// <remarks>如果同时归属多个分类，则用“|”分割。</remarks>
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
    }
}