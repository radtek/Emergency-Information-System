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
        /// 初始化。
        /// </summary>
        /// <param name="outPatientNumber">卡号。</param>
        public Create2(string outPatientNumber)
        {
            var dbTrasen = new TrasenDbContext("TrasenConnection");

            var itemKDJB = dbTrasen.YY_KDJB.Where(c => c.KH == outPatientNumber).First();
            var listGHXX = dbTrasen.VI_MZ_GHXX.Where(c => c.BRXXID == itemKDJB.BRXXID).OrderByDescending(c => c.GHSJ).ThenBy(c => c.GHXXID).ToList();

            this.ListGhxx = listGHXX.Select(c => new ItemGhxx(outPatientNumber, itemKDJB.KDJID, c)).ToList();
        }





        /// <summary>
        /// 列表。
        /// </summary>
        public List<ItemGhxx> ListGhxx { get; set; }
    }
}