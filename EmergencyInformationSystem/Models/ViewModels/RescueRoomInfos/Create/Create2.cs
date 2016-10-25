using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TrasenLib;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Create
{
    /// <summary>
    /// 抢救室——新增2。
    /// </summary>
    public class Create2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Create2"/> class.
        /// </summary>
        protected Create2()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Create2"/> class.
        /// </summary>
        /// <param name="outPatientNumber">卡号。</param>
        /// <param name="dbTrasen">创新数据库。</param>
        public Create2(string outPatientNumber, TrasenDbContext dbTrasen)
        {
            var KDJB = dbTrasen.YY_KDJB.Where(c => c.KH == outPatientNumber).First();
            var GHXXs = dbTrasen.VI_MZ_GHXX.Where(c => c.BRXXID == KDJB.BRXXID);

            this.ListGhxx = GHXXs.ToList().Select(c => new ItemGhxx(outPatientNumber, KDJB.KDJID, c, dbTrasen)).ToList();
        }





        /// <summary>
        /// 列表。
        /// </summary>
        public List<ItemGhxx> ListGhxx { get; set; }
    }
}