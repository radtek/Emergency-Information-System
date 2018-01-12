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
        public ActionResult IndexPartial(Guid rescueRoomInfoId)
        {
            var targetV = new Models.ViewModels.RescueRoomDrugRecords.IndexPartial.IndexPartial(rescueRoomInfoId);

            return PartialView(targetV);
        }





        /// <summary>
        /// 刷新。
        /// </summary>
        /// <param name="rescueRoomInfoId">归属的抢救室病例ID。</param>
        public ActionResult Refresh(Guid rescueRoomInfoId)
        {
            var db = new EiSDbContext();
            var dbTrasen = new TrasenDbContext("TrasenConnection");

            var target = db.RescueRoomInfos.Find(rescueRoomInfoId);
            if (target == null)
                return HttpNotFound();

            //设置时段起点、结点
            DateTime? timeUpperBound;
            DateTime? timeLowerBound;
            {
                timeUpperBound = target.ReceiveTime;
                var itemJZJL = dbTrasen.MZYS_JZJL.Where(c => c.JZID == target.JZID).FirstOrDefault();
                timeLowerBound = itemJZJL.WCSJ;
            }

            //==获取指定GHXXID的“处方表”记录。==
            var queryCFB = dbTrasen.VI_MZ_CFB.Where(c => c.GHXXID == target.GHXXID);
            //设置时段起点
            queryCFB = queryCFB.Where(c => timeUpperBound <= c.SFRQ);
            //设置时段结点
            if (timeLowerBound.HasValue)
                queryCFB = queryCFB.Where(c => c.SFRQ <= timeLowerBound.Value);//该结点边界特殊，使用闭区间——结束的瞬间可能同时有医嘱。

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
                        //判断是新增的药品还是退费的药品
                        if (!itemCFBMX.TYID.HasValue)
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
                        else
                        {
                            var rescueRoomDrugRecord = db.RescueRoomDrugRecords.Where(c => c.CFMXID == itemCFBMX.TYID.Value).FirstOrDefault();

                            if (rescueRoomDrugRecord != null)
                            {
                                rescueRoomDrugRecord.DosageQuantity -= itemCFBMX.YL;

                                if (rescueRoomDrugRecord.DosageQuantity == 0)
                                    db.RescueRoomDrugRecords.Remove(rescueRoomDrugRecord);

                                db.SaveChanges();
                            }
                            else
                            {
                                throw new Exception("无对应原始处方明细记录。");
                            }
                        }
                    }
                }
            }

            //删除处方时间早于时段起点的用药项
            if (timeUpperBound.HasValue)
            {
                var listRescueRoomDrugRecord = db.RescueRoomDrugRecords.Where(c => c.RescueRoomInfoId == target.RescueRoomInfoId && c.PrescriptionTime < timeUpperBound).ToList();
                db.RescueRoomDrugRecords.RemoveRange(listRescueRoomDrugRecord);
                db.SaveChanges();
            }

            //删除处方时间超过时段结点的用药项
            if (timeLowerBound.HasValue)
            {
                var listRescueRoomDrugRecord = db.RescueRoomDrugRecords.Where(c => c.RescueRoomInfoId == target.RescueRoomInfoId && timeLowerBound < c.PrescriptionTime).ToList();
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