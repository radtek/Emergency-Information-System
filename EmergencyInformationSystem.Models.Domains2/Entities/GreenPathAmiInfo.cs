using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains2.Entities
{
    public class GreenPathAmiInfo
    {
        public GreenPathAmiInfo()
        {

        }





        [Key]
        public virtual Guid GreenPathAmiId { get; set; }

        [ForeignKey("GeneralRoomInfo")]
        [Index(IsUnique = true)]
        public virtual Guid GeneralRoomInfoId { get; set; }





        public virtual DateTime? OccurrenceTime { get; set; }





        public virtual DateTime? EcgFirstTime { get; set; }

        public virtual DateTime? EcgSecondTime { get; set; }

        public virtual string Remarks { get; set; }





        public virtual DateTime? FinishPathTime { get; set; }

        public virtual bool IsHeldUp { get; set; }

        public virtual string Problem { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        public virtual GeneralRoomInfo GeneralRoomInfo { get; set; }
    }
}
