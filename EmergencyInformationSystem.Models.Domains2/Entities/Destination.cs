using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains2.Entities
{
    [Table("Destinations")]
    public class Destination
    {
        public Destination()
        {

        }





        [Key]
        public virtual Guid DestinationId { get; set; }





        [Required(AllowEmptyStrings = false)]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string DestinationName { get; set; }

        public virtual int Priority2 { get; set; }

        public virtual DestinationCode DestinationCode { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }
    }
}
