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
    /// 危重等级。
    /// </summary>
    /// <remarks>表示在门诊分诊时所划分的等级，即入室时的危重等级。</remarks>
    [Table("CriticalLevels")]
    public class CriticalLevel
    {
        public CriticalLevel()
        {

        }





        [Key]
        public virtual Guid CriticalLevelId { get; set; }





        /// <summary>
        /// 危重等级名称。
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string CriticalLevelName { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }
    }
}
