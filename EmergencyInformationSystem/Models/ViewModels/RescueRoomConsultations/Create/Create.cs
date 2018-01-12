using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomConsultations.Create
{
    public class Create : IValidatableObject
    {
        public Create()
        {

        }





        public Guid RescueRoomConsultationId { get; set; }

        public Guid RescueRoomInfoId { get; set; }

        public bool GoToGreenPath { get; set; }





        [Display(Name = "申请时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime RequestTime { get; set; }

        [Display(Name = "到达时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? ArriveTime { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "会诊医师")]
        public string ConsultationDoctorName { get; set; }

        [Display(Name = "会诊科室")]
        public Guid ConsultationDepartmentId { get; set; }





        public Domains.Entities.RescueRoomConsultation GetReturn()
        {
            var target = new Domains.Entities.RescueRoomConsultation();

            target.RescueRoomConsultationId = Guid.NewGuid();
            target.RescueRoomInfoId = this.RescueRoomInfoId;

            target.RequestTime = this.RequestTime;
            target.ArriveTime = this.ArriveTime;
            target.ConsultationDoctorName = this.ConsultationDoctorName;
            target.ConsultationDepartmentId = this.ConsultationDepartmentId;

            target.UpdateTime = DateTime.Now;

            return target;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            //1.会诊到达时间不可早于会诊申请时间。
            if (this.ArriveTime.HasValue && this.ArriveTime.Value < this.RequestTime)
                result.Add(new ValidationResult("“不可早于申请时间", new string[] { "ArriveTime" }));

            return result;
        }
    }
}