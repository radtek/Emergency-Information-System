using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexHandOver
{
    /// <summary>
    /// 交班表。
    /// </summary>
    public class IndexHandOver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexHandOver"/> class.
        /// </summary>
        /// <param name="db">数据源。</param>
        public IndexHandOver(EiSDbContext db)
        {
            this.Time = DateTime.Now;

            var query = db.RescueRoomInfos.AsEnumerable().Where(c => !c.IsLeave);
            this.List = query.ToList().Select(c => new Item(c)).ToList();
        }





        [Display(Name = "时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime Time { get; set; }





        public List<Item> List { get; set; }
    }
}