using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains2.Entities
{
    [Table("DrugRecords")]
    public class DrugRecord
    {
        public DrugRecord()
        {

        }





        [Key]
        public virtual Guid DrugRecordId { get; set; }

        [ForeignKey("GeneralRoomInfo")]
        public virtual Guid GeneralRoomInfoId { get; set; }





        public virtual string ProductCode { get; set; }

        public virtual string ProductName { get; set; }

        public virtual string GoodsName { get; set; }

        public virtual decimal DosageQuantity { get; set; }

        public virtual string DosageUnit { get; set; }

        public virtual DateTime? PrescriptionTime { get; set; }

        public virtual string Usage { get; set; }





        [Index(IsUnique = true)]
        public virtual Guid CFMXID { get; set; }

        public virtual Guid CFID { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        public virtual GeneralRoomInfo GeneralRoomInfo { get; set; }
    }
}
