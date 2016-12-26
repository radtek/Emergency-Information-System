using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomDrugRecords
{
    public class ItemSecond
    {
        public ItemSecond(RescueRoomDrugRecord rescueRoomDrugRecord)
        {
            this.ProductName = rescueRoomDrugRecord.ProductName;
            this.DosageQuantity = rescueRoomDrugRecord.DosageQuantity;
            this.DosageUnit = rescueRoomDrugRecord.DosageUnit;
            this.PrescriptionTime = rescueRoomDrugRecord.PrescriptionTime;
            this.Usage = rescueRoomDrugRecord.Usage;
        }





        [Display(Name = "品名")]
        public  string ProductName { get; set; }

        [Display(Name = "用量")]
        public  decimal DosageQuantity { get; set; }

        [Display(Name = "用量单位")]
        public  string DosageUnit { get; set; }

        [Display(Name = "处方时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public  DateTime? PrescriptionTime { get; set; }

        [Display(Name = "用法")]
        public  string Usage { get; set; }
    }
}