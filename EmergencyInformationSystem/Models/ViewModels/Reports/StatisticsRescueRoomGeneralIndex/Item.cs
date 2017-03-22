using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomGeneralIndex
{
    public class Item
    {
        public Item(Models.Domains.Entities.RescueRoomInfo rescueRoomInfo)
        {
            this.PatientName = rescueRoomInfo.PatientName;
            this.OutPatientNumber = rescueRoomInfo.OutPatientNumber;
            this.InDepartmentTime = rescueRoomInfo.InDepartmentTime;
            this.OutDepartmentTime = rescueRoomInfo.OutDepartmentTime;
            this.During = rescueRoomInfo.During;
        }





        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? InDepartmentTime { get; set; }

        [Display(Name = "离室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? OutDepartmentTime { get; set; }

        [Display(Name = "停留时长")]
        public TimeSpan? During { get; set; }
    }
}