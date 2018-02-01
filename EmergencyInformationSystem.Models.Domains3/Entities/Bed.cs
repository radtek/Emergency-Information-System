using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains3.Entities
{
    [Table("Beds")]
    public class Bed
    {
        public Bed()
        {

        }





        [Key]
        public virtual Guid BedId { get; set; }





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
