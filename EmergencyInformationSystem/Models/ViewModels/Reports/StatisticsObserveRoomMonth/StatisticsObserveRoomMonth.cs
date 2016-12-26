using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsObserveRoomMonth
{
    /// <summary>
    /// 留观室月报表。
    /// </summary>
    public class StatisticsObserveRoomMonth
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsObserveRoomMonth"/> class.
        /// </summary>
        /// <param name="time">指定的月报表涵盖时间点，只取其中月份部分。</param>
        public StatisticsObserveRoomMonth(DateTime time)
        {
            var db = new EiSDbContext();

            var start = new DateTime(time.Year, time.Month, 1);
            var end = start.AddMonths(1);

            var list = db.ObserveRoomInfos.Where(c => start <= c.OutDepartmentTime && c.OutDepartmentTime < end).ToList();

            this.Time = start;

            this.CountAll = list.Count();

            //停留时长
            if (this.CountAll > 0)
                this.AverageDuring = new TimeSpan((long)(list.Average(c => c.During.Value.Ticks)));
            this.ListDuringFirst = list.OrderBy(c => c.During).GroupBy(c => c.DuringGroupName).Select(c => new DuringFirst(c, time)).ToList();

            //去向
            this.ListDestinationFirst = list.OrderBy(c => c.Destination.DestinationCategoryNameConcat).GroupBy(c => c.Destination.DestinationCategoryNameConcat).Select(c => new DestinationFirst(c, time)).ToList();
        }





        public DateTime Time { get; set; }





        [Display(Name = "总例数")]
        public int CountAll { get; set; }

        [Display(Name = "平均停留时长")]
        public TimeSpan AverageDuring { get; set; }





        public List<DuringFirst> ListDuringFirst { get; set; }

        public List<DestinationFirst> ListDestinationFirst { get; set; }
    }
}