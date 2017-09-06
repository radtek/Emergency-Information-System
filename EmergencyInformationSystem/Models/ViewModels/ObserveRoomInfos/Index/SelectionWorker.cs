using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Index
{
    public class SelectionWorker
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="route">导航对象。</param>
        public SelectionWorker(Route route)
        {
            var db = new Models.Domains.Entities.EiSDbContext();

            this.IsLeaves = new System.Web.Mvc.SelectList(
                new List<System.Web.Mvc.SelectListItem>
                {
                    new System.Web.Mvc.SelectListItem {Text="是",Value="true" },
                    new System.Web.Mvc.SelectListItem {Text="否",Value="false" }
                }, "Value", "Text");
        }





        public System.Web.Mvc.SelectList IsLeaves { get; set; }
    }
}