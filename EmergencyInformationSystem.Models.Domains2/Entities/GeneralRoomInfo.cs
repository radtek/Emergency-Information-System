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
            this.PostGeneralRoomInfos = new List<GeneralRoomInfo>();
        }





        [Key]
        public virtual Guid GeneralRoomInfoId { get; set; }

        [ForeignKey("Room")]
        public virtual Guid RoomId { get; set; }

        [ForeignKey("PreGeneralRoomInfo")]
        public virtual Guid? PreGeneralRoomInfoId { get; set; }





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





        public virtual GeneralRoomInfo PreGeneralRoomInfo { get; set; }





        [ForeignKey("PreGeneralRoomInfoId")]
        public virtual IEnumerable<GeneralRoomInfo> PostGeneralRoomInfos { get; set; }





        public string ReceiveAgeName
        {
            get
            {
                if (!this.BirthDate.HasValue || !this.ReceiveTime.HasValue)
                    return null;
                else
                {
                    int ageYears;
                    int ageMonths;

                    DateTime upperBound = this.ReceiveTime.Value;

                    ageYears = upperBound.Year - this.BirthDate.Value.Year;
                    ageMonths = upperBound.Month - this.BirthDate.Value.Month;

                    if (ageMonths < 0)
                    {
                        ageMonths += 12;
                        ageYears -= 1;
                    }

                    if (ageYears >= 1)
                    {
                        return ageYears + "岁";
                    }
                    else
                    {
                        return ageMonths + "个月";
                    }
                }
            }
        }

        public string BedNameFull
        {
            get
            {
                return this.BedId == null ? this.BedNumber : this.Bed.BedName;
            }
        }

        public string InRoomWayNameFull
        {
            get
            {
                if (this.InRoomWayId == null)
                    return null;
                else if ((this.InRoomWay.InRoomWayCode & InRoomWayCode.HasAdditionalInfo) == 0)
                    return this.InRoomWay.InRoomWayName;
                else
                    return this.InRoomWay.InRoomWayName + " - " + this.InRoomWayRemarks;
            }
        }

        public string IsGreenPathName
        {
            get
            {
                return this.GreenPathCategoryId.HasValue ? "是" : "否";
            }
        }

        public string GreenPathCategoryNameFull
        {
            get
            {
                if (this.GreenPathCategoryId == null)
                    return null;
                if ((this.GreenPathCategory.GreenPathCategoryCode & GreenPathCategoryCode.HasAdditionalInfo) == 0)
                    return this.GreenPathCategory.GreenPathCategoryName;
                else
                    return this.GreenPathCategory.GreenPathCategoryName + " - " + this.GreenPathCategoryRemarks;
            }
        }

        public string IsRescueName
        {
            get
            {
                return this.IsRescue ? "是" : "否";
            }
        }

        public string RescueResultNameFull
        {
            get
            {
                if (!this.IsRescue)
                    return this.IsRescueName;
                else
                    return this.IsRescueName + " - " + this.RescueResult?.RescueResultName;
            }
        }

        public string IsLeaveName
        {
            get
            {
                return this.OutDepartmentTime.HasValue ? "是" : "否";
            }
        }

        public TimeSpan? During
        {
            get
            {
                return this.OutDepartmentTime - this.InDepartmentTime;
            }
        }

        public DateTime InDepartmentTimeActual
        {
            get
            {
                if (this.PreGeneralRoomInfo == null)
                    return this.InDepartmentTime;
                else
                    return this.PreGeneralRoomInfo.InDepartmentTimeActual;
            }
        }

        public TimeSpan DuringDetained
        {
            get
            {
                if (this.OutDepartmentTime.HasValue)
                    return this.OutDepartmentTime.Value - this.InDepartmentTimeActual;
                else
                    return DateTime.Now - this.InDepartmentTimeActual;
            }
        }

        public int? DuringHours
        {
            get
            {
                return this.During?.Hours + this.During?.Days * 24;
            }
        }

        public string DuringGroupName
        {
            get
            {
                if (!this.DuringHours.HasValue)
                    return "未离室";
                else if (this.DuringHours.Value > 72)
                    return "大于72小时";
                else if (this.DuringHours.Value > 48)
                    return "48至72小时";
                else if (this.DuringHours.Value > 24)
                    return "24至48小时";
                else
                    return "小于等于24小时";
            }
        }

        public string DestinationNameFull
        {
            get
            {
                if (this.DestinationId == null)
                    return null;
                if ((this.Destination.DestinationCode & DestinationCode.HasAdditionalInfo) == DestinationCode.HasAdditionalInfo)
                    return this.Destination.DestinationName + " - " + this.DestinationRemarks;
                else if ((this.Destination.DestinationCode & DestinationCode.TransferHospital) == DestinationCode.TransferHospital)
                    return this.Destination.DestinationName + " - " + this.TransferTarget;
                else
                    return this.Destination.DestinationName;
            }
        }

        public bool? IsGotoFirstSubscription
        {
            get
            {
                if (this.DestinationId == null || this.DestinationFirstId == null)
                    return null;

                if (this.DestinationId == this.DestinationFirstId)
                    return true;

                return false;
            }
        }

        public bool? IsGotoSecondSubscription
        {
            get
            {
                if (this.DestinationId == null || this.DestinationSecondId == null)
                    return null;

                if (this.DestinationId == this.DestinationSecondId)
                    return true;

                return false;
            }
        }

        public bool? IsGotoSubscription
        {
            get
            {
                if (!this.IsGotoFirstSubscription.HasValue || !this.IsGotoSecondSubscription.HasValue)
                    return null;

                return this.IsGotoFirstSubscription.Value || this.IsGotoSecondSubscription.Value;
            }
        }

        public bool IsTransferRoom
        {
            get
            {
                if (this.DestinationId == null)
                    return false;
                if ((this.Destination.DestinationCode & DestinationCode.TransferRoom) == DestinationCode.TransferRoom)
                    return true;
                return false;
            }
        }

        public string GreenPathActionName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Guid? GreenPathId
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}