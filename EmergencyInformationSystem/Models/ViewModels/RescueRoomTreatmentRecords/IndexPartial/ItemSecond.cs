using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomTreatmentRecords.IndexPartial
{
    public class ItemSecond
    {
        public ItemSecond(RescueRoomTreatmentRecord target)
        {
            this.ProductCode = target.ProductCode;
            this.ProductName = target.ProductName;
            this.GoodsName = target.GoodsName;
            this.DosageQuantity = target.DosageQuantity;
            this.DosageUnit = target.DosageUnit;
            this.PrescriptionTime = target.PrescriptionTime;
            this.Usage = target.Usage;
        }





        [Display(Name = "代码")]
        public string ProductCode { get; set; }

        [Display(Name = "品名")]
        public string ProductName { get; set; }

        [Display(Name = "商品名")]
        public string GoodsName { get; set; }

        [Display(Name = "用量")]
        public decimal DosageQuantity { get; set; }

        [Display(Name = "用量单位")]
        public string DosageUnit { get; set; }

        [Display(Name = "处方时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? PrescriptionTime { get; set; }

        [Display(Name = "用法")]
        public string Usage { get; set; }
    }
}