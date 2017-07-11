using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyInformationSystem.Controllers
{
    public class ApiController : Controller
    {
        public PartialViewResult IndexSubscription()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "POST");
            Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");

            var targetV = new Models.ViewModels.Api.IndexSubscription.IndexSubscription();

            return PartialView(targetV);
        }
    }
}