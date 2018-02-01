using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos2.Edit
{
    public class Edit : IValidatableObject
    {
        public Edit(Domains3.Entities.GeneralRoomInfo target)
        {
            this.Initial(target);
        }

        public Edit(Guid id)
        {
            var db3 = new Domains3.Entities.EiSDbContext();

            var target = db3.GeneralRoomInfos.Find(id);

            this.Initial(target);
        }

        public Edit()
        {

        }

        private void Initial(Domains3.Entities.GeneralRoomInfo target)
        {
            this.GeneralRoomInfoId = target.GeneralRoomInfoId;

            this.InDepartmentTime = target.InDepartmentTime;
            this.BedId = target.BedId;
            this.FirstNurseName = target.FirstNurseName;
            this.InRoomWayId = target.InRoomWayId;
            this.InRoomWayRemarks = target.InRoomWayRemarks;
            this.AdditionalDiagnosis = target.AdditionalDiagnosis;

            this.CriticalLevelId = target.CriticalLevelId;
            this.IsRescue = target.IsRescue;
            this.RescueResultId = target.RescueResultId;
            this.GreenPathCategoryId = target.GreenPathCategoryId;
            this.GreenPathCategoryRemarks = target.GreenPathCategoryRemarks;
            this.Antibiotic = target.Antibiotic;
            this.Remarks = target.Remarks;

            this.DestinationFirstId = target.DestinationFirstId;
            this.DestinationFirstTime = target.DestinationFirstTime;
            this.DestinationFirstContact = target.DestinationFirstContact;
            this.DestinationSecondId = target.DestinationSecondId;

            this.OutDepartmentTime = target.OutDepartmentTime;
            this.DestinationId = target.DestinationId;
            this.DestinationRemarks = target.DestinationRemarks;
            this.HandleNurse = target.HandleNurse;
            this.DiagnosisName = target.DiagnosisName;
            this.TransferReasonId = target.TransferReasonId;
            this.TransferTarget = target.TransferTarget;
            this.ProfessionalTarget = target.ProfessionalTarget;

            this.TimeStamp = target.TimeStamp;
        }





        public Guid GeneralRoomInfoId { get; set; }

        public bool IsTransferRoom { get; set; }





        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }

        [Display(Name = "床位")]
        public Guid? BedId { get; set; }

        [Display(Name = "首诊护士")]
        public string FirstNurseName { get; set; }

        [Display(Name = "入室方式")]
        public Guid? InRoomWayId { get; set; }

        [Display(Name = "入室方式明细")]
        public string InRoomWayRemarks { get; set; }

        [Display(Name = "补充诊断")]
        public string AdditionalDiagnosis { get; set; }





        [Display(Name = "危重等级")]
        public Guid? CriticalLevelId { get; set; }

        [Display(Name = "抢救")]
        public bool IsRescue { get; set; }

        [Display(Name = "抢救效果")]
        public Guid? RescueResultId { get; set; }

        [Display(Name = "绿色通道")]
        public Guid? GreenPathCategoryId { get; set; }

        [Display(Name = "绿色通道明细")]
        public string GreenPathCategoryRemarks { get; set; }

        [Display(Name = "抗生素")]
        public string Antibiotic { get; set; }

        [Display(Name = "备注")]
        public string Remarks { get; set; }





        [Display(Name = "预约首选科室")]
        public Guid? DestinationFirstId { get; set; }

        [Display(Name = "预约首选时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? DestinationFirstTime { get; set; }

        [Display(Name = "预约首选医师")]
        public string DestinationFirstContact { get; set; }

        [Display(Name = "预约次选科室")]
        public Guid? DestinationSecondId { get; set; }





        [Display(Name = "离室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? OutDepartmentTime { get; set; }

        [Display(Name = "去向")]
        public Guid? DestinationId { get; set; }

        [Display(Name = "去向明细")]
        public string DestinationRemarks { get; set; }

        [Display(Name = "经手护士")]
        public string HandleNurse { get; set; }

        [Display(Name = "离室诊断")]
        public string DiagnosisName { get; set; }

        [Display(Name = "转院原因")]
        public Guid? TransferReasonId { get; set; }

        [Display(Name = "转往医院")]
        public string TransferTarget { get; set; }

        [Display(Name = "专科名称")]
        public string ProfessionalTarget { get; set; }





        public byte[] TimeStamp { get; set; }





        public void GetReturn(Domains3.Entities.GeneralRoomInfo target)
        {
            target.InDepartmentTime = this.InDepartmentTime;
            target.BedId = this.BedId;
            target.FirstNurseName = this.FirstNurseName;
            target.InRoomWayId = this.InRoomWayId;
            target.InRoomWayRemarks = this.InRoomWayRemarks;
            target.AdditionalDiagnosis = this.AdditionalDiagnosis;

            target.CriticalLevelId = this.CriticalLevelId;
            target.IsRescue = this.IsRescue;
            target.RescueResultId = this.RescueResultId;
            target.GreenPathCategoryId = this.GreenPathCategoryId;
            target.GreenPathCategoryRemarks = this.GreenPathCategoryRemarks;
            target.Antibiotic = this.Antibiotic;
            target.Remarks = this.Remarks;

            target.DestinationFirstId = this.DestinationFirstId;
            target.DestinationFirstTime = this.DestinationFirstTime;
            target.DestinationFirstContact = this.DestinationFirstContact;
            target.DestinationSecondId = this.DestinationSecondId;

            target.OutDepartmentTime = this.OutDepartmentTime;
            target.DestinationId = this.DestinationId;
            target.DestinationRemarks = this.DestinationRemarks;
            target.HandleNurse = this.HandleNurse;
            target.DiagnosisName = this.DiagnosisName;
            target.TransferReasonId = this.TransferReasonId;
            target.TransferTarget = this.TransferTarget;
            target.ProfessionalTarget = this.ProfessionalTarget;

            target.TimeStamp = this.TimeStamp;

            target.UpdateTime = DateTime.Now;
        }





        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            var db3 = new Domains3.Entities.EiSDbContext();
            var targetOld = db3.GeneralRoomInfos.Find(this.GeneralRoomInfoId);

            //1.入室时间不能晚于当前时间。
            if (this.InDepartmentTime > DateTime.Now)
                result.Add(new ValidationResult("“入室时间”不能晚于当前时间", new string[] { "InDepartmentTime" }));

            //2.入室方式必填。
            if (!this.InRoomWayId.HasValue && !targetOld.InRoomWayId.HasValue)
                result.Add(new ValidationResult("“入室方式”不可为空", new string[] { "InRoomWayId" }));

            //3.首诊护士必填。
            if (string.IsNullOrWhiteSpace(this.FirstNurseName))
                result.Add(new ValidationResult("“首诊护士”不可为空", new string[] { "FirstNurseName" }));

            //4.入室方式为允许附加数据才可以有附加数据。
            //if (!db.InRescueRoomWays.Find(rescueRoomInfo.InRescueRoomWayId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.InRescueRoomWayRemarks))
            //    ModelState.AddModelError("InRescueRoomWayRemarks", "与入院方式不匹配。");

            //5.入室方式为允许附加数据，必须有具体名称。
            if (this.InRoomWayId.HasValue
                && db3.InRoomWays.Find(this.InRoomWayId).IsHasAdditionalInfo
                && string.IsNullOrWhiteSpace(this.InRoomWayRemarks))
                result.Add(new ValidationResult("“入室方式明细”不可为空", new string[] { "InRoomWayRemarks" }));

            //6.有抢救才能有抢救结果。
            if (!this.IsRescue && this.RescueResultId.HasValue)
                result.Add(new ValidationResult("与“抢救”不匹配", new string[] { "RescueResultId" }));

            //7.离室时，有抢救则必须有抢救结果。
            if (this.OutDepartmentTime.HasValue && this.IsRescue && !this.RescueResultId.HasValue)
                result.Add(new ValidationResult("离室时，有“抢救”必须有“抢救结果”", new string[] { "RescueResultId" }));

            //8.绿色通道为允许附加数据才可以有附加数据。
            //if (!db.GreenPathCategories.Find(rescueRoomInfo.GreenPathCategoryId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.GreenPathCategoryRemarks))
            //    ModelState.AddModelError("GreenPathCategoryRemarks", "与绿色通道病种不匹配。");

            //9.绿色通道为允许附加数据,必须有具体名称。
            if (this.GreenPathCategoryId.HasValue
                && db3.GreenPathCategories.Find(this.GreenPathCategoryId).IsHasAdditionalInfo
                && string.IsNullOrWhiteSpace(this.GreenPathCategoryRemarks))
                result.Add(new ValidationResult("“绿色通道明细”不可为空", new string[] { "GreenPathCategoryRemarks" }));

            //10.有预约首选科室，必须有预约首选时间。
            if (this.DestinationFirstId.HasValue && !this.DestinationFirstTime.HasValue)
                result.Add(new ValidationResult("“预约时间”不可为空", new string[] { "DestinationFirstTime" }));

            //11.预约首选时间不能早于入室时间。
            if (this.DestinationFirstTime.HasValue && this.DestinationFirstTime.Value < this.InDepartmentTime)
                result.Add(new ValidationResult("“预约时间”不能早于“入室时间”", new string[] { "DestinationFirstTime" }));

            //12.有预约首选科室，必须有预约首选医师。
            if (this.DestinationFirstId.HasValue && string.IsNullOrWhiteSpace(this.DestinationFirstContact))
                result.Add(new ValidationResult("“预约医师”不可为空", new string[] { "DestinationFirstContact" }));

            //13.有预约次选科室，必须有预约首选科室。
            if (this.DestinationSecondId.HasValue && !this.DestinationFirstId.HasValue)
                result.Add(new ValidationResult("必须先填写“预约首选科室”", new string[] { "DestinationSecondId" }));

            //14.有离室时间，必须有去向。
            if (this.OutDepartmentTime.HasValue && this.DestinationId == null)
                result.Add(new ValidationResult("离室时必填", new string[] { "DestinationId" }));

            //15.有离室时间，必须有经手护士。
            if (this.OutDepartmentTime.HasValue && string.IsNullOrWhiteSpace(this.HandleNurse))
                result.Add(new ValidationResult("离室时必填", new string[] { "HandleNurse" }));

            //16.离室时间必须不早于入室时间。
            if (this.OutDepartmentTime.HasValue && this.InDepartmentTime > this.OutDepartmentTime)
                result.Add(new ValidationResult("不能早于“入室时间”", new string[] { "OutDepartmentTime" }));

            //17.去向为允许附加数据才可以填写去向详细。
            //if (!db.Destinations.Find(rescueRoomInfo.DestinationId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.DestinationRemarks))
            //    ModelState.AddModelError("DestinationRemarks", "与去向不匹配。");

            //18.去向为允许附加数据,必须填写去向详细。
            if (this.DestinationId.HasValue
                && db3.Destinations.Find(this.DestinationId).IsHasAdditionalInfo
                && string.IsNullOrWhiteSpace(this.DestinationRemarks))
                result.Add(new ValidationResult("“去向明细”不可为空", new string[] { "DestinationRemarks" }));

            //19.有去向，必须有离室时间。
            if (this.DestinationId.HasValue && !this.OutDepartmentTime.HasValue)
                result.Add(new ValidationResult("“离室时间”不可为空", new string[] { "OutDepartmentTime" }));

            //20.有去向，必须有经手护士。
            if (this.DestinationId.HasValue && string.IsNullOrWhiteSpace(this.HandleNurse))
                result.Add(new ValidationResult("“经手护士”不可为空", new string[] { "HandleNurse" }));

            //21.去向为转院时，必须有转院原因。
            if (this.DestinationId.HasValue
                && db3.Destinations.Find(this.DestinationId).IsTransferHospital
                && !this.TransferReasonId.HasValue)
                result.Add(new ValidationResult("“转院原因”不可为空", new string[] { "TransferReasonId" }));

            //22.去向为转院时，必须有转往医院。
            if (this.DestinationId.HasValue
                && db3.Destinations.Find(this.DestinationId).IsTransferHospital
                && string.IsNullOrWhiteSpace(this.TransferTarget))
                result.Add(new ValidationResult("“转往医院”不可为空", new string[] { "TransferTarget" }));

            //23.去向为专科时，必须有专科名称。
            if (this.DestinationId.HasValue
                && db3.Destinations.Find(this.DestinationId).IsNeedProfessional
                && string.IsNullOrWhiteSpace(this.ProfessionalTarget))
                result.Add(new ValidationResult("“专科名称”不可为空", new string[] { "ProfessionalTarget" }));

            return result;
        }
    }
}