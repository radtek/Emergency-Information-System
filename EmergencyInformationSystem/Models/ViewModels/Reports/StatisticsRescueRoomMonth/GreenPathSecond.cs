using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomMonth
{
    /// <summary>
    /// 月报表绿色通道项第二级。
    /// </summary>
    public class GreenPathSecond
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GreenPathSecond"/> class.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="time">The time.</param>
        public GreenPathSecond(IEnumerable<RescueRoomInfo> group,DateTime time)
        {
            this.GreenPathCategoryId = group.First().GreenPathCategoryId;
            this.Time = time;

            this.GreenPathCategoryName = group.First().GreenPathCategory.GreenPathCategoryName;
            this.Count = group.Count();
            this.Level = 2;

            if (!group.First().GreenPathCategory.IsHasAdditionalInfo)
            {
                this.List = new List<GreenPathThird>();
                return;
            }
            else
                this.List = group.OrderBy(c => c.GreenPathCategoryRemarks).GroupBy(c => c.GreenPathCategoryRemarks).Select(c => new GreenPathThird(c, time)).ToList();
        }





        /// <summary>
        /// 绿色通道病种ID。
        /// </summary>
        public int GreenPathCategoryId { get; set; }

        /// <summary>
        /// 统计项归属的时间点。
        /// </summary>
        public DateTime Time { get; set; }

        public int Level { get; set; }





        /// <summary>
        /// 绿色通道病种名称。
        /// </summary>
        public string GreenPathCategoryName { get; set; }

        /// <summary>
        /// 数量。
        /// </summary>
        public int Count { get; set; }





        public List<GreenPathThird> List { get; set; }
    }
}