using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexRescue
{
    /// <summary>
    /// 月报表抢救项表。
    /// </summary>
    public class IndexRescue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexRescue"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="isRescue">if set to <c>true</c> [is rescue].</param>
        /// <param name="rescueResultId">The rescue result identifier.</param>
        /// <param name="db">The database.</param>
        public IndexRescue(DateTime time, bool isRescue, int? rescueResultId, EiSDbContext db)
        {
            this.Start = new DateTime(time.Year, time.Month, 1);
            this.End = this.Start.AddMonths(1);

            var query = db.RescueRoomInfos.Where(c => this.Start <= c.OutDepartmentTime && c.OutDepartmentTime < this.End && c.IsRescue == isRescue);
            if (rescueResultId != null)
                query = query.Where(c => c.RescueResultId == rescueResultId);

            this.List = query.ToList().Select(c => new Item(c)).ToList();
        }





        public DateTime Start { get; set; }

        public DateTime End { get; set; }





        public List<Item> List { get; set; }
    }
}