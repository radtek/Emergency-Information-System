using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexRescueRoomDestination
{
    /// <summary>
    /// Class IndexDestination.
    /// </summary>
    public class IndexRescueRoomDestination
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexRescueRoomDestination"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="isClassifiedToInDepartment">if set to <c>true</c> [is classified to in department].</param>
        /// <param name="isClassifiedToOutDepartment">if set to <c>true</c> [is classified to out department].</param>
        /// <param name="isClassifiedLeave">if set to <c>true</c> [is classified leave].</param>
        /// <param name="isClassifiedToOther">if set to <c>true</c> [is classified to other].</param>
        /// <param name="destinationId">The destination identifier.</param>
        /// <param name="destinationRemarks">The destination remarks.</param>
        public IndexRescueRoomDestination(DateTime time, bool? isClassifiedToInDepartment, bool? isClassifiedToOutDepartment, bool? isClassifiedLeave, bool? isClassifiedToOther, int? destinationId, string destinationRemarks, int level)
        {
            var db = new EiSDbContext();

            this.Start = new DateTime(time.Year, time.Month, 1);
            this.End = this.Start.AddMonths(1);
            this.Message = string.Format("{0} 去向：", this.Start.ToString("yyyy年M月"));

            var query = db.RescueRoomInfos.Where(c => this.Start <= c.OutDepartmentTime && c.OutDepartmentTime < this.End);
            if (level == 1)
            {
                if (isClassifiedToInDepartment != null)
                    query = query.Where(c => c.Destination.IsClassifiedToInDepartment == isClassifiedToInDepartment);
                if (isClassifiedToOutDepartment != null)
                    query = query.Where(c => c.Destination.IsClassifiedToOutDepartment == isClassifiedToOutDepartment);
                if (isClassifiedLeave != null)
                    query = query.Where(c => c.Destination.IsClassifiedLeave == isClassifiedLeave);
                if (isClassifiedToOther != null)
                    query = query.Where(c => c.Destination.IsClassifiedToOther == isClassifiedToOther);
                this.Message += query.First().Destination.DestinationCategoryNameConcat;
            }
            if (level == 2)
            {
                query = query.Where(c => c.DestinationId == destinationId);
                this.Message += query.First().Destination.DestinationCategoryNameConcat + " - " + query.First().Destination.DestinationName;
            }
            if (level == 3)
            {
                query = query.Where(c => c.DestinationId == destinationId);
                if (string.IsNullOrEmpty(destinationRemarks))
                    query = query.Where(c => c.DestinationRemarks == null || c.DestinationRemarks == "");
                else
                    query = query.Where(c => c.DestinationRemarks == destinationRemarks);
                this.Message += query.First().Destination.DestinationCategoryNameConcat + " - " + query.First().DestinationNameFull;
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