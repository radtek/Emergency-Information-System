using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.GreenPaths.IndexAmi
{
    public class Route : RouteBase
    {
        public Route(int page, int perPage, int count) : base(page, perPage, count)
        {
        }

        public Route() : base(0, 0, 0)
        {

        }





        /// <summary>
        /// 获取指定导航。
        /// </summary>
        /// <param name="page">页码。</param>
        public Route GetRoute(int page)
        {
            return new Route(page, this.PerPage, this.Count);
        }
    }
}