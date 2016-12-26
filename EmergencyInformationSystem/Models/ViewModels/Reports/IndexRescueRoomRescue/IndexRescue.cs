using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexRescueRoomRescue
{
    /// <summary>
    /// 抢救室统计项明细抢救项。
    /// </summary>
    public class IndexRescueRoomRescue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexRescueRoomRescue"/> class.
        /// </summary>
        /// <param name="time">指定的月报表涵盖时间点，只使用其中日期部分。</param>
        /// <param name="isRescue">是否抢救。</param>
        /// <param name="rescueResultId">抢救结果ID。</param>
        public IndexRescueRoomRescue(DateTime time, bool isRescue, int? rescueResultId)
        {
            var db = new EiSDbContext();

            this.Start = new DateTime(time.Year, time.Month, 1);
            this.End = this.Start.AddMonths(1);

            var query = db.RescueRoomInfos.Where(c => this.Start <= c.OutDepartmentTime && c.OutDepartmentTime < this.End && c.IsRescue == isRescue);
            if (rescueResultId != null)
                query = query.Where(c => c.RescueResultId == rescueResultId);
            query = query.OrderBy(c => c.InDepartmentTime).ThenBy(c => c.RescueRoomInfoId);

            this.List = query.ToList().Select(c => new Item(c)).ToList();
        }





        public DateTime Start { get; set; }

        public DateTime End { get; set; }





        public List<Item> List { get; set; }
    }
}