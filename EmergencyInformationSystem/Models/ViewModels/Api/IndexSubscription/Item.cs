using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.Api.IndexSubscription
{
    public class Item
    {
        public Item(Models.Domains.Entities.RescueRoomInfo target)
        {
            this.RescueRoomInfoId = target.RescueRoomInfoId;
            this.Controller = "RescueRoomInfos";

            this.PatientName = target.PatientName;
            this.OutPatientNumber = target.OutPatientNumber;
            this.InDepartmentTime = target.InDepartmentTime;
            this.BedNameFull = target.BedNameFull;
            this.Sex = target.Sex;
            this.ReceiveAgeName = target.ReceiveAgeName;
            this.DestinationFirstName = target.DestinationFirstName;
            this.DestinationFirstTime = target.DestinationFirstTime;
            this.DestinationFirstContact = target.DestinationFirstContact;
            this.DestinationSecondName = target.DestinationSecondName;
            this.Source = "抢救室";
        }

        public Item(Models.Domains.Entities.ObserveRoomInfo target)
        {
            this.ObserveRoomInfoId = target.ObserveRoomInfoId;
            this.Controller = "ObserveRoomInfos";

            this.PatientName = target.PatientName;
            this.OutPatientNumber = target.OutPatientNumber;
            this.InDepartmentTime = target.InDepartmentTime;
            this.BedNameFull = target.BedNameFull;
            this.Sex = target.Sex;
            this.ReceiveAgeName = target.ReceiveAgeName;
            this.DestinationFirstName = target.DestinationFirstName;
            this.DestinationFirstTime = target.DestinationFirstTime;
            this.DestinationFirstContact = target.DestinationFirstContact;
            this.DestinationSecondName = target.DestinationSecondName;
            this.Source = "留观室";
        }

        public Item()
        {

        }





        public int? RescueRoomInfoId { get; set; }

        public Guid? ObserveRoomInfoId { get; set; }

        public string Controller { get; set; }





        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }

        [Display(Name = "床位号")]
        public string BedNameFull { get; set; }

        [Display(Name = "性别")]
        public string Sex { get; set; }

        [Display(Name = "就诊年龄")]
        public string ReceiveAgeName { get; set; }

        [Display(Name = "预约首选科室")]
        public string DestinationFirstName { get; set; }

        [Display(Name = "预约首选时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? DestinationFirstTime { get; set; }

        [Display(Name = "预约首选医师")]
        public string DestinationFirstContact { get; set; }

        [Display(Name = "预约次选科室")]
        public string DestinationSecondName { get; set; }

        [Display(Name = "来源")]
        public string Source { get; set; }
    }
}