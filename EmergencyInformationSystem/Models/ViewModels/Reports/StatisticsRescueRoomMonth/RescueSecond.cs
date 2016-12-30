using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomMonth
{
    /// <summary>
    /// 月报表抢救项第二级。
    /// </summary>
    public class RescueSecond
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RescueSecond"/> class.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="time">The time.</param>
        public RescueSecond(IEnumerable<RescueRoomInfo> group,DateTime time)
        {
            this.IsRescue = group.First().IsRescue;
            this.RescueResultId = group.First().RescueResultId;
            this.Time = time;
            this.Level = 2;

            this.RescueResultName = group.First().RescueResult.RescueResultName;
            if (string.IsNullOrEmpty(this.RescueResultName))
                this.RescueResultName = "--";
            this.Count = group.Count();
        }





        /// <summary>
        /// 是否抢救。
        /// </summary>
        public bool IsRescue { get; set; }

        /// <summary>
        /// 抢救结果ID。
        /// </summary>
        public int RescueResultId { get; set; }

        /// <summary>
        /// 统计项归属的时间点。
        /// </summary>
        public DateTime Time { get; set; }

        public int Level { get; set; }





        /// <summary>
        /// 抢救名称全。
        /// </summary>
        public string RescueResultName { get; set; }

        /// <summary>
        /// 数量。
        /// </summary>
        public int Count { get; set; }
    }
}