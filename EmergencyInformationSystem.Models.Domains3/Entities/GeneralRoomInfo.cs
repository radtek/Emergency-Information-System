using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains3.Entities
{
    /// <summary>
    /// 通用病例。
    /// </summary>
    [Table("GeneralRoomInfos")]
    public class GeneralRoomInfo
    {
        public GeneralRoomInfo()
        {
            this.PostGeneralRoomInfos = new List<GeneralRoomInfo>();
            this.GreenPathInfos = new List<GreenPathInfo>();
        }





        /// <summary>
        /// 通用病例ID。
        /// </summary>
        [Key]
        public virtual Guid GeneralRoomInfoId { get; set; }

        /// <summary>
        /// 室ID。
        /// </summary>
        [ForeignKey("Room")]
        public virtual Guid RoomId { get; set; }

        /// <summary>
        /// 前一条连续记录的ID。
        /// </summary>
        [ForeignKey("PreGeneralRoomInfo")]
        public virtual Guid? PreGeneralRoomInfoId { get; set; }





        /// <summary>
        /// 患者姓名。
        /// </summary>
        public virtual string PatientName { get; set; }

        /// <summary>
        /// 卡号。
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public virtual string OutPatientNumber { get; set; }

        /// <summary>
        /// 性别。
        /// </summary>
        public virtual string Sex { get; set; }

        /// <summary>
        /// 出生日期。
        /// </summary>
        public virtual DateTime? BirthDate { get; set; }

        /// <summary>
        /// 入室诊断。
        /// </summary>
        /// <remarks>接诊医师诊断。</remarks>
        public virtual string DiagnosisNameOrigin { get; set; }

        /// <summary>
        /// 接诊时间。
        /// </summary>
        public virtual DateTime? ReceiveTime { get; set; }

        /// <summary>
        /// 首诊医师。
        /// </summary>
        /// <remarks>接诊医师。</remarks>
        public virtual string FirstDoctorName { get; set; }





        /// <summary>
        /// 入室时间。
        /// </summary>
        public virtual DateTime InDepartmentTime { get; set; }

        /// <summary>
        /// 床位号。
        /// </summary>
        /// <remarks>已不使用。仅保存旧数据。应使用BedId。</remarks>
        public virtual string BedNumber { get; set; }

        /// <summary>
        /// 床位ID。
        /// </summary>
        [ForeignKey("Bed")]
        public virtual Guid? BedId { get; set; }

        /// <summary>
        /// 首诊护士姓名。
        /// </summary>
        public virtual string FirstNurseName { get; set; }

        /// <summary>
        /// 入室方式ID。
        /// </summary>
        [ForeignKey("InRoomWay")]
        public virtual Guid? InRoomWayId { get; set; }
        /// <summary>
        /// 入室方式明细。
        /// </summary>
        /// <remarks>有额外信息时才有意义。</remarks>
        public virtual string InRoomWayRemarks { get; set; }

        /// <summary>
        /// 补充诊断。
        /// </summary>
        public virtual string AdditionalDiagnosis { get; set; }





        /// <summary>
        /// 危重等级ID。
        /// </summary>
        [ForeignKey("CriticalLevel")]
        public virtual Guid? CriticalLevelId { get; set; }

        /// <summary>
        /// 是否抢救。
        /// </summary>
        public virtual bool IsRescue { get; set; }

        /// <summary>
        /// 抢救效果ID。
        /// </summary>
        [ForeignKey("RescueResult")]
        public virtual Guid? RescueResultId { get; set; }

        /// <summary>
        /// 绿色通道类型ID。
        /// </summary>  
        [ForeignKey("GreenPathCategory")]
        public virtual Guid? GreenPathCategoryId { get; set; }

        /// <summary>
        /// 绿色通道明细。
        /// </summary>
        /// <remarks>有额外信息时才有意义。</remarks>
        public virtual string GreenPathCategoryRemarks { get; set; }

        /// <summary>
        /// 抗生素。
        /// </summary>
        public virtual string Antibiotic { get; set; }

        /// <summary>
        /// 备注。
        /// </summary>
        public virtual string Remarks { get; set; }





        /// <summary>
        /// 预约首选科室ID。
        /// </summary>
        /// <remarks>为“去向”的ID。</remarks>
        [ForeignKey("DestinationFirst")]
        public virtual Guid? DestinationFirstId { get; set; }

        /// <summary>
        /// 预约首选时间。
        /// </summary>
        public virtual DateTime? DestinationFirstTime { get; set; }

        /// <summary>
        /// 预约首选联系人。
        /// </summary>
        public virtual string DestinationFirstContact { get; set; }

        /// <summary>
        /// 预约次选科室ID。
        /// </summary>
        /// <remarks>为“去向”的ID。</remarks>
        [ForeignKey("DestinationSecond")]
        public virtual Guid? DestinationSecondId { get; set; }





        /// <summary>
        /// 离室时间。
        /// </summary>
        public virtual DateTime? OutDepartmentTime { get; set; }

        /// <summary>
        /// 去向ID。
        /// </summary>
        [ForeignKey("Destination")]
        public virtual Guid? DestinationId { get; set; }

        /// <summary>
        /// 去向明细。
        /// </summary>
        /// <remarks>有额外信息时才有意义。</remarks>
        public virtual string DestinationRemarks { get; set; }

        /// <summary>
        /// 经手护士。
        /// </summary>
        public virtual string HandleNurse { get; set; }

        /// <summary>
        /// 离室诊断名称。
        /// </summary>
        public virtual string DiagnosisName { get; set; }

        /// <summary>
        /// 转院原因ID。
        /// </summary>
        [ForeignKey("TransferReason")]
        public virtual Guid? TransferReasonId { get; set; }

        /// <summary>
        /// 转往医院。
        /// </summary>
        /// <remarks>去向为“转院”时才有意义。</remarks>
        public virtual string TransferTarget { get; set; }

        /// <summary>
        /// 专科名称。
        /// </summary>
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

        public virtual List<GreenPathInfo> GreenPathInfos { get; set; }





        /// <summary>
        /// 就诊年龄名称。
        /// </summary>
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


        /// <summary>
        /// 完整床位名称。
        /// </summary>
        public string BedNameFull
        {
            get
            {
                return this.BedId == null ? this.BedNumber : this.Bed.BedName;
            }
        }

        /// <summary>
        /// 完整入室方式名称。
        /// </summary>
        public string InRoomWayNameFull
        {
            get
            {
                if (this.InRoomWayId == null)
                    return null;
                else if (!this.InRoomWay.IsHasAdditionalInfo)
                    return this.InRoomWay.InRoomWayName;
                else
                    return this.InRoomWay.InRoomWayName + " - " + this.InRoomWayRemarks;
            }
        }

        /// <summary>
        /// 是否绿色通道名称。
        /// </summary>
        public string IsGreenPathName
        {
            get
            {
                return this.GreenPathCategoryId.HasValue ? "是" : "否";
            }
        }

        /// <summary>
        /// 完整绿色通道名称。
        /// </summary>
        public string GreenPathCategoryNameFull
        {
            get
            {
                if (this.GreenPathCategoryId == null)
                    return null;
                if (!this.GreenPathCategory.IsHasAdditionalInfo)
                    return this.GreenPathCategory.GreenPathCategoryName;
                else
                    return this.GreenPathCategory.GreenPathCategoryName + " - " + this.GreenPathCategoryRemarks;
            }
        }

        /// <summary>
        /// 是否抢救名称。
        /// </summary>
        public string IsRescueName
        {
            get
            {
                return this.IsRescue ? "是" : "否";
            }
        }

        /// <summary>
        /// 完整抢救名称。
        /// </summary>
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

        /// <summary>
        /// 是否离室名称。
        /// </summary>
        public string IsLeaveName
        {
            get
            {
                return this.OutDepartmentTime.HasValue ? "是" : "否";
            }
        }

        /// <summary>
        /// 停留时长。
        /// </summary>
        /// <remarks>当次入室的入室时间至离室时间的间隔。</remarks>
        public TimeSpan? During
        {
            get
            {
                return this.OutDepartmentTime - this.InDepartmentTime;
            }
        }

        /// <summary>
        /// 最初入室时间。
        /// </summary>
        /// <remarks>若有转室，则返回转室前的最初入室时间。</remarks>
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

        /// <summary>
        /// 连续滞留时长。
        /// </summary>
        /// <remarks>从最初入室到当前（未离室）或离室时（已离室）的累积时长。</remarks>
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

        /// <summary>
        /// 停留时长小时数。
        /// </summary>
        public int? DuringHours
        {
            get
            {
                return this.During?.Hours + this.During?.Days * 24;
            }
        }

        /// <summary>
        /// 连续滞留时长小时数。
        /// </summary>
        public int? DuringDetainedHours
        {
            get
            {
                return this.DuringDetained.Hours + this.DuringDetained.Days * 24;
            }
        }

        /// <summary>
        /// 停留时长分组。
        /// </summary>
        /// <remarks>基于停留时长小时数进行的分组。</remarks>
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

        /// <summary>
        /// 完整去向名称。
        /// </summary>
        public string DestinationNameFull
        {
            get
            {
                if (this.DestinationId == null)
                    return null;
                if (this.Destination.IsHasAdditionalInfo)
                    return this.Destination.DestinationName + " - " + this.DestinationRemarks;
                else if (this.Destination.IsTransferHospital)
                    return this.Destination.DestinationName + " - " + this.TransferTarget;
                else
                    return this.Destination.DestinationName;
            }
        }

        /// <summary>
        /// 是否去往首选预约科室。
        /// </summary>
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

        /// <summary>
        /// 是否去往次选预约科室。
        /// </summary>
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

        /// <summary>
        /// 是否去往预约科室。
        /// </summary>
        public bool? IsGotoSubscription
        {
            get
            {
                if (!this.IsGotoFirstSubscription.HasValue || !this.IsGotoSecondSubscription.HasValue)
                    return null;

                return this.IsGotoFirstSubscription.Value || this.IsGotoSecondSubscription.Value;
            }
        }

        /// <summary>
        /// 是否转室。
        /// </summary>
        public bool IsTransferRoom
        {
            get
            {
                if (this.DestinationId == null)
                    return false;
                if (this.Destination.IsTransferRoom)
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
