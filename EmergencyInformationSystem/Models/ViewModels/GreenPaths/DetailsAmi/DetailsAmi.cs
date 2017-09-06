using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.GreenPaths.DetailsAmi
{
    public class DetailsAmi
    {
        public DetailsAmi(Models.Domains.Entities.GreenPathAmi target)
        {
            this.GreenPathAmiId = target.GreenPathAmiId;
            this.RescueRoomInfoId = target.RescueRoomInfoId;

            this.OccurrenceTime = target.OccurrenceTime;

            this.EcgFirstTime = target.EcgFirstTime;
            this.EcgSecondTime = target.EcgSecondTime;
            this.Remarks = target.Remarks;

            this.FinishPathTime = target.FinishPathTime;
            this.IsHeldUp = target.IsHeldUp;
            this.During = target.During;
            this.Problem = target.Problem;
        }





        public Guid GreenPathAmiId { get; set; }

        public int RescueRoomInfoId { get; set; }





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

        [Display(Name = "滞留")]
        public bool IsHeldUp { get; set; }

        [Display(Name = "通道停留时长")]
        public TimeSpan? During { get; set; }

        [Display(Name = "存在问题")]
        public string Problem { get; set; }
    }
}