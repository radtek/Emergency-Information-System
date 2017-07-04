using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexSubscription
{
    public class IndexSubscription
    {
        public IndexSubscription()
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            this.Time = DateTime.Now;

            var query1 = db.RescueRoomInfos.Where(c => c.OutDepartmentTime == null);
            var list1 = query1.ToList();
            var listA = list1.Select(c => new Item(c)).ToList();

            var query2 = db.ObserveRoomInfos.Where(c => c.OutDepartmentTime == null);
            var list2 = query2.ToList();
            var listB = list2.Select(c => new Item(c)).ToList();

            this.List = listA.Union(listB).ToList();
        }





        [Display(Name = "时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime Time { get; set; }





        public List<Item> List { get; set; }
    }
}