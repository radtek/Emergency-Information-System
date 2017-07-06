using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexObserveRoomHandOver
{
    /// <summary>
    /// 留观室交班表。
    /// </summary>
    public class IndexObserveRoomHandOver
    {
        public IndexObserveRoomHandOver()
        {
            var db = new EiSDbContext();

            this.Time = DateTime.Now;

            var query = db.ObserveRoomInfos.AsQueryable();
            query = query.Where(c => c.OutDepartmentTime == null);
            var queryOrdered = query.OrderBy(c => c.InDepartmentTime).ThenBy(c => c.ObserveRoomInfoId);
            var list = queryOrdered.ToList();

            this.List = list.Select(c => new Item(c)).ToList();
        }





        [Display(Name = "时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime Time { get; set; }





        public List<Item> List { get; set; }
    }
}