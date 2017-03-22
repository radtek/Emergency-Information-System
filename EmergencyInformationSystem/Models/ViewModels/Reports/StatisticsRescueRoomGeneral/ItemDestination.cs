using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomGeneral
{
    public class ItemDestination : ItemBase
    {
        public ItemDestination(DateTime start, DateTime end, int level, int countAll, IEnumerable<Models.Domains.Entities.RescueRoomInfo> group) : base(start, end, level, countAll, group)
        {
            this.DestinationId = countAll > 0 ? group.First().DestinationId : 0;
            this.DestinationIsHasAdditionalInfo = countAll > 0 ? group.First().Destination.IsHasAdditionalInfo : false;
            this.DestinationRemarks = countAll > 0 ? group.First().ReceiveAgeName : string.Empty;
            this.DestinationIsTransfer = countAll > 0 ? group.First().Destination.IsTransfer : false;
            this.TransferTarget = countAll > 0 ? group.First().TransferTarget : string.Empty;
            this.DestinationIsProfessional = countAll > 0 ? group.First().Destination.IsProfessional : false;
            this.ProfessionalTarget = countAll > 0 ? group.First().ProfessionalTarget : string.Empty;

            switch (level)
            {
                case 1:
                    this.Name = group.First().Destination.DestinationName;

                    this.Route.DestinationId = this.DestinationId;

                    break;
                case 2:
                    this.Name = group.First().DestinationNameFull;

                    this.Route.DestinationId = this.DestinationId;
                    this.Route.DestinationIsHasAdditionalInfo = this.DestinationIsHasAdditionalInfo;
                    this.Route.DestinationRemarks = this.DestinationRemarks;
                    this.Route.DestinationIsTransfer = this.DestinationIsTransfer;
                    this.Route.TransferTarget = this.TransferTarget;
                    this.Route.DestinationIsProfessional = this.DestinationIsProfessional;
                    this.Route.ProfessionalTarget = this.ProfessionalTarget;

                    break;
            }
            if (string.IsNullOrEmpty(this.Name))
                this.Name = "--";

            if (level == 0)
            {
                var listGroup = group.GroupBy(c => c.DestinationId);

                this.List = listGroup.Select(c => new ItemDestination(this.Start, this.End, this.Level + 1, countAll, c)).ToList().AsEnumerable<ItemBase>().ToList();
            }
            else if (level == 1)
            {
                IEnumerable<IGrouping<string, Models.Domains.Entities.RescueRoomInfo>> listGroup;

                if (this.DestinationIsHasAdditionalInfo)
                {
                    listGroup = group.GroupBy(c => c.DestinationRemarks);
                }
                else if (this.DestinationIsTransfer)
                {
                    listGroup = group.GroupBy(c => c.TransferTarget);
                }
                else if (this.DestinationIsProfessional)
                {
                    listGroup = group.GroupBy(c => c.ProfessionalTarget);
                }
                else //此路径无效
                {
                    listGroup = new List<IGrouping<string, Models.Domains.Entities.RescueRoomInfo>>();
                }

                this.List = listGroup.Select(c => new ItemDestination(this.Start, this.End, this.Level + 1, countAll, c)).ToList().AsEnumerable<ItemBase>().ToList();
            }
        }





        public int DestinationId { get; set; }

        public bool DestinationIsHasAdditionalInfo { get; set; }

        public string DestinationRemarks { get; set; }

        public bool DestinationIsTransfer { get; set; }

        public string TransferTarget { get; set; }

        public bool DestinationIsProfessional { get; set; }

        public string ProfessionalTarget { get; set; }
    }
}