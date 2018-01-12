using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.GreenPaths.EditAmi
{
    public class EditAmi
    {
        public EditAmi(Models.Domains.Entities.GreenPathAmi target)
        {
            this.GreenPathAmiId = target.GreenPathAmiId;
            this.RescueRoomInfoId = target.RescueRoomInfoId;

            this.OccurrenceTime = target.OccurrenceTime;

            this.EcgFirstTime = target.EcgFirstTime;
            this.EcgSecondTime = target.EcgSecondTime;
            this.Remarks = target.Remarks;

            this.FinishPathTime = target.FinishPathTime;
            this.IsHeldUp = target.IsHeldUp;
            this.Problem = target.Problem;

            this.TimeStamp = target.TimeStamp;
        }

        public EditAmi()
        {

        }





        public Guid GreenPathAmiId { get; set; }

        public Guid RescueRoomInfoId { get; set; }





        [Display(Name = "发病时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? OccurrenceTime { get; set; }





        [Display(Name = "首次心电图时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? EcgFirstTime { get; set; }

        [Display(Name = "再次心电图时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? EcgSecondTime { get; set; }

        [Display(Name = "备注")]
        public string Remarks { get; set; }





        [Display(Name = "完成通道时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? FinishPathTime { get; set; }

        [Display(Name = "滞留")]
        public bool IsHeldUp { get; set; }

        [Display(Name = "存在问题")]
        public string Problem { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }





        public void GetReturn(Domains.Entities.GreenPathAmi target)
        {
            target.OccurrenceTime = this.OccurrenceTime;

            target.EcgFirstTime = this.EcgFirstTime;
            target.EcgSecondTime = this.EcgSecondTime;
            target.Remarks = this.Remarks;

            target.FinishPathTime = this.FinishPathTime;
            target.IsHeldUp = this.IsHeldUp;
            target.Problem = this.Problem;

            target.TimeStamp = this.TimeStamp;
            target.UpdateTime = DateTime.Now;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            var db = new Domains.Entities.EiSDbContext();
            var rescueRoomInfo = db.RescueRoomInfos.Find(this.RescueRoomInfoId);

            //1-须先有首次心电图才能有再次心电图。
            if (this.EcgSecondTime.HasValue && !this.EcgFirstTime.HasValue)
                result.Add(new ValidationResult("“须先有首次心电图才能有再次心电图", new string[] { "EcgSecondTime" }));
            //2-再次心电图时间不可早于首次心电图时间。
            if (this.EcgSecondTime.HasValue && this.EcgFirstTime.HasValue && this.EcgFirstTime.Value > this.EcgSecondTime.Value)
                result.Add(new ValidationResult("“再次心电图时间不可早于首次心电图时间", new string[] { "EcgSecondTime" }));
            //3-完成通道时，发病时间不可为空。
            if (this.FinishPathTime.HasValue && !this.OccurrenceTime.HasValue)
                result.Add(new ValidationResult("“完成通道时，发病时间不可为空", new string[] { "OccurrenceTime" }));
            //4-发病时间不可晚于接诊时间。           
            if (rescueRoomInfo.ReceiveTime.HasValue && this.OccurrenceTime.HasValue && rescueRoomInfo.ReceiveTime.Value < this.OccurrenceTime.Value)
                result.Add(new ValidationResult("发病时间不可晚于接诊时间", new string[] { "OccurrenceTime" }));
            //5-首次心电图时间不能早于接诊时间。
            //if (rescueRoomInfo.ReceiveTime.HasValue && greenPathAmi.EcgFirstTime.HasValue && rescueRoomInfo.ReceiveTime.Value > greenPathAmi.EcgFirstTime.Value)
            //    ModelState.AddModelError("EcgFirstTime", "首次心电图时间不能早于接诊时间。");
            //6-再次心电图时间不能晚于完成通道时间。
            if (this.FinishPathTime.HasValue && this.EcgSecondTime.HasValue && this.FinishPathTime.Value < this.EcgSecondTime.Value)
                result.Add(new ValidationResult("再次心电图时间不能晚于完成通道时间", new string[] { "EcgSecondTime" }));
            //7-完成通道时间不能早于接诊时间。
            if (rescueRoomInfo.ReceiveTime.HasValue && this.FinishPathTime.HasValue && rescueRoomInfo.ReceiveTime.Value > this.FinishPathTime.Value)
                result.Add(new ValidationResult("完成通道时间不能早于接诊时间", new string[] { "EcgFirstTime" }));

            return result;
        }
    }
}