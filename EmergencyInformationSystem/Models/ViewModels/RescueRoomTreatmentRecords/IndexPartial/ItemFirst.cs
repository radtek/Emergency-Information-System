using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomTreatmentRecords.IndexPartial
{
    public class ItemFirst
    {
        public ItemFirst(IGrouping<Guid, RescueRoomTreatmentRecord> group)
        {
            this.Origin_CFID = group.Key;

            this.List = group.OrderBy(c => c.PrescriptionTime).ThenBy(c => c.ProductCode).Select(c => new ItemSecond(c)).ToList();
        }





        public Guid Origin_CFID { get; set; }





        public List<ItemSecond> List { get; set; }
    }
}