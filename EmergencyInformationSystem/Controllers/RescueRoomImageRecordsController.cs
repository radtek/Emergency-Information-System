using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 抢救室影像项控制器。
    /// </summary>
    public class RescueRoomImageRecordsController : Controller
    {
        /// <summary>
        /// 一览——部分。
        /// </summary>
        /// <param name="rescueRoomInfoId">归属的抢救室病例ID。</param>
        public ActionResult IndexPartial(int rescueRoomInfoId)
        {
            var db = new EiSDbContext();

            var target = db.RescueRoomInfos.Find(rescueRoomInfoId);
            if (target == null)
                return null;

            var query = target.RescueRoomImageRecords.OrderBy(c => c.BookTime);

            return PartialView(query);
        }





        /// <summary>
        /// 刷新。
        /// </summary>
        /// <param name="id">归属的抢救室病例ID。</param>
        public ActionResult Refresh(int rescueRoomInfoId)
        {
            var db = new EiSDbContext();

            var target = db.RescueRoomInfos.Find(rescueRoomInfoId);
            if (target == null)
                return HttpNotFound();

            Oracle.ManagedDataAccess.Client.OracleConnection connection;
            Oracle.ManagedDataAccess.Client.OracleCommand command;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter dataAdapter;
            connection = new Oracle.ManagedDataAccess.Client.OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.100.9)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=hzsydb)));User Id=pacsinterface;Password=pubpacs;");
            command = new Oracle.ManagedDataAccess.Client.OracleCommand(string.Format("select * from pacstations.PACS_CHECK_VIEW where cureid='{0}' AND chktime>= to_date('{1}','yyyy-mm-dd')", target.OutPatientNumber, target.InDepartmentTime.ToString("yyyy-MM-dd")), connection);
            var dataSet = new System.Data.DataSet();
            dataAdapter = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(command);
            dataAdapter.Fill(dataSet);

            foreach (System.Data.DataRow row in dataSet.Tables[0].Rows)
            {
                var newRescueRoomImageRecord = new RescueRoomImageRecord();

                newRescueRoomImageRecord.BOOKID = (string)row["BOOKID"];

                if (db.RescueRoomImageRecords.Any(c => c.BOOKID == newRescueRoomImageRecord.BOOKID) || (target.OutDepartmentTime.HasValue && target.OutDepartmentTime.Value <= (DateTime?)row["CHKTIME"]))
                    continue;

                newRescueRoomImageRecord.RescueRoomImageRecordId = Guid.NewGuid();
                newRescueRoomImageRecord.RescueRoomInfoId = target.RescueRoomInfoId;
                newRescueRoomImageRecord.BookTime = (DateTime?)row["BOOKDATE"];
                newRescueRoomImageRecord.CheckTime = (DateTime?)row["CHKTIME"];
                newRescueRoomImageRecord.ReportTime = (DateTime?)row["REPTIME"];
                newRescueRoomImageRecord.Part = (string)row["CHKPARTS"];
                newRescueRoomImageRecord.Category = (string)row["CHKTYPENAME"];
                newRescueRoomImageRecord.ImageCategoryId = int.Parse(row["IMGTYPE"].ToString());

                newRescueRoomImageRecord.UpdateTime = DateTime.Now;

                db.RescueRoomImageRecords.Add(newRescueRoomImageRecord);
                db.SaveChanges();
            }

            //删除检查时间早于入室时间的影像项
            if (false)
            {
                var listRescueRoomImageRecord = db.RescueRoomImageRecords.Where(c => c.RescueRoomInfoId == target.RescueRoomInfoId && c.CheckTime < target.InDepartmentTime).ToList();
                db.RescueRoomImageRecords.RemoveRange(listRescueRoomImageRecord);
                db.SaveChanges();
            }

            //删除检查时间超过离室时间的影像项
            if (target.OutDepartmentTime.HasValue)
            {
                var listRescueRoomImageRecord = db.RescueRoomImageRecords.Where(c => c.RescueRoomInfoId == target.RescueRoomInfoId && target.OutDepartmentTime <= c.CheckTime).ToList();
                db.RescueRoomImageRecords.RemoveRange(listRescueRoomImageRecord);
                db.SaveChanges();
            }

            return RedirectToAction("IndexPartial", new { rescueRoomInfoId = rescueRoomInfoId });
        }
    }
}