using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains2.Entities
{
    [Table("TransferReasons")]
    public class TransferReason
    {
        public TransferReason()
        {

        }





        [Key]
        public virtual Guid TransferReasonId { get; set; }





        [Required(AllowEmptyStrings = false)]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string TransferReasonName { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }
    }
}
