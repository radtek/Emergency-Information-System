using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomGeneral
{
    public class Route
    {
        public Route()
        {

        }





        public DateTime Start { get; set; }

        public DateTime End { get; set; }





        public bool? IsRescue { get; set; }

        public int? RescueResultId { get; set; }

        public int? InRescueRoomWayId { get; set; }

        public bool? InRescueRoomWayIsHasAdditionalInfo { get; set; }

        public string InRescueRoomWayRemarks { get; set; }

        public int? DestinationId { get; set; }

        public bool? DestinationIsHasAdditionalInfo { get; set; }

        public string DestinationRemarks { get; set; }

        public bool? DestinationIsTransfer { get; set; }

        public string TransferTarget { get; set; }

        public bool? DestinationIsProfessional { get; set; }

        public string ProfessionalTarget { get; set; }
    }
}