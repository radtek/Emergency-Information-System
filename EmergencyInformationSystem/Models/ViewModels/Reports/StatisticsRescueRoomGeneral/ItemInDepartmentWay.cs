using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomGeneral
{
    public class ItemInDepartmentWay
    {
        public ItemInDepartmentWay(DateTime start, DateTime end, int level, int countAll, IEnumerable<Models.Domains.Entities.RescueRoomInfo> group)
        {
            this.Start = start;
            this.End = end;
            this.Level = level;
            this.Count = group.Count();
            this.Rate = (decimal)this.Count / countAll;

            this.InRescueRoomWayId = group.First().InRescueRoomWayId;
            this.InRescueRoomWayIsHasAdditionalInfo = group.First().InRescueRoomWay.IsHasAdditionalInfo;
            this.InRescueRoomWayRemarks = group.First().InRescueRoomWayRemarks;

            switch (level)
            {
                case 1:
                    this.Name = group.First().InRescueRoomWay.InRescueRoomWayName;
                    break;
                case 2:
                    this.Name = group.First().InRescueRoomWayNameFull;
                    break;
            }
            if (string.IsNullOrEmpty(this.Name))
                this.Name = "--";

            if (level == 0)
            {
                var listGroup = group.GroupBy(c => c.InRescueRoomWayId);

                this.List = listGroup.Select(c => new ItemInDepartmentWay(this.Start, this.End, this.Level + 1, countAll, c)).ToList();
            }
            else if (level == 1)
            {
                if (this.InRescueRoomWayIsHasAdditionalInfo)
                {
                    var listGroup = group.GroupBy(c => c.InRescueRoomWayRemarks);

                    this.List = listGroup.Select(c => new ItemInDepartmentWay(this.Start, this.End, this.Level + 1, countAll, c)).ToList();
                }
            }
        }





        [Display(Name = "入室方式")]
        public string Name { get; set; }

        [Display(Name = "例数")]
        public int Count { get; set; }

        [Display(Name = "百分比")]
        [DisplayFormat(DataFormatString = "{0:p}")]
        public decimal Rate { get; set; }





        public int Level { get; set; }





        public DateTime Start { get; set; }

        public DateTime End { get; set; }





        public int InRescueRoomWayId { get; set; }

        public bool InRescueRoomWayIsHasAdditionalInfo { get; set; }

        public string InRescueRoomWayRemarks { get; set; }





        public List<ItemInDepartmentWay> List { get; set; }
    }
}