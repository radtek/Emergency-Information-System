using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomMonth
{
    /// <summary>
    /// 月报表绿色通道项第三级。
    /// </summary>
    public class GreenPathThird
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GreenPathThird"/> class.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="time">The time.</param>
        public GreenPathThird(IGrouping<string, RescueRoomInfo> group, DateTime time)
        {
            this.GreenPathCategoryId = group.First().GreenPathCategoryId.Value;
            this.GreenPathCategoryRemarks = group.Key;
            this.Time = time;
            this.Level = 3;

            this.Count = group.Count();
            this.GreenPathCategoryRemarksForDisplay = group.Key;

            if (string.IsNullOrEmpty(this.GreenPathCategoryRemarksForDisplay))
                this.GreenPathCategoryRemarksForDisplay = "--";
        }





        /// <summary>
        /// 绿色通道病种ID。
        /// </summary>
        public Guid GreenPathCategoryId { get; set; }

        /// <summary>
        /// 绿色通道其他病种名称。
        /// </summary>
        public string GreenPathCategoryRemarks { get; set; }

        /// <summary>
        /// 统计项归属的时间点。
        /// </summary>
        public DateTime Time { get; set; }

        public int Level { get; set; }





        /// <summary>
        /// 数量。
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 绿色通道其他病种名称。（显示用）
        /// </summary>
        public string GreenPathCategoryRemarksForDisplay { get; set; }
    }
}