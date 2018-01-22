using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains2.Entities
{
    [Table("ImageRecords")]
    public class ImageRecord
    {
        public ImageRecord()
        {

        }





        [Key]
        public virtual Guid ImageRecordId { get; set; }

        [ForeignKey("GeneralRoomInfo")]
        public virtual Guid GeneralRoomInfoId { get; set; }

        [ForeignKey("ImageCategory")]
        public virtual Guid ImageCategoryId { get; set; }





        public virtual DateTime? BookTime { get; set; }

        public virtual DateTime? CheckTime { get; set; }

        public virtual DateTime? ReportTime { get; set; }

        public virtual string Part { get; set; }

        public virtual string Category { get; set; }





        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string BOOKID { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        public virtual GeneralRoomInfo GeneralRoomInfo { get; set; }

        public virtual ImageCategory ImageCategory { get; set; }
    }
}
