using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains2.Entities
{
    [Table("Consultation")]
    public class Consultation
    {
        public Consultation()
        {

        }





        [Key]
        public virtual Guid ConsultationId { get; set; }

        [ForeignKey("GeneralRoomInfo")]
        public virtual Guid GeneralRoomInfoId { get; set; }





        public virtual DateTime RequestTime { get; set; }

        public virtual DateTime? ArriveTime { get; set; }

        [Required(AllowEmptyStrings = false)]
        public virtual string ConsultationDoctorName { get; set; }

        [ForeignKey("ConsultationDepartment")]
        public virtual Guid ConsultationDepartmentId { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        public virtual GeneralRoomInfo GeneralRoomInfo { get; set; }

        public virtual Destination ConsultationDepartment { get; set; }





        public TimeSpan? DuringRequestToArrive
        {
            get
            {
                return this.ArriveTime - this.RequestTime;
            }
        }
    }
}
