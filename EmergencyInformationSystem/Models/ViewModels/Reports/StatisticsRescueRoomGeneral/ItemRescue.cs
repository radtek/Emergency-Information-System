using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomGeneral
{
    public class ItemRescue : ItemBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemRescue"/> class.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="level">当前等级。0级时，包含所有对象。</param>
        /// <param name="countAll">总数。</param>
        /// <param name="group">进入该级别的对象组。</param>
        public ItemRescue(DateTime start, DateTime end, int level, int countAll, IEnumerable<Models.Domains.Entities.RescueRoomInfo> group) : base(start, end, level, countAll, group)
        {
            this.IsRescue = countAll > 0 ? group.First().IsRescue : false;
            this.RescueResultId = countAll > 0 ? group.First().RescueResultId : 0;

            switch (level)
            {
                case 1:
                    this.Name = group.First().IsRescueName;

                    this.Route.IsRescue = this.IsRescue;

                    break;
                case 2:
                    this.Name = group.First().RescueResultNameFull;

                    this.Route.IsRescue = this.IsRescue;
                    this.Route.RescueResultId = this.RescueResultId;

                    break;
            }
            if (string.IsNullOrEmpty(this.Name))
                this.Name = "--";

            if (level == 0)
            {
                var listGroup = group.GroupBy(c => c.IsRescue);

                this.List = listGroup.Select(c => new ItemRescue(this.Start, this.End, this.Level + 1, countAll, c)).ToList().AsEnumerable<ItemBase>().ToList();
            }
            else if (level == 1)
            {
                if (this.IsRescue)
                {
                    var listGroup = group.GroupBy(c => c.RescueResultId);

                    this.List = listGroup.Select(c => new ItemRescue(this.Start, this.End, this.Level + 1, countAll, c)).ToList().AsEnumerable<ItemBase>().ToList();
                }
            }
        }





        public bool IsRescue { get; set; }

        public int RescueResultId { get; set; }
    }
}