using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.GreenPaths.DetailsAmiPrint
{
    public class ItemRescueRoomTreatmentRecord
    {
        public ItemRescueRoomTreatmentRecord(Models.Domains.Entities.RescueRoomTreatmentRecord target)
        {
            this.RescueRoomTreatmentRecordId = target.RescueRoomTreatmentRecordId;
            this.CFID = target.CFID;

            this.ProductCode = target.ProductCode;
            this.ProductName = target.ProductName;
            this.DosageQuantity = target.DosageQuantity;
            this.PrescriptionTime = target.PrescriptionTime;
        }





        public Guid RescueRoomTreatmentRecordId { get; set; }

        public Guid CFID { get; set; }





        [Display(Name = "代码")]
        public string ProductCode { get; set; }

        [Display(Name = "品名")]
        public string ProductName { get; set; }

        [Display(Name = "用量")]
        public decimal DosageQuantity { get; set; }

        [Display(Name = "处方时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? PrescriptionTime { get; set; }
    }
}