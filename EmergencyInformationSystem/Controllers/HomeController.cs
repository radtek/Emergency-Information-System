using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 主界面控制器。
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// 主界面。
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }
    }
}