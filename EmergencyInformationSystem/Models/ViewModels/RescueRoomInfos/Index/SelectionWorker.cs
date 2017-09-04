using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Index
{
    public class SelectionWorker
    {
        public SelectionWorker(Route route)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            this.GreenPathCategories = new System.Web.Mvc.SelectList(db.GreenPathCategories, "GreenPathCategoryId", "GreenPathCategoryName", route.GreenPathCategoryId);
            this.InRescueRoomWays = new System.Web.Mvc.SelectList(db.InRescueRoomWays, "InRescueRoomWayId", "InRescueRoomWayName", route.InRescueRoomWayId);
            this.Destinations = new System.Web.Mvc.SelectList(db.Destinations, "DestinationId", "DestinationName", route.DestinationId);
            this.IsRescues = new System.Web.Mvc.SelectList(
                new List<System.Web.Mvc.SelectListItem>
                {
                    new System.Web.Mvc.SelectListItem {Text="是",Value="True" },
                    new System.Web.Mvc.SelectListItem {Text="否",Value="False" }
                }, "Value", "Text");
            this.IsLeaves= new System.Web.Mvc.SelectList(
                new List<System.Web.Mvc.SelectListItem>
                {
                    new System.Web.Mvc.SelectListItem {Text="是",Value="true" },
                    new System.Web.Mvc.SelectListItem {Text="否",Value="false" }
                }, "Value", "Text");
        }





        public System.Web.Mvc.SelectList GreenPathCategories { get; set; }

        public System.Web.Mvc.SelectList InRescueRoomWays { get; set; }

        public System.Web.Mvc.SelectList Destinations { get; set; }

        public System.Web.Mvc.SelectList IsRescues { get; set; }

        public System.Web.Mvc.SelectList IsLeaves { get; set; }
    }
}