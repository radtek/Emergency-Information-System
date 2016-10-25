using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 危重等级。
    /// </summary>
    [Table("CriticalLevels")]
    public class CriticalLevel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CriticalLevel"/> class.
        /// </summary>
        public CriticalLevel()
        {

        }





        /// <summary>
        /// 危重等级ID。
        /// </summary>
        [Key]
        public virtual int CriticalLevelId { get; set; }





        /// <summary>
        /// 危重等级名称。
        /// </summary>
        [Display(Name = "危重等级")]
        public virtual string CriticalLevelName { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }
    }
}