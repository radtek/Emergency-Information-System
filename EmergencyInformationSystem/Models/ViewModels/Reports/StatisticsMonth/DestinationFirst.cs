using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsMonth
{
    /// <summary>
    /// 月报表去向项第一级。
    /// </summary>
    public class DestinationFirst
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DestinationFirst"/> class.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="time">The time.</param>
        public DestinationFirst(IEnumerable<RescueRoomInfo> group, DateTime time)
        {
            this.IsClassifiedToInDepartment = group.First().Destination.IsClassifiedToInDepartment;
            this.IsClassifiedToOutDepartment = group.First().Destination.IsClassifiedToOutDepartment;
            this.IsClassifiedLeave = group.First().Destination.IsClassifiedLeave;
            this.IsClassifiedToOther = group.First().Destination.IsClassifiedToOther;
            this.Time = time;

            this.DestinationCategoryNameConcat = group.First().Destination.DestinationCategoryNameConcat;
            this.Count = group.Count();

            if (string.IsNullOrEmpty(this.DestinationCategoryNameConcat))
                this.DestinationCategoryNameConcat = "--";

            this.List = group.OrderBy(c => c.DestinationId).GroupBy(c => c.DestinationId).Select(c => new DestinationSecond(c, time)).ToList();
        }





        public bool IsClassifiedToInDepartment { get; set; }

        public bool IsClassifiedToOutDepartment { get; set; }

        public bool IsClassifiedLeave { get; set; }

        public bool IsClassifiedToOther { get; set; }

        public DateTime Time { get; set; }





        public string DestinationCategoryNameConcat { get; set; }

        /// <summary>
        /// 数量。
        /// </summary>
        public int Count { get; set; }





        public List<DestinationSecond> List { get; set; }
    }
}