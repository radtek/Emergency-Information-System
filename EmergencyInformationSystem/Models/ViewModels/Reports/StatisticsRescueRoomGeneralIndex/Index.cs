using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomGeneralIndex
{
    public class Index
    {
        public Index(DateTime start, DateTime end, bool? isRescue, int? rescueResultId, int? inRescueRoomWayId, bool? inRescueRoomWayIsHasAdditionalInfo, string inRescueRoomWayRemarks, int? destinationId, bool? destinationIsHasAdditionalInfo, string destinationRemarks, bool? destinationIsTransfer, string transferTarget, bool? destinationIsProfessional, string professionalTarget)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            var query = db.RescueRoomInfos.Where(c => start <= c.OutDepartmentTime && c.OutDepartmentTime < end);
            //Description = string.Format("{0} 至 {1}", start.ToShortDateString(), end.ToShortDateString());

            if (isRescue.HasValue)
            {
                query = query.Where(c => c.IsRescue == isRescue);
                //Description += string.Format("\n抢救：{0}", isRescue.Value ? "是" : "否");

                if (rescueResultId.HasValue)
                {
                    query = query.Where(c => c.RescueResultId == rescueResultId);
                }
            }
            else if (inRescueRoomWayId.HasValue)
            {
                query = query.Where(c => c.InRescueRoomWayId == inRescueRoomWayId);

                if (inRescueRoomWayIsHasAdditionalInfo == true)
                    query = query.Where(c => c.InRescueRoomWayRemarks == inRescueRoomWayRemarks);
            }
            else if (destinationId.HasValue)
            {
                query = query.Where(c => c.DestinationId == destinationId);

                if (destinationIsHasAdditionalInfo == true)
                    query = query.Where(c => c.DestinationRemarks == destinationRemarks);

                if (destinationIsTransfer == true)
                    query = query.Where(c => c.TransferTarget == transferTarget);

                if (destinationIsProfessional == true)
                    query = query.Where(c => c.ProfessionalTarget == professionalTarget);
            }

            var queryOrdered = query.OrderBy(c => c.OutDepartmentTime);

            var list = queryOrdered.ToList();

            var queryV = list.Select(c => new Item(c));

            this.List = queryV.ToList();
        }





        public string Description { get; set; }

        public List<Item> List { get; set; }
    }
}