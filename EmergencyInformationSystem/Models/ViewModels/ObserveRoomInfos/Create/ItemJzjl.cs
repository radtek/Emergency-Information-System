using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using TrasenLib;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Create
{
    /// <summary>
    /// 留观室——新增2——接诊记录。
    /// </summary>
    public class ItemJzjl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemJzjl"/> class.
        /// </summary>
        /// <param name="JZJL">门诊医师接诊记录。</param>
        public ItemJzjl(MZYS_JZJL JZJL)
        {
            var dbTrasen = new TrasenDbContext("TrasenConnection");

            this.ORIGIN_JZID = JZJL.JZID;

            this.FirstDoctorName = dbTrasen.JC_EMPLOYEE_PROPERTY.Where(c => c.EMPLOYEE_ID == JZJL.JSYSDM).FirstOrDefault()?.NAME;
            this.DiagnosisNameOrigin = JZJL.ZDMC;
            this.ReceiveTime = JZJL.JSSJ;
        }





        /// <summary>
        /// 接诊ID。
        /// </summary>
        public Guid ORIGIN_JZID { get; set; }





        /// <summary>
        /// 接诊医师。
        /// </summary>
        [Display(Name = "接诊医师")]
        public string FirstDoctorName { get; set; }

        /// <summary>
        /// 诊断名称。
        /// </summary>
        [Display(Name = "诊断名称")]
        public string DiagnosisNameOrigin { get; set; }

        /// <summary>
        /// 接诊时间。
        /// </summary>
        [Display(Name = "接诊时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? ReceiveTime { get; set; }
    }
}