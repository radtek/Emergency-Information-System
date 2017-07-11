using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyInformationReportSystem.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult IndexSubscription()
        {
            return View();
        }
    }
}