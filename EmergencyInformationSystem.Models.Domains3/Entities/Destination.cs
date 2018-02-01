using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains3.Entities
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





        public virtual bool IsUseForRescueRoom { get; set; }

        public virtual bool IsUseForObserveRoom { get; set; }

        public virtual bool IsUseForResuscitateRoom { get; set; }





        public virtual bool IsUseForSubscription { get; set; }

        public virtual bool IsUseForConsultation { get; set; }





        public virtual bool IsToInDepartment { get; set; }

        public virtual bool IsToOutDepartment { get; set; }

        public virtual bool IsToLeave { get; set; }

        public virtual bool IsToOther { get; set; }





        public virtual bool IsHasAdditionalInfo { get; set; }





        public virtual bool IsTransferHospital { get; set; }

        public virtual bool IsNeedProfessional { get; set; }

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
