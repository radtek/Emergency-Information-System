﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomMonth
{
    /// <summary>
    /// 抢救室月报表时长项第一级。
    /// </summary>
    public class DuringFirst
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuringFirst"/> class.
        /// </summary>
        public DuringFirst(IGrouping<string, RescueRoomInfo> group, DateTime time)
        {
            this.DuringMin = group.Min(c => c.DuringHours.Value);
            this.DuringMax = group.Max(c => c.DuringHours.Value);
            this.Time = time;
            this.Level = 1;

            this.DuringGroupName = group.Key;
            this.Count = group.Count();

            this.List = group.OrderBy(c => c.During).GroupBy(c => c.DuringHours.Value).Select(c => new DuringSecond(c, time)).ToList();
        }





        public int DuringMin { get; set; }

        public int DuringMax { get; set; }

        public DateTime Time { get; set; }

        public int Level { get; set; }





        public string DuringGroupName { get; set; }

        /// <summary>
        /// 数量。
        /// </summary>
        public int Count { get; set; }





        public List<DuringSecond> List { get; set; }
    }
}