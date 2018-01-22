using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains2.Entities
{
    [Table("ImageCategories")]
    public class ImageCategory
    {
        public ImageCategory()
        {

        }





        [Key]
        public virtual Guid ImageCategoryId { get; set; }





        [Required(AllowEmptyStrings = false)]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string ImageCategoryName { get; set; }





        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string OriginCode { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }
    }
}
