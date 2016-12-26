using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TrasenLib;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Create
{
    /// <summary>
    /// 留观室——新增3。
    /// </summary>
    /// <remarks>实现生成器。</remarks>
    public class Create4
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Create4"/> class.
        /// </summary>
        public Create4()
        {

        }





        /// <summary>
        /// 基于指定条件获取实例。
        /// </summary>
        /// <param name="outPatientNumber">卡号。</param>
        /// <param name="JZID">门诊医师接诊记录ID。</param>
        /// <param name="GHXXID">挂号信息ID。</param>
        /// <param name="BRXXID">病人信息ID。</param>
        /// <param name="KDJID">卡登记ID。</param>
        public ObserveRoomInfo GetObserveRoomInfo(string outPatientNumber, Guid JZID, Guid GHXXID, Guid BRXXID, Guid KDJID)
        {
            var dbTrasen = new TrasenDbContext("TrasenConnection");

            var target = new ObserveRoomInfo();

            var BRXX = dbTrasen.VI_YY_BRXX.Where(c => c.BRXXID == BRXXID).FirstOrDefault();
            var GHXX = dbTrasen.VI_MZ_GHXX.Where(c => c.GHXXID == GHXXID).FirstOrDefault();
            var JZJL = dbTrasen.MZYS_JZJL.Where(c => c.JZID == JZID).FirstOrDefault();

            target.PatientName = BRXX?.BRXM;
            target.OutPatientNumber = outPatientNumber;
            if (BRXX != null)
                target.Sex = dbTrasen.JC_SEXCODE.Where(c => c.CODE == BRXX.XB).FirstOrDefault()?.NAME;
            target.BirthDate = BRXX?.CSRQ;
            target.DiagnosisNameOrigin = JZJL?.ZDMC;
            target.ReceiveTime = JZJL?.JSSJ;
            target.FirstDoctorName = dbTrasen.JC_EMPLOYEE_PROPERTY.Where(c => c.EMPLOYEE_ID == JZJL.JSYSDM).FirstOrDefault()?.NAME;

            target.KDJID = KDJID;
            target.BRXXID = BRXXID;
            target.GHXXID = GHXXID;
            target.JZID = JZID;

            target.InDepartmentTime = DateTime.Today;

            return target;
        }
    }
}