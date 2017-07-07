using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomMonth
{
    /// <summary>
    /// 抢救室月报表时长项第二级。
    /// </summary>
    public class DuringSecond
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuringSecond"/> class.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="time">The time.</param>
        public DuringSecond(IGrouping<int, RescueRoomInfo> group, DateTime time)
        {
            this.DuringHours = group.Key;
            this.Time = time;
            this.Level = 2;

            this.DuringHoursName = this.DuringHours.ToString();
            this.Count = group.Count();
        }





        public int DuringHours { get; set; }

        /// <summary>
        /// 统计项归属的时间点。
        /// </summary>
        public DateTime Time { get; set; }

        public int Level { get; set; }





        /// <summary>
        /// 时长名称。
        /// </summary>
        public string DuringHoursName { get; set; }

        /// <summary>
        /// 数量。
        /// </summary>
        public int Count { get; set; }
    }
}