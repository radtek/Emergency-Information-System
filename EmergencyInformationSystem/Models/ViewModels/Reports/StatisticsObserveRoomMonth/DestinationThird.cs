using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsObserveRoomMonth
{
    /// <summary>
    /// 留观室月报表去向项第三级。
    /// </summary>
    public class DestinationThird
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DestinationThird"/> class.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="time">The time.</param>
        public DestinationThird(IGrouping<string, ObserveRoomInfo> group, DateTime time)
        {
            this.DestinationId = group.First().DestinationId;
            this.DestinationRemarks = group.Key;
            this.Time = time;
            this.Level = 3;

            this.DestinationRemarksForDisplay = group.Key;
            this.Count = group.Count();

            if (string.IsNullOrEmpty(this.DestinationRemarksForDisplay))
                this.DestinationRemarksForDisplay = "--";
        }





        /// <summary>
        /// 去向ID。
        /// </summary>
        public int DestinationId { get; set; }

        /// <summary>
        /// 去向明细。
        /// </summary>
        public string DestinationRemarks { get; set; }

        /// <summary>
        /// 统计项归属的时间点。
        /// </summary>
        public DateTime Time { get; set; }

        public int Level { get; set; }





        public string DestinationRemarksForDisplay { get; set; }

        /// <summary>
        /// 数量。
        /// </summary>
        public int Count { get; set; }
    }
}