﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using TrasenLib;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Create
{
    /// <summary>
    /// 抢救室——新增2——挂号信息。
    /// </summary>
    public class ItemGhxx
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="GHXX">挂号信息。</param>
        public ItemGhxx(VI_MZ_GHXX GHXX)
        {
            var dbTrasen = new TrasenDbContext("TrasenConnection");

            this.RegisterTime = GHXX.GHSJ;

            var listJZJL = dbTrasen.MZYS_JZJL.Where(c => c.GHXXID == GHXX.GHXXID).OrderByDescending(c => c.JSSJ).ThenBy(c => c.JZID).ToList();

            this.ListJzjl = listJZJL.Select(c => new ItemJzjl(c)).ToList();
        }





        /// <summary>
        /// 挂号时间。
        /// </summary>
        [Display(Name = "挂号时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? RegisterTime { get; set; }





        /// <summary>
        /// 接诊记录列表。
        /// </summary>
        public List<ItemJzjl> ListJzjl { get; set; }
    }
}