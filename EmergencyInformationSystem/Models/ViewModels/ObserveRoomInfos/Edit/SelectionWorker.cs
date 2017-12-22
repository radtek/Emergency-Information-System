using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Edit
{
    public class SelectionWorker
    {
        public SelectionWorker(Edit targetV)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            this.Beds = new System.Web.Mvc.SelectList(db.Beds.Where(c => c.IsUseForObserveRoom), "BedId", "BedName", targetV.BedId);
            this.InObserveRoomWays = new System.Web.Mvc.SelectList(db.InObserveRoomWays, "InObserveRoomWayId", "InObserveRoomWayName", targetV.InObserveRoomWayId);
            this.Destinations = new System.Web.Mvc.SelectList(db.Destinations.Where(c => c.IsUseForRescueRoom).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", targetV.DestinationId);
            this.DestinationFirsts = new System.Web.Mvc.SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", targetV.DestinationFirstId);
            this.DestinationSeconds = new System.Web.Mvc.SelectList(db.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", targetV.DestinationSecondId);
            this.TransferReasons = new System.Web.Mvc.SelectList(db.TransferReasons, "TransferReasonId", "TransferReasonName", targetV.TransferReasonId);
        }





        public System.Web.Mvc.SelectList Beds { get; set; }

        public System.Web.Mvc.SelectList InObserveRoomWays { get; set; }

        public System.Web.Mvc.SelectList Destinations { get; set; }

        public System.Web.Mvc.SelectList DestinationFirsts { get; set; }

        public System.Web.Mvc.SelectList DestinationSeconds { get; set; }

        public System.Web.Mvc.SelectList TransferReasons { get; set; }
    }
}