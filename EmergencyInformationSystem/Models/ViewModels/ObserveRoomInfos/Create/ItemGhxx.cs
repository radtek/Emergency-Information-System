using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using TrasenLib;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Create
{
    /// <summary>
    /// 留观室——新增2——挂号信息。
    /// </summary>
    public class ItemGhxx
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemGhxx"/> class.
        /// </summary>
        protected ItemGhxx()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemGhxx"/> class.
        /// </summary>
        /// <param name="outPatientNumber">卡号。</param>
        /// <param name="KDJID">卡登记ID。</param>
        /// <param name="GHXX">挂号信息。</param>
        /// <param name="dbTrasen">创新数据库。</param>
        public ItemGhxx(string outPatientNumber, Guid KDJID, VI_MZ_GHXX GHXX, TrasenDbContext dbTrasen)
        {
            this.RegisterTime = GHXX.GHSJ;

            var JZJLs = dbTrasen.MZYS_JZJL.Where(c => c.GHXXID == GHXX.GHXXID);

            this.ListJzjl = JZJLs.ToList().Select(c => new ItemJzjl(outPatientNumber, KDJID, c, dbTrasen)).ToList();
        }





        /// <summary>
        /// 挂号时间。
        /// </summary>
        [Display(Name = "挂号时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? RegisterTime { get; set; }





        /// <summary>
        /// 急诊记录列表。
        /// </summary>
        public List<ItemJzjl> ListJzjl { get; set; }
    }
}