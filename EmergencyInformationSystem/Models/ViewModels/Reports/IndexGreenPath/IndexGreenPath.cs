using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexGreenPath
{
    /// <summary>
    /// Class IndexGreenPath.
    /// </summary>
    public class IndexGreenPath
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexGreenPath"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="isGreenPath">if set to <c>true</c> [is green path].</param>
        /// <param name="greenPathCategoryId">The green path category identifier.</param>
        /// <param name="greenPathCategoryRemarks">The green path category remarks.</param>
        /// <param name="db">The database.</param>
        public IndexGreenPath(DateTime time, bool? isGreenPath, int? greenPathCategoryId, string greenPathCategoryRemarks, EiSDbContext db)
        {
            this.Start = new DateTime(time.Year, time.Month, 1);
            this.End = this.Start.AddMonths(1);

            var query = db.RescueRoomInfos.Where(c => this.Start <= c.OutDepartmentTime && c.OutDepartmentTime < this.End);
            if (greenPathCategoryId != null)
                query = query.Where(c => c.GreenPathCategoryId == greenPathCategoryId);
            if (!string.IsNullOrEmpty(greenPathCategoryRemarks))
                query = query.Where(c => c.GreenPathCategoryRemarks == greenPathCategoryRemarks);

            var list = query.ToList();

            if (isGreenPath != null)
                list = list.Where(c => c.IsGreenPath == isGreenPath).ToList();

            this.List = list.Select(c => new Item(c)).ToList();
        }





        public DateTime Start { get; set; }

        public DateTime End { get; set; }





        public List<Item> List { get; set; }
    }
}