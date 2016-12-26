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
        /// 一览。
        /// </summary>
        /// <param name="rescueRoomInfoId">归属的抢救室病例ID。</param>
        public ActionResult IndexPartial(int rescueRoomInfoId)
        {
            var db = new EiSDbContext();

            var target = db.RescueRoomInfos.Find(rescueRoomInfoId);
            if (target == null)
                return null;

            var list = target.RescueRoomDrugRecords.OrderBy(c => c.PrescriptionTime).ThenBy(c => c.CFID).ThenBy(c => c.ProductCode).GroupBy(c => c.CFID).ToList();

            return PartialView(list);
        }





        /// <summary>
        /// 刷新。
        /// </summary>
        /// <param name="rescueRoomInfoId">归属的抢救室病例ID。</param>
        public ActionResult Refresh(int rescueRoomInfoId)
        {
            var db = new EiSDbContext();
            var dbTrasen = new TrasenDbContext("TrasenConnection");

            var target = db.RescueRoomInfos.Find(rescueRoomInfoId);
            if (target == null)
                return HttpNotFound();

            //获取指定GHXXID的“处方表”记录。
            var queryCFB = dbTrasen.VI_MZ_CFB.Where(c => c.GHXXID == target.GHXXID && target.ReceiveTime <= c.SFRQ);

            if (target.OutDepartmentTime.HasValue)
                queryCFB = queryCFB.Where(c => c.SFRQ < target.OutDepartmentTime);

            var listCFB = queryCFB.ToList();

            foreach (var itemCFB in listCFB)
            {
                //获取指定CFID的“处方表明细”记录。
                var queryCFBMX = dbTrasen.VI_MZ_CFB_MX.Where(c => c.CFID == itemCFB.CFID);
                var listCFBMX = queryCFBMX.ToList();

                foreach (var itemCFBMX in listCFBMX)
                {
                    if (db.RescueRoomDrugRecordDefinitions.Any(c => c.DrugCode == itemCFBMX.BM))
                    {
                        var rescueRoomDrugRecord = db.RescueRoomDrugRecords.Where(c => c.CFMXID == itemCFBMX.CFMXID).FirstOrDefault();

                        if (rescueRoomDrugRecord == null)
                        {
                            rescueRoomDrugRecord = new RescueRoomDrugRecord();

                            rescueRoomDrugRecord.RescueRoomDrugRecordId = Guid.NewGuid();
                            rescueRoomDrugRecord.RescueRoomInfoId = target.RescueRoomInfoId;
                            rescueRoomDrugRecord.ProductCode = itemCFBMX.BM;
                            rescueRoomDrugRecord.ProductName = itemCFBMX.PM;
                            rescueRoomDrugRecord.GoodsName = itemCFBMX.SPM;
                            rescueRoomDrugRecord.DosageQuantity = itemCFBMX.YL;
                            rescueRoomDrugRecord.DosageUnit = itemCFBMX.YLDW;
                            rescueRoomDrugRecord.PrescriptionTime = itemCFB.SFRQ;
                            rescueRoomDrugRecord.Usage = itemCFBMX.YFMC;

                            rescueRoomDrugRecord.CFMXID = itemCFBMX.CFMXID;
                            rescueRoomDrugRecord.CFID = itemCFBMX.CFID;

                            rescueRoomDrugRecord.UpdateTime = DateTime.Now;

                            db.RescueRoomDrugRecords.Add(rescueRoomDrugRecord);
                            db.SaveChanges();
                        }
                        else
                        {
                            rescueRoomDrugRecord.RescueRoomInfoId = target.RescueRoomInfoId;
                            rescueRoomDrugRecord.ProductCode = itemCFBMX.BM;
                            rescueRoomDrugRecord.ProductName = itemCFBMX.PM;
                            rescueRoomDrugRecord.GoodsName = itemCFBMX.SPM;
                            rescueRoomDrugRecord.DosageQuantity = itemCFBMX.YL;
                            rescueRoomDrugRecord.DosageUnit = itemCFBMX.YLDW;
                            rescueRoomDrugRecord.PrescriptionTime = itemCFB.SFRQ;
                            rescueRoomDrugRecord.Usage = itemCFBMX.YFMC;

                            rescueRoomDrugRecord.CFMXID = itemCFBMX.CFMXID;
                            rescueRoomDrugRecord.CFID = itemCFBMX.CFID;

                            db.SaveChanges();
                        }
                    }
                }
            }

            //删除处方时间早于接诊时间的用药项
            if (true)
            {
                var listRescueRoomDrugRecord = db.RescueRoomDrugRecords.Where(c => c.RescueRoomInfoId == target.RescueRoomInfoId && c.PrescriptionTime < target.ReceiveTime).ToList();
                db.RescueRoomDrugRecords.RemoveRange(listRescueRoomDrugRecord);
                db.SaveChanges();
            }

            //删除处方时间超过离室时间的用药项
            if (target.OutDepartmentTime.HasValue)
            {
                var listRescueRoomDrugRecord = db.RescueRoomDrugRecords.Where(c => c.RescueRoomInfoId == target.RescueRoomInfoId && target.OutDepartmentTime <= c.PrescriptionTime).ToList();
                db.RescueRoomDrugRecords.RemoveRange(listRescueRoomDrugRecord);
                db.SaveChanges();
            }

            //删除编码在定义外的用药项
            if (true)
            {
                var listRescueRoomDrugRecord = db.RescueRoomDrugRecords.ToList();
                var listRescueRoomDrugRecordDefinition = db.RescueRoomDrugRecordDefinitions.Where(c => c.GreenPathCode == "Ami").ToList();

                foreach (var itemRescueRoomDrugRecord in listRescueRoomDrugRecord)
                {
                    if (!listRescueRoomDrugRecordDefinition.Any(c => c.DrugCode == itemRescueRoomDrugRecord.ProductCode))
                    {
                        db.RescueRoomDrugRecords.Remove(itemRescueRoomDrugRecord);
                    }
                }
                db.SaveChanges();
            }

            return RedirectToAction("IndexPartial", new { rescueRoomInfoId });
        }
    }
}