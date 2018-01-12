using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Edit
{
    public class SelectionWorker
    {
        public SelectionWorker(Edit targetV)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            this.Beds = new System.Web.Mvc.SelectList(db.Beds.Where(c => c.IsUseForRescueRoom).OrderBy(c => c.Priority), "BedId", "BedName", targetV.BedId);
            this.InRescueRoomWays = new System.Web.Mvc.SelectList(db.InRescueRoomWays.OrderBy(c => c.Priority), "InRescueRoomWayId", "InRescueRoomWayName", targetV.InRescueRoomWayId);
            this.GreenPathCategories = new System.Web.Mvc.SelectList(db.GreenPathCategories.OrderBy(c => c.Priority), "GreenPathCategoryId", "GreenPathCategoryName", targetV.GreenPathCategoryId);
            this.RescueResults = new System.Web.Mvc.SelectList(db.RescueResults.OrderBy(c => c.Priority), "RescueResultId", "RescueResultName", targetV.RescueResultId);
            this.Destinations = new System.Web.Mvc.SelectList(db.Destinations.Where(c => c.IsUseForRescueRoom).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", targetV.DestinationId);
            this.CriticalLevels = new System.Web.Mvc.SelectList(db.CriticalLevels, "CriticalLevelId", "CriticalLevelName", targetV.CriticalLevelId);
            this.DestinationFirsts = new System.Web.Mvc.SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", targetV.DestinationFirstId);
            this.DestinationSeconds = new System.Web.Mvc.SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", targetV.DestinationSecondId);
            this.TransferReasons = new System.Web.Mvc.SelectList(db.TransferReasons, "TransferReasonId", "TransferReasonName", targetV.TransferReasonId);
        }





        public System.Web.Mvc.SelectList Beds { get; set; }

        public System.Web.Mvc.SelectList InRescueRoomWays { get; set; }

        public System.Web.Mvc.SelectList GreenPathCategories { get; set; }

        public System.Web.Mvc.SelectList RescueResults { get; set; }

        public System.Web.Mvc.SelectList Destinations { get; set; }

        public System.Web.Mvc.SelectList CriticalLevels { get; set; }

        public System.Web.Mvc.SelectList DestinationFirsts { get; set; }

        public System.Web.Mvc.SelectList DestinationSeconds { get; set; }

        public System.Web.Mvc.SelectList TransferReasons { get; set; }
    }
}