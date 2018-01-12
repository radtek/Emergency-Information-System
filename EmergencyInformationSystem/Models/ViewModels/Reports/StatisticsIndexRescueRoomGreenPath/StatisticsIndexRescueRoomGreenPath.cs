using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsIndexRescueRoomGreenPath
{
    /// <summary>
    /// Class IndexGreenPath.
    /// </summary>
    public class StatisticsIndexRescueRoomGreenPath
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsIndexRescueRoomGreenPath"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="isGreenPath">if set to <c>true</c> [is green path].</param>
        /// <param name="greenPathCategoryId">The green path category identifier.</param>
        /// <param name="greenPathCategoryRemarks">The green path category remarks.</param>
        public StatisticsIndexRescueRoomGreenPath(DateTime time, bool? isGreenPath, Guid? greenPathCategoryId, string greenPathCategoryRemarks, int level)
        {
            var db = new EiSDbContext();

            this.Start = new DateTime(time.Year, time.Month, 1);
            this.End = this.Start.AddMonths(1);
            this.Message = string.Format("{0} 绿色通道：", this.Start.ToString("yyyy年M月"));

            var list = db.RescueRoomInfos.Where(c => this.Start <= c.OutDepartmentTime && c.OutDepartmentTime < this.End).OrderBy(c => c.InDepartmentTime).ThenBy(c => c.RescueRoomInfoId).ToList();
            if (level == 1)
            {
                list = list.Where(c => c.IsGreenPath == isGreenPath).ToList();
                this.Message += list.First().IsGreenPathName;
            }
            if (level == 2)
            {
                list = list.Where(c => c.GreenPathCategoryId == greenPathCategoryId).ToList();
                this.Message += list.First().GreenPathCategory.GreenPathCategoryName;
            }
            if (level == 3)
            {
                list = list.Where(c => c.GreenPathCategoryId == greenPathCategoryId).ToList();
                if (string.IsNullOrEmpty(greenPathCategoryRemarks))
                    list = list.Where(c => c.GreenPathCategoryRemarks == null || c.GreenPathCategoryRemarks == "").ToList();
                else
                    list = list.Where(c => c.GreenPathCategoryRemarks == greenPathCategoryRemarks).ToList();
                this.Message += list.First().GreenPathCategoryNameFull;
            }

            this.List = list.Select(c => new Item(c)).ToList();
        }





        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Message { get; set; }





        public List<Item> List { get; set; }
    }
}