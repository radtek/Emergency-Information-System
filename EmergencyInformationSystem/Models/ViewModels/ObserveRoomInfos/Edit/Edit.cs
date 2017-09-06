using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Edit
{
    public class Edit : IValidatableObject
    {
        public Edit(Models.Domains.Entities.ObserveRoomInfo target)
        {
            this.ObserveRoomInfoId = target.ObserveRoomInfoId;

            this.InDepartmentTime = target.InDepartmentTime;
            this.BedId = target.BedId;
            this.FirstNurseName = target.FirstNurseName;
            this.InObserveRoomWayId = target.InObserveRoomWayId;
            this.InObserveRoomWayRemarks = target.InObserveRoomWayRemarks;
            this.AdditionalDiagnosis = target.AdditionalDiagnosis;

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

        public Edit()
        {

        }





        public Guid ObserveRoomInfoId { get; set; }





        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }

        [Display(Name = "床位")]
        public int BedId { get; set; }

        [Display(Name = "首诊护士")]
        public string FirstNurseName { get; set; }

        [Display(Name = "入室方式")]
        public int InObserveRoomWayId { get; set; }

        [Display(Name = "入室方式明细")]
        public string InObserveRoomWayRemarks { get; set; }

        [Display(Name = "补充诊断")]
        public string AdditionalDiagnosis { get; set; }





        [Display(Name = "预约首选科室")]
        public int DestinationFirstId { get; set; }

        [Display(Name = "预约首选时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? DestinationFirstTime { get; set; }

        [Display(Name = "预约首选医师")]
        public string DestinationFirstContact { get; set; }

        [Display(Name = "预约次选科室")]
        public int DestinationSecondId { get; set; }





        [Display(Name = "离室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? OutDepartmentTime { get; set; }

        [Display(Name = "去向")]
        public int DestinationId { get; set; }

        [Display(Name = "去向明细")]
        public string DestinationRemarks { get; set; }

        [Display(Name = "经手护士")]
        public string HandleNurse { get; set; }

        [Display(Name = "离室诊断")]
        public string DiagnosisName { get; set; }

        [Display(Name = "转院原因")]
        public int? TransferReasonId { get; set; }

        [Display(Name = "转往医院")]
        public string TransferTarget { get; set; }

        [Display(Name = "专科名称")]
        public string ProfessionalTarget { get; set; }





        public byte[] TimeStamp { get; set; }





        public void GetReturn(Models.Domains.Entities.ObserveRoomInfo target)
        {
            target.InDepartmentTime = this.InDepartmentTime;
            target.BedId = this.BedId;
            target.FirstNurseName = this.FirstNurseName;
            target.InObserveRoomWayId = this.InObserveRoomWayId;
            target.InObserveRoomWayRemarks = this.InObserveRoomWayRemarks;
            target.AdditionalDiagnosis = this.AdditionalDiagnosis;

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

            var db = new Models.Domains.Entities.EiSDbContext();

            //1.入室时间不能晚于当前时间。
            if (this.InDepartmentTime > DateTime.Now)
                result.Add(new ValidationResult("“入室时间”不能晚于当前时间", new string[] { "InDepartmentTime" }));

            //2.入室方式必填。
            if (db.InObserveRoomWays.Find(this.InObserveRoomWayId).IsUseForEmpty)
                result.Add(new ValidationResult("“入室方式”不可为空", new string[] { "InObserveRoomWayId" }));

            //3.首诊护士必填。
            if (string.IsNullOrEmpty(this.FirstNurseName))
                result.Add(new ValidationResult("“首诊护士”不可为空", new string[] { "FirstNurseName" }));

            //4.入室方式为允许附加数据才可以有附加数据。
            //if (!db.InRescueRoomWays.Find(rescueRoomInfo.InRescueRoomWayId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.InRescueRoomWayRemarks))
            //    ModelState.AddModelError("InRescueRoomWayRemarks", "与入院方式不匹配。");

            //5.入室方式为允许附加数据，必须有具体名称。
            if (db.InObserveRoomWays.Find(this.InObserveRoomWayId).IsHasAdditionalInfo && string.IsNullOrEmpty(this.InObserveRoomWayRemarks))
                result.Add(new ValidationResult("“入室方式明细”不可为空", new string[] { "InObserveRoomWayRemarks" }));

            //10.有预约首选科室，必须有预约首选时间。
            if (!db.Destinations.Find(this.DestinationFirstId).IsUseForEmpty && !this.DestinationFirstTime.HasValue)
                result.Add(new ValidationResult("“预约时间”不可为空", new string[] { "DestinationFirstTime" }));

            //11.预约首选时间不能早于入室时间。
            if (this.DestinationFirstTime.HasValue && this.DestinationFirstTime.Value < this.InDepartmentTime)
                result.Add(new ValidationResult("“预约时间”不能早于“入室时间”", new string[] { "DestinationFirstTime" }));

            //12.有预约首选科室，必须有预约首选医师。
            if (!db.Destinations.Find(this.DestinationFirstId).IsUseForEmpty && string.IsNullOrEmpty(this.DestinationFirstContact))
                result.Add(new ValidationResult("“预约医师”不可为空", new string[] { "DestinationFirstContact" }));

            //13.有预约次选科室，必须有预约首选科室。
            if (!db.Destinations.Find(this.DestinationSecondId).IsUseForEmpty && db.Destinations.Find(this.DestinationFirstId).IsUseForEmpty)
                result.Add(new ValidationResult("必须先填写“预约首选科室”", new string[] { "DestinationSecondId" }));

            //14.有离室时间，必须有去向。
            //if (rescueRoomInfo.IsLeave && db.Destinations.Find(rescueRoomInfo.DestinationId).IsUseForEmpty)
            //    ModelState.AddModelError("DestinationId", "离室时必填。");

            //15.有离室时间，必须有经手护士。
            //if (rescueRoomInfo.IsLeave && string.IsNullOrEmpty(rescueRoomInfo.HandleNurse))
            //    ModelState.AddModelError("HandleNurse", "离室时必填。");

            //16.离室时间必须不早于入室时间。
            if (this.OutDepartmentTime.HasValue && this.InDepartmentTime > this.OutDepartmentTime)
                result.Add(new ValidationResult("不能早于“入室时间”", new string[] { "OutDepartmentTime" }));

            //17.去向为允许附加数据才可以填写去向详细。
            //if (!db.Destinations.Find(rescueRoomInfo.DestinationId).IsHasAdditionalInfo && !string.IsNullOrEmpty(rescueRoomInfo.DestinationRemarks))
            //    ModelState.AddModelError("DestinationRemarks", "与去向不匹配。");

            //18.去向为允许附加数据,必须填写去向详细。
            if (db.Destinations.Find(this.DestinationId).IsHasAdditionalInfo && string.IsNullOrEmpty(this.DestinationRemarks))
                result.Add(new ValidationResult("“去向明细”不可为空", new string[] { "DestinationRemarks" }));

            //19.有去向，必须有离室时间。
            if (!db.Destinations.Find(this.DestinationId).IsUseForEmpty && !this.OutDepartmentTime.HasValue)
                result.Add(new ValidationResult("“离室时间”不可为空", new string[] { "OutDepartmentTime" }));

            //20.有去向，必须有经手护士。
            if (!db.Destinations.Find(this.DestinationId).IsUseForEmpty && string.IsNullOrEmpty(this.HandleNurse))
                result.Add(new ValidationResult("“经手护士”不可为空", new string[] { "HandleNurse" }));

            //21.去向为转院时，必须有转院原因。
            if (db.Destinations.Find(this.DestinationId).IsTransfer && db.TransferReasons.Find(this.TransferReasonId).IsUseForEmpty)
                result.Add(new ValidationResult("“转院原因”不可为空", new string[] { "TransferReasonId" }));

            //22.去向为转院时，必须有转往医院。
            if (db.Destinations.Find(this.DestinationId).IsTransfer && string.IsNullOrEmpty(this.TransferTarget))
                result.Add(new ValidationResult("“转往医院”不可为空", new string[] { "TransferTarget" }));

            //23.去向为专科时，必须有专科名称
            if (db.Destinations.Find(this.DestinationId).IsProfessional && string.IsNullOrEmpty(this.ProfessionalTarget))
                result.Add(new ValidationResult("“专科名称”不可为空", new string[] { "ProfessionalTarget" }));

            return result;
        }
    }
}