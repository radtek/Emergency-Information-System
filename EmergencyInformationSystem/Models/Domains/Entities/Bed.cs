using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 床位。
    /// </summary>
    [Table("Beds")]
    public class Bed
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bed"/> class.
        /// </summary>
        public Bed()
        {

        }





        /// <summary>
        /// 床位ID。
        /// </summary>
        [Key]
        public virtual int BedId { get; set; }





        /// <summary>
        /// 床位名称。
        /// </summary>
        [Display(Name = "床位")]
        public virtual string BedName { get; set; }

        /// <summary>
        /// 是否用于抢救室。
        /// </summary>
        public virtual bool IsUseForRescueRoom { get; set; }

        /// <summary>
        /// 是否用于留观室。
        /// </summary>
        public virtual bool IsUseForObserveRoom { get; set; }

        /// <summary>
        /// 是否用于表示空。
        /// </summary>
        public virtual bool IsUseForEmpty { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }
    }
}