﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsMonth
{
    /// <summary>
    /// 月报表去向项第二级。
    /// </summary>
    public class DestinationSecond
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DestinationSecond"/> class.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="time">The time.</param>
        public DestinationSecond(IEnumerable<RescueRoomInfo> group,DateTime time)
        {
            this.DestinationId = group.First().DestinationId;
            this.Time = time;

            this.DestinationName = group.First().Destination.DestinationName;
            this.Count = group.Count();

            if (string.IsNullOrEmpty(this.DestinationName))
                this.DestinationName = "--";

            if (!group.First().Destination.IsHasAdditionalInfo)
            {
                this.List = new List<DestinationThird>();
                return;
            }
            else
                this.List = group.OrderBy(c => c.DestinationRemarks).GroupBy(c => c.DestinationRemarks).Select(c => new DestinationThird(c, time)).ToList();
        }





        public int DestinationId { get; set; }

        public DateTime Time { get; set; }





        /// <summary>
        /// 去向名称。
        /// </summary>
        public string DestinationName { get; set; }

        /// <summary>
        /// 数量。
        /// </summary>
        public int Count { get; set; }





        public List<DestinationThird> List { get; set; }
    }
}