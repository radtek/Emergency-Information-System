using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomGeneral
{
    public class ItemInDepartmentWay : ItemBase
    {
        public ItemInDepartmentWay(DateTime start, DateTime end, int level, int countAll, IEnumerable<Models.Domains.Entities.RescueRoomInfo> group) : base(start, end, level, countAll, group)
        {
            this.InRescueRoomWayId = countAll > 0 ? group.First().InRescueRoomWayId : 0;
            this.InRescueRoomWayIsHasAdditionalInfo = countAll > 0 ? group.First().InRescueRoomWay.IsHasAdditionalInfo : false;
            this.InRescueRoomWayRemarks = countAll > 0 ? group.First().InRescueRoomWayRemarks : string.Empty;

            switch (level)
            {
                case 1:
                    this.Name = group.First().InRescueRoomWay.InRescueRoomWayName;

                    this.Route.InRescueRoomWayId = this.InRescueRoomWayId;

                    break;
                case 2:
                    this.Name = group.First().InRescueRoomWayNameFull;

                    this.Route.InRescueRoomWayId = this.InRescueRoomWayId;
                    this.Route.InRescueRoomWayIsHasAdditionalInfo = this.InRescueRoomWayIsHasAdditionalInfo;
                    this.Route.InRescueRoomWayRemarks = this.InRescueRoomWayRemarks;

                    break;
            }
            if (string.IsNullOrEmpty(this.Name))
                this.Name = "--";

            if (level == 0)
            {
                var listGroup = group.GroupBy(c => c.InRescueRoomWayId);

                this.List = listGroup.Select(c => new ItemInDepartmentWay(this.Start, this.End, this.Level + 1, countAll, c)).ToList().AsEnumerable<ItemBase>().ToList();
            }
            else if (level == 1)
            {
                if (this.InRescueRoomWayIsHasAdditionalInfo)
                {
                    var listGroup = group.GroupBy(c => c.InRescueRoomWayRemarks);

                    this.List = listGroup.Select(c => new ItemInDepartmentWay(this.Start, this.End, this.Level + 1, countAll, c)).ToList().AsEnumerable<ItemBase>().ToList();
                }
            }
        }





        public int InRescueRoomWayId { get; set; }

        public bool InRescueRoomWayIsHasAdditionalInfo { get; set; }

        public string InRescueRoomWayRemarks { get; set; }
    }
}