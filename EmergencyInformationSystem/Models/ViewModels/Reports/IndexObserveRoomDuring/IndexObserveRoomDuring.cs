using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexObserveRoomDuring
{
    public class IndexObserveRoomDuring
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexObserveRoomDuring"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="duringHours">The during hours.</param>
        /// <param name="duringMin">The during minimum.</param>
        /// <param name="duringMax">The during maximum.</param>
        public IndexObserveRoomDuring(DateTime time, int? duringHours, int? duringMin, int? duringMax)
        {
            var db = new EiSDbContext();

            this.Start = new DateTime(time.Year, time.Month, 1);
            this.End = this.Start.AddMonths(1);

            var list = db.ObserveRoomInfos.Where(c => this.Start <= c.OutDepartmentTime && c.OutDepartmentTime < this.End).ToList();
            if (duringHours != null)
                list = list.Where(c => c.DuringHours == duringHours.Value).ToList();
            if (duringMin != null)
                list = list.Where(c => duringMin <= c.DuringHours).ToList();
            if (duringMax != null)
                list = list.Where(c => c.DuringHours <= duringMax).ToList();

            list = list.OrderBy(c => c.InDepartmentTime).ThenBy(c => c.ObserveRoomInfoId).ToList();

            this.List = list.Select(c => new Item(c)).ToList();
        }



        public DateTime Start { get; set; }

        public DateTime End { get; set; }





        public List<Item> List { get; set; }
    }
}