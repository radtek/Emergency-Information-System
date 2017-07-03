using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 抢救室病例。
    /// </summary>
    /// <remarks>表示抢救室的病例。包含冗余的个人信息。</remarks>
    [Table("RescueRoomInfos")]
    public class RescueRoomInfo
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="RescueRoomInfo"/>。
        /// </summary>
        public RescueRoomInfo()
        {
        }

        #endregion





        #region 实体属性

        /// <summary>
        /// 抢救室病例ID。
        /// </summary>
        [Key]
        public virtual int RescueRoomInfoId { get; set; }





        /// <summary>
        /// 患者姓名。
        /// </summary>
        [Display(Name = "患者姓名")]
        public virtual string PatientName { get; set; }

        /// <summary>
        /// 卡号。
        /// </summary>
        [Required]
        [Display(Name = "卡号")]
        public virtual string OutPatientNumber { get; set; }

        /// <summary>
        /// 性别。
        /// </summary>
        [Display(Name = "性别")]
        public virtual string Sex { get; set; }

        /// <summary>
        /// 出生日期。
        /// </summary>
        [Display(Name = "出生日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public virtual DateTime? BirthDate { get; set; }

        /// <summary>
        /// 急诊选择接诊诊断名称。
        /// </summary>
        [Display(Name = "入室诊断")]
        public virtual string DiagnosisNameOrigin { get; set; }

        /// <summary>
        /// 急诊选择接诊时间。
        /// </summary>
        [Display(Name = "接诊时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public virtual DateTime? ReceiveTime { get; set; }

        /// <summary>
        /// 急诊选择接诊医师姓名。
        /// </summary>
        [Display(Name = "首诊医师")]
        public virtual string FirstDoctorName { get; set; }





        /// <summary>
        /// 入室时间。
        /// </summary>        
        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public virtual DateTime InDepartmentTime { get; set; }

        /// <summary>
        /// 床位号。
        /// </summary>
        [Obsolete]
        [Display(Name = "床位")]
        public virtual string BedNumber { get; set; }

        /// <summary>
        /// 床位ID。
        /// </summary>
        [ForeignKey("Bed")]
        [Display(Name = "床位")]
        public virtual int BedId { get; set; }

        /// <summary>
        /// 首诊护士姓名。
        /// </summary>
        [Display(Name = "首诊护士")]
        public virtual string FirstNurseName { get; set; }

        /// <summary>
        /// 进入抢救室方式ID。
        /// </summary>
        [ForeignKey("InRescueRoomWay")]
        [Display(Name = "入室方式")]
        public virtual int InRescueRoomWayId { get; set; }

        /// <summary>
        /// 进入抢救室方式明细。
        /// </summary>
        /// <remarks>有额外信息时才有意义。</remarks>
        [Display(Name = "入室方式明细")]
        public virtual string InRescueRoomWayRemarks { get; set; }

        /// <summary>
        /// 补充诊断。
        /// </summary>
        [Display(Name = "补充诊断")]
        public virtual string AdditionalDiagnosis { get; set; }





        /// <summary>
        /// 危重等级ID。
        /// </summary>
        [ForeignKey("CriticalLevel")]
        [Display(Name = "危重等级")]
        public virtual int CriticalLevelId { get; set; }

        /// <summary>
        /// 是否抢救。
        /// </summary>
        [Display(Name = "抢救")]
        public virtual bool IsRescue { get; set; }

        /// <summary>
        /// 抢救效果ID。
        /// </summary>
        [ForeignKey("RescueResult")]
        [Display(Name = "抢救效果")]
        public virtual int RescueResultId { get; set; }

        /// <summary>
        /// 绿色通道类型ID。
        /// </summary>  
        [ForeignKey("GreenPathCategory")]
        [Display(Name = "绿色通道")]
        public virtual int GreenPathCategoryId { get; set; }

        /// <summary>
        /// 绿色通道明细。
        /// </summary>
        /// <remarks>有额外信息时才有意义。</remarks>
        [Display(Name = "绿色通道明细")]
        public virtual string GreenPathCategoryRemarks { get; set; }

        /// <summary>
        /// 抗生素。
        /// </summary>
        [Display(Name = "抗生素")]
        public virtual string Antibiotic { get; set; }

        /// <summary>
        /// 备注。
        /// </summary>
        [Display(Name = "备注")]
        public virtual string Remarks { get; set; }





        /// <summary>
        /// 预约首选科室ID——去向ID。
        /// </summary>
        [ForeignKey("DestinationFirst")]
        [Display(Name = "预约首选科室")]
        public virtual int DestinationFirstId { get; set; }

        /// <summary>
        /// 预约首选科室预约时间。
        /// </summary>        
        [Display(Name = "预约首选时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public virtual DateTime? DestinationFirstTime { get; set; }

        /// <summary>
        /// 预约首选科室联系人。
        /// </summary>
        [Display(Name = "预约首选医师")]
        public virtual string DestinationFirstContact { get; set; }

        /// <summary>
        /// 预约次选科室ID——去向ID。
        /// </summary>
        [ForeignKey("DestinationSecond")]
        [Display(Name = "预约次选科室")]
        public virtual int DestinationSecondId { get; set; }





        /// <summary>
        /// 离室时间。
        /// </summary>
        [Display(Name = "离室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public virtual DateTime? OutDepartmentTime { get; set; }

        /// <summary>
        /// 去向ID。
        /// </summary>
        [ForeignKey("Destination")]
        [Display(Name = "去向")]
        public virtual int DestinationId { get; set; }

        /// <summary>
        /// 去向明细。
        /// </summary>
        /// <remarks>有额外信息时才有意义。</remarks>
        [Display(Name = "去向明细")]
        public virtual string DestinationRemarks { get; set; }

        /// <summary>
        /// 经手护士。
        /// </summary>
        [Display(Name = "经手护士")]
        public virtual string HandleNurse { get; set; }

        /// <summary>
        /// 离室诊断名称。
        /// </summary>
        [Display(Name = "离室诊断")]
        public virtual string DiagnosisName { get; set; }

        /// <summary>
        /// 转院原因ID。
        /// </summary>
        [Display(Name = "转院原因")]
        [ForeignKey("TransferReason")]
        public virtual int? TransferReasonId { get; set; }

        /// <summary>
        /// 转往医院。
        /// </summary>
        [Display(Name = "转往医院")]
        public virtual string TransferTarget { get; set; }

        /// <summary>
        /// 专科名称。
        /// </summary>
        [Display(Name = "专科名称")]
        public virtual string ProfessionalTarget { get; set; }





        /// <summary>
        /// “创新”“卡登记ID”。
        /// </summary>
        /// <remarks>dbo.YY_KDJB的KDJID。</remarks>
        public virtual Guid? KDJID { get; set; }

        /// <summary>
        /// “创新”“病人信息ID”。
        /// </summary>
        /// <remarks>dbo.YY_BRXX的BRXXID。</remarks>
        public virtual Guid? BRXXID { get; set; }

        /// <summary>
        /// “创新”“挂号信息ID”。
        /// </summary>
        /// <remarks>dbo.MZ_GHXX的GHXXID。</remarks>
        public virtual Guid? GHXXID { get; set; }

        /// <summary>
        /// “创新”“接诊信息ID”。
        /// </summary>
        /// <remarks>dbo.MZYS_JZJL的JZID。</remarks>
        public virtual Guid? JZID { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }

        #endregion





        #region 导航属性

        /// <summary>
        /// 床位。
        /// </summary>     
        public virtual Bed Bed { get; set; }

        /// <summary>
        /// 进入抢救室方式。
        /// </summary>
        public virtual InRescueRoomWay InRescueRoomWay { get; set; }

        /// <summary>
        /// 绿色通道类型。
        /// </summary>           
        public virtual GreenPathCategory GreenPathCategory { get; set; }

        /// <summary>
        /// 危重等级。
        /// </summary>      
        public virtual CriticalLevel CriticalLevel { get; set; }

        /// <summary>
        /// 抢救效果。
        /// </summary>              
        public virtual RescueResult RescueResult { get; set; }

        /// <summary>
        /// 预约首选科室——去向。
        /// </summary>
        public virtual Destination DestinationFirst { get; set; }

        /// <summary>
        /// 预约次选科室——去向。
        /// </summary>    
        public virtual Destination DestinationSecond { get; set; }

        /// <summary>
        /// 去向。
        /// </summary>             
        public virtual Destination Destination { get; set; }

        /// <summary>
        /// 关联的上一次留观室病例。
        /// </summary>
        public virtual ObserveRoomInfo PreviousObserveRoomInfo { get; set; }

        /// <summary>
        /// 关联的下一次留观室病例。
        /// </summary>
        public virtual ObserveRoomInfo NextObserveRoomInfo { get; set; }

        /// <summary>
        /// 转院原因。
        /// </summary>
        public virtual TransferReason TransferReason { get; set; }

        #endregion





        #region 导航集合

        /// <summary>
        /// 抢救室会诊项。
        /// </summary>   
        public virtual List<RescueRoomConsultation> RescueRoomConsultations { get; set; }

        /// <summary>
        /// 抢救室影像项。
        /// </summary>   
        public virtual List<RescueRoomImageRecord> RescueRoomImageRecords { get; set; }

        /// <summary>
        /// 抢救室用药项。
        /// </summary>
        public virtual List<RescueRoomDrugRecord> RescueRoomDrugRecords { get; set; }

        /// <summary>
        /// 抢救室治疗项。
        /// </summary>
        public virtual List<RescueRoomTreatmentRecord> RescueRoomTreatmentRecords { get; set; }

        /// <summary>
        /// 绿色通道-急性心肌梗死。
        /// </summary>
        public virtual List<GreenPathAmi> GreenPathAmis { get; set; }

        /// <summary>
        /// 绿色通道-急性脑卒中。
        /// </summary>
        public virtual List<GreenPathStk> GreenStks { get; set; }

        #endregion





        #region 实例属性

        /// <summary>
        /// 就诊年龄名称。
        /// </summary>
        [Display(Name = "就诊年龄")]
        public string ReceiveAgeName
        {
            get
            {
                if (!this.BirthDate.HasValue || !this.ReceiveTime.HasValue)
                    return string.Empty;
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
        /// 床位名称-完整。
        /// </summary>
        [Display(Name = "床位")]
        public string BedNameFull
        {
            get
            {
                if (this.Bed == null || this.Bed.IsUseForEmpty)
                    return this.BedNumber;
                else
                    return this.Bed.BedName;
            }
        }

        /// <summary>
        /// 进入抢救室方式名称-完整。
        /// </summary>
        /// <remarks>整合附加信息。</remarks>
        [Display(Name = "入室方式")]
        public string InRescueRoomWayNameFull
        {
            get
            {
                if (!this.InRescueRoomWay.IsHasAdditionalInfo)
                    return this.InRescueRoomWay.InRescueRoomWayName;
                else
                    return this.InRescueRoomWay.InRescueRoomWayName + " - " + this.InRescueRoomWayRemarks;
            }
        }

        /// <summary>
        /// 是否绿色通道。
        /// </summary>
        public bool IsGreenPath
        {
            get
            {
                if (GreenPathCategory == null)
                    return false;

                return !this.GreenPathCategory.IsUseForEmpty;
            }
        }

        /// <summary>
        /// 是否绿色通道名称。
        /// </summary>
        public string IsGreenPathName
        {
            get
            {
                if (this.IsGreenPath)
                    return "是";
                else
                    return "否";
            }
        }

        /// <summary>
        /// 绿色通道类型名称-完整。
        /// </summary>
        /// <remarks>整合附加信息。</remarks>
        [Display(Name = "绿色通道")]
        public string GreenPathCategoryNameFull
        {
            get
            {
                if (!this.GreenPathCategory.IsHasAdditionalInfo)
                {
                    return this.GreenPathCategory.GreenPathCategoryName;
                }
                else
                {
                    return this.GreenPathCategory.GreenPathCategoryName + " - " + this.GreenPathCategoryRemarks;
                }
            }
        }

        /// <summary>
        /// 是否抢救名称。
        /// </summary>
        public string IsRescueName
        {
            get
            {
                if (this.IsRescue)
                    return "是";
                else
                    return "否";
            }
        }

        /// <summary>
        /// 抢救效果名称-完整。
        /// </summary>
        [Display(Name = "抢救")]
        public string RescueResultNameFull
        {
            get
            {
                if (!this.IsRescue)
                    return this.IsRescueName;
                else
                    return this.IsRescueName + " - " + this.RescueResult.RescueResultName;
            }
        }

        /// <summary>
        /// 预约首选科室名称——去向名称。
        /// </summary>
        [Display(Name = "预约首选科室")]
        public string DestinationFirstName
        {
            get
            {
                return this.DestinationFirst.DestinationName;
            }
        }

        /// <summary>
        /// 预约次选科室名称——去向名称。
        /// </summary>
        [Display(Name = "预约次选科室")]
        public string DestinationSecondName
        {
            get
            {
                return this.DestinationSecond.DestinationName;
            }
        }

        /// <summary>
        /// 是否离室。
        /// </summary>
        [Display(Name = "离室")]
        public bool IsLeave
        {
            get
            {
                return this.OutDepartmentTime != null;
            }
        }

        /// <summary>
        /// 是否离室名称。
        /// </summary>
        public string IsLeaveName
        {
            get
            {
                return this.IsLeave ? "是" : "否";
            }
        }

        /// <summary>
        /// 停留时长。
        /// </summary>
        /// <remarks>入室时间至离室时间的间隔。</remarks>
        [Display(Name = "停留时长")]
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
        /// <remarks>连续在抢救室和留观室中的最初入室时间。</remarks>
        public DateTime InDepartmentTimeActual
        {
            get
            {
                if (this.PreviousObserveRoomInfo == null)
                    return this.InDepartmentTime;
                else
                    return this.PreviousObserveRoomInfo.InDepartmentTimeActual;
            }
        }

        /// <summary>
        /// 连续滞留时长。
        /// </summary>
        /// <remarks>从最初入室到当前（未离室）或离室时的累积时长。</remarks>
        [Display(Name = "连续滞留时长")]
        public TimeSpan DuringDetained
        {
            get
            {
                if (this.IsLeave)
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
        /// 去向名称-完整。
        /// </summary>
        /// <remarks>整合附加信息。</remarks>
        [Display(Name = "去向")]
        public string DestinationNameFull
        {
            get
            {
                if (this.Destination.IsHasAdditionalInfo)
                    return this.Destination.DestinationName + " - " + this.DestinationRemarks;
                else if (this.Destination.IsTransfer)
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
                if (this.Destination.IsUseForEmpty || this.DestinationFirst.IsUseForEmpty)
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
                if (this.Destination.IsUseForEmpty || this.DestinationSecond.IsUseForEmpty)
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
        /// 绿色通道表格跳转响应方法名称。
        /// </summary>
        public string GreenPathActionName
        {
            get
            {
                if (this.GreenPathCategory.IsUseForEmpty)
                    return string.Empty;
                else
                    switch (this.GreenPathCategory.CodeName)
                    {
                        case "Ami":
                            if (this.GreenPathAmis.Count == 1)
                                return "DetailsAmi";
                            else
                                return "CreateAmi";
                        default:
                            return string.Empty;
                    }
            }
        }

        /// <summary>
        /// 绿色通道表格跳转ID。
        /// </summary>
        public Guid? GreenPathId
        {
            get
            {
                if (this.GreenPathCategory.IsUseForEmpty)
                    return null;
                else
                    switch (this.GreenPathCategory.CodeName)
                    {
                        case "Ami":
                            if (this.GreenPathAmis.Count == 1)
                                return this.GreenPathAmis.First().GreenPathAmiId;
                            else
                                return null;
                        default:
                            return null;
                    }
            }
        }

        #endregion
    }
}