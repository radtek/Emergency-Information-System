using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 服务-数据查询。
    /// </summary>
    public class ServicesQueryController : Controller
    {
        /// <summary>
        /// Gets the in rescue room way.
        /// </summary>
        /// <param name="id">进入抢救室方式ID。</param>
        public JsonResult GetInRescueRoomWay(int id)
        {
            var db = new EiSDbContext();

            var target = db.InRescueRoomWays.Find(id);

            return Json(target);
        }

        /// <summary>
        /// Gets the in rescue room way.
        /// </summary>
        /// <param name="id">进入留观室方式ID。</param>
        public JsonResult GetInObserveRoomWay(int id)
        {
            var db = new EiSDbContext();

            var target = db.InObserveRoomWays.Find(id);

            return Json(target);
        }

        /// <summary>
        /// Gets the in rescue room way.
        /// </summary>
        /// <param name="id">绿色通道类型ID。</param>
        public JsonResult GetGreenPathCategory(int id)
        {
            var db = new EiSDbContext();

            var target = db.GreenPathCategories.Find(id);

            return Json(target);
        }

        /// <summary>
        /// Gets the in rescue room way.
        /// </summary>
        /// <param name="id">去向ID。</param>
        public JsonResult GetDestination(int id)
        {
            var db = new EiSDbContext();

            var target = db.Destinations.Find(id);

            return Json(target);
        }
    }
}