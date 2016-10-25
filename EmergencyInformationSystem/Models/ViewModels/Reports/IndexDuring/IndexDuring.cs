using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexDuring
{
    /// <summary>
    /// Class IndexDuring.
    /// </summary>
    public class IndexDuring
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexDuring"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="duringHours">The during hours.</param>
        /// <param name="duringMin">The during minimum.</param>
        /// <param name="duringMax">The during maximum.</param>
        /// <param name="db">The database.</param>
        public IndexDuring(DateTime time, int? duringHours, int? duringMin, int? duringMax, EiSDbContext db)
        {
            this.Start = new DateTime(time.Year, time.Month, 1);
            this.End = this.Start.AddMonths(1);

            var list = db.RescueRoomInfos.Where(c => this.Start <= c.OutDepartmentTime && c.OutDepartmentTime < this.End).ToList();
            if (duringHours != null)
                list = list.Where(c => c.DuringHours == duringHours.Value).ToList();
            if (duringMin != null)
                list = list.Where(c => duringMin <= c.DuringHours).ToList();
            if (duringMax != null)
                list = list.Where(c => c.DuringHours <= duringMax).ToList();

            this.List = list.Select(c => new Item(c)).ToList();
        }





        public DateTime Start { get; set; }

        public DateTime End { get; set; }





        public List<Item> List { get; set; }
    }
}