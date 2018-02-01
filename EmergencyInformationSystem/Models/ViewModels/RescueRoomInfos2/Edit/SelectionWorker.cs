using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos2.Edit
{
    public class SelectionWorker
    {
        public SelectionWorker(Edit targetV)
        {
            var db3 = new Domains3.Entities.EiSDbContext();

            this.Beds = new System.Web.Mvc.SelectList(db3.Beds.Where(c => c.IsUseForRescueRoom).OrderBy(c => c.Priority), "BedId", "BedName", targetV.BedId);
            this.InRoomWays = new System.Web.Mvc.SelectList(db3.InRoomWays.Where(c => c.IsUseForRescueRoom).OrderBy(c => c.Priority), "InRoomWayId", "InRoomWayName", targetV.InRoomWayId);
            this.GreenPathCategories = new System.Web.Mvc.SelectList(db3.GreenPathCategories.OrderBy(c => c.Priority), "GreenPathCategoryId", "GreenPathCategoryName", targetV.GreenPathCategoryId);
            this.RescueResults = new System.Web.Mvc.SelectList(db3.RescueResults.OrderBy(c => c.Priority), "RescueResultId", "RescueResultName", targetV.RescueResultId);
            this.Destinations = new System.Web.Mvc.SelectList(db3.Destinations.Where(c => c.IsUseForRescueRoom).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", targetV.DestinationId);
            this.CriticalLevels = new System.Web.Mvc.SelectList(db3.CriticalLevels, "CriticalLevelId", "CriticalLevelName", targetV.CriticalLevelId);
            this.DestinationFirsts = new System.Web.Mvc.SelectList(db3.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", targetV.DestinationFirstId);
            this.DestinationSeconds = new System.Web.Mvc.SelectList(db3.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", targetV.DestinationSecondId);
            this.TransferReasons = new System.Web.Mvc.SelectList(db3.TransferReasons, "TransferReasonId", "TransferReasonName", targetV.TransferReasonId);
        }





        public System.Web.Mvc.SelectList Beds { get; set; }

        public System.Web.Mvc.SelectList InRoomWays { get; set; }

        public System.Web.Mvc.SelectList GreenPathCategories { get; set; }

        public System.Web.Mvc.SelectList RescueResults { get; set; }

        public System.Web.Mvc.SelectList Destinations { get; set; }

        public System.Web.Mvc.SelectList CriticalLevels { get; set; }

        public System.Web.Mvc.SelectList DestinationFirsts { get; set; }

        public System.Web.Mvc.SelectList DestinationSeconds { get; set; }

        public System.Web.Mvc.SelectList TransferReasons { get; set; }
    }
}