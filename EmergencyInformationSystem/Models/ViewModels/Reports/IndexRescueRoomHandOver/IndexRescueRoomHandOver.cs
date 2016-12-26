﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.IndexRescueRoomHandOver
{
    /// <summary>
    /// 抢救室交班表。
    /// </summary>
    public class IndexRescueRoomHandOver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexRescueRoomHandOver"/> class.
        /// </summary>
        public IndexRescueRoomHandOver()
        {
            var db = new EiSDbContext();

            this.Time = DateTime.Now;

            var query = db.RescueRoomInfos.OrderBy(c => c.InDepartmentTime).ThenBy(c => c.RescueRoomInfoId).AsEnumerable().Where(c => !c.IsLeave);

            this.List = query.ToList().Select(c => new Item(c)).ToList();
        }





        [Display(Name = "时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime Time { get; set; }





        public List<Item> List { get; set; }
    }
}