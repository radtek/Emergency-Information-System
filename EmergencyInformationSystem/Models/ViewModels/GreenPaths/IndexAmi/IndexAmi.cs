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
        public IndexAmi(int page, int perPage)
        {
            var db = new EiSDbContext();

            var query = db.RescueRoomInfos.Where(c => c.GreenPathCategory.CodeName == "Ami").SelectMany(c => c.GreenPathAmis);

            var queryCurrentPage = query.OrderByDescending(c => c.RescueRoomInfo.InDepartmentTime).ThenBy(c => c.GreenPathAmiId).Skip((page - 1) * perPage).Take(perPage);

            this.Route = new Route(page, perPage, query.Count());

            this.List = queryCurrentPage.ToList().Select(c => new Item(c)).ToList();
        }





        public Route Route { get; set; }





        public List<Item> List { get; set; }
    }
}