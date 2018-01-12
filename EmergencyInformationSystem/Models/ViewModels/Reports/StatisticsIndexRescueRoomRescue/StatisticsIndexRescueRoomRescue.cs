using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsIndexRescueRoomRescue
{
    /// <summary>
    /// 抢救室统计项明细抢救项。
    /// </summary>
    public class StatisticsIndexRescueRoomRescue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsIndexRescueRoomRescue"/> class.
        /// </summary>
        /// <param name="time">指定的月报表涵盖时间点，只使用其中日期部分。</param>
        /// <param name="isRescue">是否抢救。</param>
        /// <param name="rescueResultId">抢救结果ID。</param>
        public StatisticsIndexRescueRoomRescue(DateTime time, bool isRescue, Guid? rescueResultId, int level)
        {
            var db = new EiSDbContext();

            this.Start = new DateTime(time.Year, time.Month, 1);
            this.End = this.Start.AddMonths(1);
            this.Message = string.Format("{0} 抢救：", this.Start.ToString("yyyy年M月"));

            var query = db.RescueRoomInfos.Where(c => this.Start <= c.OutDepartmentTime && c.OutDepartmentTime < this.End);
            //Level 1
            if (level >= 1)
            {
                query = query.Where(c => c.IsRescue == isRescue);
                this.Message += query.First().IsRescueName;
            }
            //Level 2
            if (level >= 2)
            {
                query = query.Where(c => c.RescueResultId == rescueResultId);
                this.Message += query.First().RescueResultNameFull;
            }
            query = query.OrderBy(c => c.InDepartmentTime).ThenBy(c => c.RescueRoomInfoId);

            this.List = query.ToList().Select(c => new Item(c)).ToList();
        }





        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Message { get; set; }





        public List<Item> List { get; set; }
    }
}