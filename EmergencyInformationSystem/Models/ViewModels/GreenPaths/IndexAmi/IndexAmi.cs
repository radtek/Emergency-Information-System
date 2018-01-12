using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.GreenPaths.IndexAmi
{
    /// <summary>
    /// 绿色通道——急性心肌梗死——一览。
    /// </summary>
    public class IndexAmi
    {
        public IndexAmi(Route route)
        {
            var db = new EiSDbContext();

            var query = db.RescueRoomInfos.Where(c => c.GreenPathCategory.CodeName == "Ami").SelectMany(c => c.GreenPathAmis);

            route.Count = query.Count();

            var queryOrdered = query.OrderByDescending(c => c.RescueRoomInfo.InDepartmentTime).ThenBy(c => c.GreenPathAmiId);
            var queryCurrentPage = queryOrdered.Skip((route.Page - 1) * route.PerPage).Take(route.PerPage);

            this.Route = route;

            this.List = queryCurrentPage.ToList().Select(c => new Item(c)).ToList();
        }





        public Route Route { get; set; }





        public List<Item> List { get; set; }
    }
}