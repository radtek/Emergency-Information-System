using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsMonth
{
    /// <summary>
    /// 月报表绿色通道项第一级。
    /// </summary>
    public class GreenPathFirst
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GreenPathFirst"/> class.
        /// </summary>
        /// <param name="group">The gourp.</param>
        /// <param name="time">The time.</param>
        public GreenPathFirst(IEnumerable<RescueRoomInfo> group, DateTime time)
        {
            this.IsGreenPath = group.First().IsGreenPath;
            this.Time = time;

            this.IsGreenPathName = group.First().IsGreenPathName;
            this.Count = group.Count();

            if (!group.First().IsGreenPath)
            {
                this.List = new List<GreenPathSecond>();
                return;
            }
            else
                this.List = group.OrderBy(c => c.GreenPathCategoryId).GroupBy(c => c.GreenPathCategoryId).Select(c => new GreenPathSecond(c, time)).ToList();
        }





        public bool IsGreenPath { get; set; }

        public DateTime Time { get; set; }





        /// <summary>
        /// 是否绿色通道名称。
        /// </summary>
        public string IsGreenPathName { get; set; }

        /// <summary>
        /// 数量。
        /// </summary>
        public int Count { get; set; }





        public List<GreenPathSecond> List { get; set; }
    }
}