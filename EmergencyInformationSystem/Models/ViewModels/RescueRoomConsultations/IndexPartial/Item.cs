using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomConsultations.IndexPartial
{
    public class Item
    {
        public Item(Domains.Entities.RescueRoomConsultation target)
        {
            this.RescueRoomConsultationId = target.RescueRoomConsultationId;

            this.RequestTime = target.RequestTime;
            this.ArriveTime = target.ArriveTime;
            this.ConsultationDoctorName = target.ConsultationDoctorName;
            this.ConsultationDepartmentName = target.ConsultationDepartmentName;
        }





        public Guid RescueRoomConsultationId { get; set; }





        [Display(Name = "申请时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime RequestTime { get; set; }

        [Display(Name = "到达时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? ArriveTime { get; set; }

        [Display(Name = "会诊医师")]
        public string ConsultationDoctorName { get; set; }

        [Display(Name = "会诊科室")]
        public string ConsultationDepartmentName { get; set; }
    }
}