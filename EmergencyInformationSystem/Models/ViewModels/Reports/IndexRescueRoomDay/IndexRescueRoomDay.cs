using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexRescueRoomDay
{
    /// <summary>
    /// 抢救室日报表。
    /// </summary>
    public class IndexRescueRoomDay
    {
        public IndexRescueRoomDay(DateTime time)
        {
            var db = new EiSDbContext();

            this.End = time.Date.AddHours(8);
            this.Start = End.AddDays(-1);

            var queryIn = db.RescueRoomInfos.Where(c => this.Start <= c.InDepartmentTime && c.InDepartmentTime < this.End);
            var queryStay = db.RescueRoomInfos.Where(c => c.InDepartmentTime < this.Start && (this.Start < c.OutDepartmentTime || c.OutDepartmentTime == null));

            var query = queryIn.Union(queryStay);
            var queryOrdered = query.OrderBy(c => c.InDepartmentTime).ThenBy(c => c.RescueRoomInfoId);
            var list = queryOrdered.ToList();

            this.List = list.Select(c => new Item(c)).ToList();
        }





        [Display(Name = "开始时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy年M月d日H时}")]
        public DateTime Start { get; set; }

        [Display(Name = "结束时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy年M月d日H时}")]
        public DateTime End { get; set; }





        public List<Item> List { get; set; }
    }
}