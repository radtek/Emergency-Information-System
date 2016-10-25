﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexDestination
{
    /// <summary>
    /// Class IndexDestination.
    /// </summary>
    public class IndexDestination
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexDestination"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="isClassifiedToInDepartment">if set to <c>true</c> [is classified to in department].</param>
        /// <param name="isClassifiedToOutDepartment">if set to <c>true</c> [is classified to out department].</param>
        /// <param name="isClassifiedLeave">if set to <c>true</c> [is classified leave].</param>
        /// <param name="isClassifiedToOther">if set to <c>true</c> [is classified to other].</param>
        /// <param name="destinationId">The destination identifier.</param>
        /// <param name="destinationRemarks">The destination remarks.</param>
        /// <param name="db">The database.</param>
        public IndexDestination(DateTime time, bool? isClassifiedToInDepartment, bool? isClassifiedToOutDepartment, bool? isClassifiedLeave, bool? isClassifiedToOther, int? destinationId, string destinationRemarks, EiSDbContext db)
        {
            this.Start = new DateTime(time.Year, time.Month, 1);
            this.End = this.Start.AddMonths(1);

            var query = db.RescueRoomInfos.Where(c => this.Start <= c.OutDepartmentTime && c.OutDepartmentTime < this.End);
            if (isClassifiedToInDepartment != null)
                query = query.Where(c => c.Destination.IsClassifiedToInDepartment == isClassifiedToInDepartment);
            if (isClassifiedToOutDepartment != null)
                query = query.Where(c => c.Destination.IsClassifiedToOutDepartment == isClassifiedToOutDepartment);
            if (isClassifiedLeave != null)
                query = query.Where(c => c.Destination.IsClassifiedLeave == isClassifiedLeave);
            if (isClassifiedToOther != null)
                query = query.Where(c => c.Destination.IsClassifiedToOther == isClassifiedToOther);
            if (destinationId != null)
                query = query.Where(c => c.DestinationId == destinationId);
            if (!string.IsNullOrEmpty(destinationRemarks))
                query = query.Where(c => c.DestinationRemarks == destinationRemarks);

            this.List = query.ToList().Select(c => new Item(c)).ToList();
        }





        public DateTime Start { get; set; }

        public DateTime End { get; set; }





        public List<Item> List { get; set; }
    }
}