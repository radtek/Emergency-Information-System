using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TrasenLib;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 抢救室用药项控制器。
    /// </summary>
    public class RescueRoomDrugRecordsController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RescueRoomDrugRecordsController"/> class.
        /// </summary>
        public RescueRoomDrugRecordsController()
        {
            db = new EiSDbContext();
            dbTrasen = new TrasenDbContext("TrasenConnection");
        }





        /// <summary>
        /// EiS数据上下文。
        /// </summary>
        private EiSDbContext db;

        /// <summary>
        /// Trasen数据上下文。
        /// </summary>
        private TrasenDbContext dbTrasen;





        /// <summary>
        /// 一览——部分。
        /// </summary>
        /// <param name="rescueRoomInfoId">归属的抢救室病例ID。</param>
        public ActionResult IndexPartial(int rescueRoomInfoId)
        {
            var target = db.RescueRoomInfos.Find(rescueRoomInfoId);
            if (target == null)
                return null;

            var query = target.RescueRoomDrugRecords.OrderBy(c => c.PrescriptionTime);

            return PartialView(query);
        }





        /// <summary>
        /// 刷新。
        /// </summary>
        /// <param name="rescueRoomInfoId">归属的抢救室病例ID。</param>
        public ActionResult Refresh(int rescueRoomInfoId)
        {
            var target = db.RescueRoomInfos.Find(rescueRoomInfoId);
            if (target == null)
                return HttpNotFound();

            //获取指定GHXXID的“处方表”记录。
            var queryCFB = dbTrasen.VI_MZ_CFB.Where(c => c.GHXXID == target.GHXXID && c.SFRQ >= target.ReceiveTime);
            foreach (var itemCFB in queryCFB)
            {
                //获取指定CFID的“处方表明细”记录。
                var queryCFBMX = dbTrasen.VI_MZ_CFB_MX.Where(c => c.CFID == itemCFB.CFID);
                foreach (var itemCFBMX in queryCFBMX)
                {
                    if ((!db.RescueRoomDrugRecords.Any(c => c.CFMXID == itemCFBMX.CFMXID)) && itemCFBMX.BM.Length == 6)
                    {
                        var newRescueRoomDrugRecord = new RescueRoomDrugRecord();

                        newRescueRoomDrugRecord.RescueRoomDrugRecordId = Guid.NewGuid();
                        newRescueRoomDrugRecord.RescueRoomInfoId = target.RescueRoomInfoId;
                        newRescueRoomDrugRecord.ProductCode = itemCFBMX.BM;
                        newRescueRoomDrugRecord.ProductName = itemCFBMX.PM;
                        newRescueRoomDrugRecord.GoodsName = itemCFBMX.SPM;
                        newRescueRoomDrugRecord.DosageQuantity = itemCFBMX.YL;
                        newRescueRoomDrugRecord.DosageUnit = itemCFBMX.YLDW;
                        newRescueRoomDrugRecord.PrescriptionTime = itemCFB.SFRQ;

                        newRescueRoomDrugRecord.CFMXID = itemCFBMX.CFMXID;

                        newRescueRoomDrugRecord.UpdateTime = DateTime.Now;

                        db.RescueRoomDrugRecords.Add(newRescueRoomDrugRecord);
                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("IndexPartial", new { rescueRoomInfoId });
        }
    }
}