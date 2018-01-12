using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.GreenPaths.IndexAmi
{
    public class Item
    {
        public Item(GreenPathAmi target)
        {
            this.GreenPathAmiId = target.GreenPathAmiId;
            this.RescueRoomInfoId = target.RescueRoomInfoId;
            this.IsLeave = target.RescueRoomInfo.OutDepartmentTime.HasValue;

            this.PatientName = target.RescueRoomInfo.PatientName;
            this.OutPatientNumber = target.RescueRoomInfo.OutPatientNumber;
            this.InDepartmentTime = target.RescueRoomInfo.InDepartmentTime;

            this.OccurrenceTime = target.OccurrenceTime;

            this.EcgFirstTime = target.EcgFirstTime;
            this.EcgSecondTime = target.EcgSecondTime;
            this.Remarks = target.Remarks;

            this.FinishPathTime = target.FinishPathTime;
            this.OutDepartmentTime = target.RescueRoomInfo.OutDepartmentTime;
            this.IsHeldUp = target.IsHeldUp;
            this.Problem = target.Problem;
        }





        public Guid GreenPathAmiId { get; set; }

        public Guid RescueRoomInfoId { get; set; }

        public bool IsLeave { get; set; }





        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }





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

        [Display(Name = "离室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]

        public DateTime? OutDepartmentTime { get; set; }

        [Display(Name = "滞留")]
        public bool IsHeldUp { get; set; }

        [Display(Name = "存在问题")]
        public string Problem { get; set; }
    }
}