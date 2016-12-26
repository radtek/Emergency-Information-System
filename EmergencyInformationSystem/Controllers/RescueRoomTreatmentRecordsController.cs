﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TrasenLib;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 抢救室治疗项控制器。
    /// </summary>
    public class RescueRoomTreatmentRecordsController : Controller
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

            var list = target.RescueRoomTreatmentRecords.OrderBy(c => c.PrescriptionTime).ThenBy(c => c.CFID).ThenBy(c => c.ProductCode).GroupBy(c => c.CFID).ToList();

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
                    if (db.RescueRoomTreatmentRecordDefinitions.Any(c => c.TreatmentCode == itemCFBMX.BM))
                    {
                        var rescueRoomTreatmentRecord = db.RescueRoomTreatmentRecords.Where(c => c.CFMXID == itemCFBMX.CFMXID).FirstOrDefault();

                        if (rescueRoomTreatmentRecord == null)
                        {
                            rescueRoomTreatmentRecord = new RescueRoomTreatmentRecord();

                            rescueRoomTreatmentRecord.RescueRoomTreatmentRecordId = Guid.NewGuid();
                            rescueRoomTreatmentRecord.RescueRoomInfoId = target.RescueRoomInfoId;
                            rescueRoomTreatmentRecord.ProductCode = itemCFBMX.BM;
                            rescueRoomTreatmentRecord.ProductName = itemCFBMX.PM;
                            rescueRoomTreatmentRecord.GoodsName = itemCFBMX.SPM;
                            rescueRoomTreatmentRecord.DosageQuantity = itemCFBMX.YL;
                            rescueRoomTreatmentRecord.DosageUnit = itemCFBMX.YLDW;
                            rescueRoomTreatmentRecord.PrescriptionTime = itemCFB.SFRQ;
                            rescueRoomTreatmentRecord.Usage = itemCFBMX.YFMC;

                            rescueRoomTreatmentRecord.CFMXID = itemCFBMX.CFMXID;
                            rescueRoomTreatmentRecord.CFID = itemCFBMX.CFID;

                            rescueRoomTreatmentRecord.UpdateTime = DateTime.Now;

                            db.RescueRoomTreatmentRecords.Add(rescueRoomTreatmentRecord);
                            db.SaveChanges();
                        }
                        else
                        {
                            rescueRoomTreatmentRecord.RescueRoomInfoId = target.RescueRoomInfoId;
                            rescueRoomTreatmentRecord.ProductCode = itemCFBMX.BM;
                            rescueRoomTreatmentRecord.ProductName = itemCFBMX.PM;
                            rescueRoomTreatmentRecord.GoodsName = itemCFBMX.SPM;
                            rescueRoomTreatmentRecord.DosageQuantity = itemCFBMX.YL;
                            rescueRoomTreatmentRecord.DosageUnit = itemCFBMX.YLDW;
                            rescueRoomTreatmentRecord.PrescriptionTime = itemCFB.SFRQ;
                            rescueRoomTreatmentRecord.Usage = itemCFBMX.YFMC;

                            rescueRoomTreatmentRecord.CFMXID = itemCFBMX.CFMXID;
                            rescueRoomTreatmentRecord.CFID = itemCFBMX.CFID;

                            db.SaveChanges();
                        }
                    }
                }
            }

            //删除处方时间早于接诊时间的治疗项
            if (true)
            {
                var listRescueRoomTreatmentRecord = db.RescueRoomTreatmentRecords.Where(c => c.RescueRoomInfoId == target.RescueRoomInfoId && c.PrescriptionTime < target.ReceiveTime).ToList();
                db.RescueRoomTreatmentRecords.RemoveRange(listRescueRoomTreatmentRecord);
                db.SaveChanges();
            }

            //删除处方时间超过离室时间的治疗项
            if (target.OutDepartmentTime.HasValue)
            {
                var listRescueRoomTreatmentRecord = db.RescueRoomTreatmentRecords.Where(c => c.RescueRoomInfoId == target.RescueRoomInfoId && target.OutDepartmentTime <= c.PrescriptionTime).ToList();
                db.RescueRoomTreatmentRecords.RemoveRange(listRescueRoomTreatmentRecord);
                db.SaveChanges();
            }

            //删除编码在定义外的治疗项
            if (true)
            {
                var listRescueRoomTreatmentRecord = db.RescueRoomTreatmentRecords.ToList();
                var listRescueRoomTreatmentRecordDefinition = db.RescueRoomTreatmentRecordDefinitions.Where(c => c.GreenPathCode == "Amim").ToList();

                foreach (var itemRescueRoomTreatmentRecord in listRescueRoomTreatmentRecord)
                {
                    if (!listRescueRoomTreatmentRecordDefinition.Any(c => c.TreatmentCode == itemRescueRoomTreatmentRecord.ProductCode))
                    {
                        db.RescueRoomTreatmentRecords.Remove(itemRescueRoomTreatmentRecord);
                    }
                }
                db.SaveChanges();
            }

            return RedirectToAction("IndexPartial", new { rescueRoomInfoId });
        }
    }
}