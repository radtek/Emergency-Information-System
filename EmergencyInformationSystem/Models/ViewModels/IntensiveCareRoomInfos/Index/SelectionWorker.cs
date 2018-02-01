using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.IntensiveCareRoomInfos.Index
{
    public class SelectionWorker
    {
        public SelectionWorker(Route route)
        {
            var db2 = new Domains2.Entities.EiSDbContext();

            this.GreenPathCategories = new System.Web.Mvc.SelectList(db2.GreenPathCategories.OrderBy(c => c.Priority), "GreenPathCategoryId", "GreenPathCategoryName", route.GreenPathCategoryId);
            this.InRoomWays = new System.Web.Mvc.SelectList(db2.InRoomWays.Where(c => (c.InRoomWayCode & Domains2.Entities.InRoomWayCode.IntensiveCareRoom) == Domains2.Entities.InRoomWayCode.IntensiveCareRoom).OrderBy(c => c.Priority), "InRoomWayId", "InRoomWayName", route.InRoomWayId);
            this.Destinations = new System.Web.Mvc.SelectList(db2.Destinations.Where(c => (c.DestinationCode & Domains2.Entities.DestinationCode.UseForIntensiveCareRoom) == Domains2.Entities.DestinationCode.UseForIntensiveCareRoom).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", route.DestinationId);
            this.IsRescues = new System.Web.Mvc.SelectList(
                new List<System.Web.Mvc.SelectListItem>
                {
                    new System.Web.Mvc.SelectListItem {Text="是",Value="True" },
                    new System.Web.Mvc.SelectListItem {Text="否",Value="False" }
                }, "Value", "Text");
            this.IsLeaves = new System.Web.Mvc.SelectList(
                new List<System.Web.Mvc.SelectListItem>
                {
                    new System.Web.Mvc.SelectListItem {Text="是",Value="true" },
                    new System.Web.Mvc.SelectListItem {Text="否",Value="false" }
                }, "Value", "Text");
        }





        public System.Web.Mvc.SelectList GreenPathCategories { get; set; }

        public System.Web.Mvc.SelectList InRoomWays { get; set; }

        public System.Web.Mvc.SelectList Destinations { get; set; }

        public System.Web.Mvc.SelectList IsRescues { get; set; }

        public System.Web.Mvc.SelectList IsLeaves { get; set; }
    }
}