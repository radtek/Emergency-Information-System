using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.GreenPaths.DetailsAmiPrint
{
    public class ItemRescueRoomDrugRecord
    {
        public ItemRescueRoomDrugRecord(Models.Domains.Entities.RescueRoomDrugRecord target)
        {
            this.RescueRoomDrugRecordId = target.RescueRoomDrugRecordId;
            this.CFID = target.CFID;

            this.ProductCode = target.ProductCode;
            this.ProductName = target.ProductName;
            this.DosageQuantityFull = target.DosageQuantityFull;
            this.PrescriptionTime = target.PrescriptionTime;
            this.Usage = target.Usage;
        }





        public Guid RescueRoomDrugRecordId { get; set; }

        public Guid CFID { get; set; }





        [Display(Name = "代码")]
        public string ProductCode { get; set; }

        [Display(Name = "品名")]
        public string ProductName { get; set; }

        [Display(Name = "用量")]
        public string DosageQuantityFull { get; set; }

        [Display(Name = "处方时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? PrescriptionTime { get; set; }

        [Display(Name = "用法")]
        public string Usage { get; set; }
    }
}