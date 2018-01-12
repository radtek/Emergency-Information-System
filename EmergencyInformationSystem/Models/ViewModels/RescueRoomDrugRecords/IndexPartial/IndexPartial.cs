using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomDrugRecords.IndexPartial
{
    public class IndexPartial
    {
        public IndexPartial(Guid rescueRoomInfoId)
        {
            var db = new Domains.Entities.EiSDbContext();

            var query = db.RescueRoomDrugRecords.AsQueryable();
            query = query.Where(c => c.RescueRoomInfoId == rescueRoomInfoId);

            var group = query.GroupBy(c => c.CFID);

            this.List = group.ToList().Select(c => new ItemFirst(c)).ToList();
        }





        public List<ItemFirst> List { get; set; }
    }
}