using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains2.Entities
{
    [Table("GeneralRoomInfos")]
    public class GeneralRoomInfo
    {
        public GeneralRoomInfo()
        {

        }





        [Key]
        public virtual Guid GeneralRoomInfoId { get; set; }

        [ForeignKey("Room")]
        public virtual Guid RoomId { get; set; }





        public virtual string PatientName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public virtual string OutPatientNumber { get; set; }

        public virtual string Sex { get; set; }

        public virtual DateTime? BirthDate { get; set; }

        public virtual string DiagnosisNameOrigin { get; set; }

        public virtual DateTime? ReceiveTime { get; set; }

        public virtual string FirstDoctorName { get; set; }





        public virtual DateTime InDepartmentTime { get; set; }

        public virtual string BedNumber { get; set; }

        [ForeignKey("Bed")]
        public virtual Guid? BedId { get; set; }

        public virtual string FirstNurseName { get; set; }

        [ForeignKey("InRoomWay")]
        public virtual Guid? InRoomWayId { get; set; }

        public virtual string InRoomWayRemarks { get; set; }

        public virtual string AdditionalDiagnosis { get; set; }





        [ForeignKey("CriticalLevel")]
        public virtual Guid? CriticalLevelId { get; set; }

        public virtual bool IsRescue { get; set; }

        [ForeignKey("RescueResult")]
        public virtual Guid? RescueResultId { get; set; }

        [ForeignKey("GreenPathCategory")]
        public virtual Guid? GreenPathCategoryId { get; set; }

        public virtual string GreenPathCategoryRemarks { get; set; }

        public virtual string Antibiotic { get; set; }

        public virtual string Remarks { get; set; }





        [ForeignKey("DestinationFirst")]
        public virtual Guid? DestinationFirstId { get; set; }

        public virtual DateTime? DestinationFirstTime { get; set; }

        public virtual string DestinationFirstContact { get; set; }

        [ForeignKey("DestinationSecond")]
        public virtual Guid? DestinationSecondId { get; set; }





        public virtual DateTime? OutDepartmentTime { get; set; }

        [ForeignKey("Destination")]
        public virtual Guid? DestinationId { get; set; }

        public virtual string DestinationRemarks { get; set; }

        public virtual string HandleNurse { get; set; }

        public virtual string DiagnosisName { get; set; }

        [ForeignKey("TransferReason")]
        public virtual Guid? TransferReasonId { get; set; }

        public virtual string TransferTarget { get; set; }

        public virtual string ProfessionalTarget { get; set; }





        public virtual Guid? KDJID { get; set; }

        public virtual Guid? BRXXID { get; set; }

        public virtual Guid? GHXXID { get; set; }

        [Index(IsUnique = true)]
        public virtual Guid? JZID { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        public virtual Room Room { get; set; }

        public virtual Bed Bed { get; set; }

        public virtual InRoomWay InRoomWay { get; set; }

        public virtual CriticalLevel CriticalLevel { get; set; }

        public virtual RescueResult RescueResult { get; set; }

        public virtual GreenPathCategory GreenPathCategory { get; set; }

        public virtual Destination DestinationFirst { get; set; }

        public virtual Destination DestinationSecond { get; set; }

        public virtual Destination Destination { get; set; }

        public virtual TransferReason TransferReason { get; set; }
    }
}
