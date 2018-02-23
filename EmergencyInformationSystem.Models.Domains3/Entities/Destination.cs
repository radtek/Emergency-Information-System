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
    /// 去向。
    /// </summary>
    /// <remarks>表示离室后病人的去向，包括科室和非科室。各室通用。通过指定字段标识可使用室。</remarks>
    [Table("Destinations")]
    public class Destination
    {
        public Destination()
        {

        }





        [Key]
        public virtual Guid DestinationId { get; set; }





        /// <summary>
        /// 去向名称。
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string DestinationName { get; set; }

        public virtual int Priority2 { get; set; }





        public virtual bool IsUseForRescueRoom { get; set; }

        public virtual bool IsUseForObserveRoom { get; set; }

        public virtual bool IsUseForResuscitateRoom { get; set; }





        /// <summary>
        /// 是否用于预约。
        /// </summary>
        public virtual bool IsUseForSubscription { get; set; }

        /// <summary>
        /// 是否用于会诊。
        /// </summary>
        public virtual bool IsUseForConsultation { get; set; }





        public virtual bool IsToInDepartment { get; set; }

        public virtual bool IsToOutDepartment { get; set; }

        public virtual bool IsToLeave { get; set; }

        public virtual bool IsToOther { get; set; }





        public virtual bool IsHasAdditionalInfo { get; set; }





        /// <summary>
        /// 是否转院。
        /// </summary>
        public virtual bool IsTransferHospital { get; set; }

        /// <summary>
        /// 是否专科。
        /// </summary>
        public virtual bool IsNeedProfessional { get; set; }

        /// <summary>
        /// 是否转室。
        /// </summary>
        public virtual bool IsTransferRoom { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        //public string DestinationCategoryNameConcat
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
