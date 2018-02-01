using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains3.Entities
{
    [Table("GreenPathCategories")]
    public class GreenPathCategory
    {
        public GreenPathCategory()
        {

        }





        [Key]
        public virtual Guid GreenPathCategoryId { get; set; }





        [Required(AllowEmptyStrings = false)]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string GreenPathCategoryName { get; set; }

        public virtual int Priority { get; set; }





        public virtual bool IsHasAdditionalInfo { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }
    }
}
