using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsIndexRescueRoomDuring
{
    /// <summary>
    /// Class IndexDuring.
    /// </summary>
    public class StatisticsIndexRescueRoomDuring
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsIndexRescueRoomDuring"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="duringHours">The during hours.</param>
        /// <param name="duringMin">The during minimum.</param>
        /// <param name="duringMax">The during maximum.</param>
        public StatisticsIndexRescueRoomDuring(DateTime time, int? duringHours, int? duringMin, int? duringMax, int level)
        {
            var db = new EiSDbContext();

            this.Start = new DateTime(time.Year, time.Month, 1);
            this.End = this.Start.AddMonths(1);
            this.Message = string.Format("{0} 停留时长：", this.Start.ToString("yyyy年M月"));

            var list = db.RescueRoomInfos.Where(c => this.Start <= c.OutDepartmentTime && c.OutDepartmentTime < this.End).OrderBy(c => c.InDepartmentTime).ThenBy(c => c.RescueRoomInfoId).ToList();
            if (level == 1)
            {
                list = list.Where(c => duringMin.Value <= c.DuringHours && c.DuringHours <= duringMax.Value).ToList();
                this.Message += list.First().DuringGroupName;
            }
            if (level == 2)
            {
                list = list.Where(c => c.DuringHours == duringHours.Value).ToList();
                this.Message += duringHours + "小时";
            }

            this.List = list.Select(c => new Item(c)).ToList();
        }





        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Message { get; set; }





        public List<Item> List { get; set; }
    }
}