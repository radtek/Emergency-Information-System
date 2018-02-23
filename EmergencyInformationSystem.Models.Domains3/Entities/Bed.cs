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
    /// 床位。
    /// </summary>
    /// <remarks>
    /// 表示各室的床位。各室通用。通过指定字段标识可使用室。
    /// </remarks>
    [Table("Beds")]
    public class Bed
    {
        public Bed()
        {

        }





        [Key]
        public virtual Guid BedId { get; set; }





        /// <summary>
        /// 床位名称。
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string BedName { get; set; }

        public virtual int Priority { get; set; }





        public virtual bool IsUseForRescueRoom { get; set; }

        public virtual bool IsUseForObserveRoom { get; set; }

        public virtual bool IsUseForResuscitateRoom { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }
    }
}
