using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomGeneral
{
    public class ItemBase
    {
        public ItemBase(DateTime start, DateTime end, int level, int countAll, IEnumerable<Models.Domains.Entities.RescueRoomInfo> group)
        {
            this.Start = start;
            this.End = end;
            this.Level = level;
            this.Count = group.Count();
            this.Rate = countAll == 0 ? 0 : (decimal)this.Count / countAll;
        }





        public string Name { get; set; }

        [Display(Name = "例数")]
        public int Count { get; set; }

        [Display(Name = "百分比")]
        [DisplayFormat(DataFormatString = "{0:p}")]
        public decimal Rate { get; set; }





        public string TitleOfName { get; set; }

        public int Level { get; set; }





        public DateTime Start { get; set; }

        public DateTime End { get; set; }





        public List<ItemBase> List { get; set; }
    }
}