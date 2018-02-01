using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos2.Edit
{
    public class SelectionWorker
    {
        public SelectionWorker(Edit targetV)
        {
            var db3 = new Domains3.Entities.EiSDbContext();

            this.Beds = new System.Web.Mvc.SelectList(db3.Beds.Where(c => c.IsUseForObserveRoom).OrderBy(c => c.Priority), "BedId", "BedName", targetV.BedId);
            this.InRoomWays = new System.Web.Mvc.SelectList(db3.InRoomWays.Where(c => c.IsUseForObserveRoom).OrderBy(c => c.Priority), "InRoomWayId", "InRoomWayName", targetV.InRoomWayId);
            this.Destinations = new System.Web.Mvc.SelectList(db3.Destinations.Where(c => c.IsUseForObserveRoom).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", targetV.DestinationId);
            this.DestinationFirsts = new System.Web.Mvc.SelectList(db3.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", targetV.DestinationFirstId);
            this.DestinationSeconds = new System.Web.Mvc.SelectList(db3.Destinations.Where(c => c.IsUseForSubscription).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", targetV.DestinationSecondId);
            this.TransferReasons = new System.Web.Mvc.SelectList(db3.TransferReasons, "TransferReasonId", "TransferReasonName", targetV.TransferReasonId);
        }





        public System.Web.Mvc.SelectList Beds { get; set; }

        public System.Web.Mvc.SelectList InRoomWays { get; set; }

        public System.Web.Mvc.SelectList Destinations { get; set; }

        public System.Web.Mvc.SelectList DestinationFirsts { get; set; }

        public System.Web.Mvc.SelectList DestinationSeconds { get; set; }

        public System.Web.Mvc.SelectList TransferReasons { get; set; }
    }
}