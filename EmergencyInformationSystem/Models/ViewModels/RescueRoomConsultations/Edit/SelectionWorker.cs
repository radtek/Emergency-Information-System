using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomConsultations.Edit
{
    public class SelectionWorker
    {
        public SelectionWorker(Edit targetV)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            this.ConsultationDepartments = new System.Web.Mvc.SelectList(db.Destinations.Where(c => c.IsUseForConsultation).OrderBy(c => c.Priority2), "DestinationId", "DestinationName", targetV.ConsultationDepartmentId);
        }





        public System.Web.Mvc.SelectList ConsultationDepartments { get; set; }
    }
}