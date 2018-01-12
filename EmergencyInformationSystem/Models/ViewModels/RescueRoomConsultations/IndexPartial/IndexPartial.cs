using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomConsultations.IndexPartial
{
    public class IndexPartial
    {
        public IndexPartial(Guid rescueRoomInfoId)
        {
            var db = new Domains.Entities.EiSDbContext();

            var query = db.RescueRoomConsultations.AsQueryable();
            query = query.Where(c => c.RescueRoomInfoId == rescueRoomInfoId);

            var queryOrdered = query.OrderBy(c => c.RequestTime);

            this.List = queryOrdered.ToList().Select(c => new Item(c)).ToList();
        }





        public List<Item> List { get; set; }
    }
}