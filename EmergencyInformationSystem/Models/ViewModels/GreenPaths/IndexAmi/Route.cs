using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.GreenPaths.IndexAmi
{
    public class Route
    {
        public Route(int page, int perPage, int count)
        {
            this.Page = page;
            this.PerPage = perPage;

            this.Count = count;
        }





        /// <summary>
        /// 页码。
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页项目数。
        /// </summary>
        public int PerPage { get; set; }





        /// <summary>
        /// 项目总数。
        /// </summary>
        public int Count { get; set; }





        /// <summary>
        /// 最大页码。
        /// </summary>
        public int MaxPage
        {
            get
            {
                return (int)Math.Ceiling((double)this.Count / this.PerPage);
            }
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