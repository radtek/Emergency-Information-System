using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomMonth
{
    /// <summary>
    /// 月报表抢救项第一级。
    /// </summary>
    public class RescueFirst
    {
        public RescueFirst(IGrouping<bool, RescueRoomInfo> group, DateTime time)
        {
            this.IsRescue = group.Key;
            this.Time = time;

            this.IsRescueName = group.First().IsRescueName;
            this.Count = group.Count();
            this.Level = 1;

            if (this.IsRescue == false)
            {
                this.List = new List<RescueSecond>();
            }
            else
            {
                this.List = group.OrderBy(c => c.RescueResultId).GroupBy(c => c.RescueResultId).Select(c => new RescueSecond(c, time)).ToList();
            }
        }





        /// <summary>
        /// 是否抢救。
        /// </summary>
        public bool IsRescue { get; set; }

        /// <summary>
        /// 统计项归属的时间点。
        /// </summary>
        public DateTime Time { get; set; }

        public int Level { get; set; }





        /// <summary>
        /// 是否抢救名称。
        /// </summary>
        public string IsRescueName { get; set; }

        /// <summary>
        /// 数量。
        /// </summary>
        public int Count { get; set; }





        public List<RescueSecond> List { get; set; }
    }
}