using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomGeneral
{
    public class ItemRescue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemRescue"/> class.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="level">当前等级。0级时，包含所有对象。</param>
        /// <param name="countAll">总数。</param>
        /// <param name="group">进入该级别的对象组。</param>
        public ItemRescue(DateTime start, DateTime end, int level, int countAll, IEnumerable<Models.Domains.Entities.RescueRoomInfo> group)
        {
            this.Start = start;
            this.End = end;
            this.Level = level;
            this.Count = group.Count();
            this.Rate = (decimal)this.Count / countAll;

            this.IsRescue = group.First().IsRescue;
            this.RescueResultId = group.First().RescueResultId;

            switch (level)
            {
                case 1:
                    this.Name = group.First().IsRescueName;
                    break;
                case 2:
                    this.Name = group.First().RescueResultNameFull;
                    break;
            }
            if (string.IsNullOrEmpty(this.Name))
                this.Name = "--";

            if (level == 0)
            {
                var listGroup = group.GroupBy(c => c.IsRescue);

                this.List = listGroup.Select(c => new ItemRescue(this.Start, this.End, this.Level + 1, countAll, c)).ToList();
            }
            else if (level == 1)
            {
                if (this.IsRescue)
                {
                    var listGroup = group.GroupBy(c => c.RescueResultId);

                    this.List = listGroup.Select(c => new ItemRescue(this.Start, this.End, this.Level + 1, countAll, c)).ToList();
                }
            }
        }





        [Display(Name = "抢救")]
        public string Name { get; set; }

        [Display(Name = "例数")]
        public int Count { get; set; }

        [Display(Name = "百分比")]
        [DisplayFormat(DataFormatString = "{0:p}")]
        public decimal Rate { get; set; }





        public int Level { get; set; }





        public DateTime Start { get; set; }

        public DateTime End { get; set; }





        public bool IsRescue { get; set; }

        public int RescueResultId { get; set; }





        public List<ItemRescue> List { get; set; }
    }
}