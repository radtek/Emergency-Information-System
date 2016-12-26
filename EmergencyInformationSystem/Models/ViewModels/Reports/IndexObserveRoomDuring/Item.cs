using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexObserveRoomDuring
{
    public class Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="observeRoomInfo">The rescue room information.</param>
        public Item(ObserveRoomInfo observeRoomInfo)
        {
            this.ObserveRoomInfoId = observeRoomInfo.ObserveRoomInfoId;

            this.PatientName = observeRoomInfo.PatientName;
            this.OutPatientNumber = observeRoomInfo.OutPatientNumber;
            this.InDepartmentTime = observeRoomInfo.InDepartmentTime;
            this.During = observeRoomInfo.During;
        }





        public Guid ObserveRoomInfoId { get; set; }





        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? InDepartmentTime { get; set; }

        [Display(Name = "停留时长")]
        public TimeSpan? During { get; set; }
    }
}