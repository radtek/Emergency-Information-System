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
        protected ItemJzjl()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemJzjl"/> class.
        /// </summary>
        /// <param name="outPatientNumber">卡号。</param>
        /// <param name="KDJID">卡登记ID。</param>
        /// <param name="JZJL">门诊医师接诊记录。</param>
        /// <param name="dbTrasen">创新数据库。</param>
        public ItemJzjl(string outPatientNumber, Guid KDJID, MZYS_JZJL JZJL, TrasenDbContext dbTrasen)
        {
            this.ORIGIN_JZID = JZJL.JZID;
            this.ORIGIN_KDJID = KDJID;
            this.ORIGIN_BRXXID = JZJL.BRXXID;
            this.ORIGIN_GHXXID = JZJL.GHXXID;
            this.OutPatientNumber = outPatientNumber;

            this.FirstDoctorName = dbTrasen.JC_EMPLOYEE_PROPERTY.Where(c => c.EMPLOYEE_ID == JZJL.JSYSDM).FirstOrDefault()?.NAME;
            this.DiagnosisNameOrigin = JZJL.ZDMC;
            this.ReceiveTime = JZJL.JSSJ;
        }





        /// <summary>
        /// 接诊ID。
        /// </summary>
        public Guid ORIGIN_JZID { get; set; }

        /// <summary>
        /// 卡登记ID。
        /// </summary>
        public Guid? ORIGIN_KDJID { get; set; }

        /// <summary>
        /// 病人信息ID。
        /// </summary>
        public Guid? ORIGIN_BRXXID { get; set; }

        /// <summary>
        /// 挂号信息ID。
        /// </summary>
        public Guid ORIGIN_GHXXID { get; set; }

        /// <summary>
        /// 卡号。
        /// </summary>
        public string OutPatientNumber { get; set; }





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