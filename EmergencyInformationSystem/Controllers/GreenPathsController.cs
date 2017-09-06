using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EmergencyInformationSystem.Models.Domains.Entities;

using EmergencyInformationSystem.Models.ViewModels.GreenPaths.IndexAmi;

namespace EmergencyInformationSystem.Controllers
{
    /// <summary>
    /// 绿色通道控制器。
    /// </summary>
    public class GreenPathsController : Controller
    {
        #region 主界面

        /// <summary>
        /// 绿色通道主界面。
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        #endregion





        #region AMI

        /// <summary>
        /// 一览。
        /// </summary>
        /// <param name="page">页码。</param>
        /// <param name="perPage">每页项目数。</param>
        public ActionResult IndexAmi(Route route)
        {
            var targetV = new IndexAmi(route);

            return View(targetV);
        }

        /// <summary>
        /// 急性心肌梗死详情。
        /// </summary>
        /// <param name="id">急性心肌梗死绿色通道ID。</param>
        public ActionResult DetailsAmi(Guid id)
        {
            var db = new EiSDbContext();

            var target = db.GreenPathAmis.Find(id);
            if (target == null)
                return null;

            return View(target);
        }

        /// <summary>
        /// 急性心肌梗死详情-打印。
        /// </summary>
        /// <param name="id">急性心肌梗死绿色通道ID。</param>
        public ActionResult DetailsAmiPrint(Guid id)
        {
            var db = new EiSDbContext();

            var target = db.GreenPathAmis.Find(id);
            if (target == null)
                return null;

            return View(target);
        }

        /// <summary>
        /// 急性心肌梗死新增。
        /// </summary>
        /// <param name="rescueRoomInfoId">归属的抢救室病例ID。</param>
        /// <remarks>直接生成后，跳转到Edit。</remarks>
        public ActionResult CreateAmi(int rescueRoomInfoId)
        {
            var db = new EiSDbContext();

            var rescueRoomInfo = db.RescueRoomInfos.Find(rescueRoomInfoId);
            if (rescueRoomInfo == null)
                return HttpNotFound();

            if (db.GreenPathAmis.Any(c => c.RescueRoomInfoId == rescueRoomInfoId))
                return HttpNotFound();

            var target = new GreenPathAmi();

            target.GreenPathAmiId = Guid.NewGuid();
            target.RescueRoomInfoId = rescueRoomInfoId;

            target.UpdateTime = DateTime.Now;

            db.GreenPathAmis.Add(target);
            db.SaveChanges();

            if (db.GreenPathAmis.Count(c => c.RescueRoomInfoId == rescueRoomInfoId) > 1)
            {
                db.GreenPathAmis.Remove(target);
                db.SaveChanges();

                return HttpNotFound();
            }

            return RedirectToAction("EditAmi", new { id = target.GreenPathAmiId });
        }

        /// <summary>
        /// 急性心肌梗死编辑。
        /// </summary>
        /// <param name="id">急性心肌梗死绿色通道ID。</param>
        public ActionResult EditAmi(Guid id)
        {
            var db = new EiSDbContext();

            var target = db.GreenPathAmis.Find(id);
            if (target == null)
                return HttpNotFound();

            return View(target);
        }

        /// <summary>
        /// 急性心肌梗死编辑 执行。
        /// </summary>
        /// <param name="greenPathAmi">提交实例。</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAmi([Bind()]GreenPathAmi greenPathAmi)
        {
            var db = new EiSDbContext();

            var rescueRoomInfo = db.RescueRoomInfos.Find(greenPathAmi.RescueRoomInfoId);

            //1-须先有首次心电图才能有再次心电图。
            if (greenPathAmi.EcgSecondTime.HasValue && !greenPathAmi.EcgFirstTime.HasValue)
                ModelState.AddModelError("EcgSecondTime", "须先有首次心电图才能有再次心电图。");
            //2-再次心电图时间不可早于首次心电图时间。
            if (greenPathAmi.EcgSecondTime.HasValue && greenPathAmi.EcgFirstTime.HasValue && greenPathAmi.EcgFirstTime.Value > greenPathAmi.EcgSecondTime.Value)
                ModelState.AddModelError("EcgSecondTime", "再次心电图时间不可早于首次心电图时间。");
            //3-完成通道时，发病时间不可为空。
            if (greenPathAmi.IsFinished && !greenPathAmi.OccurrenceTime.HasValue)
                ModelState.AddModelError("OccurrenceTime", "完成通道时，发病时间不可为空。");
            //4-发病时间不可晚于接诊时间。
            if (rescueRoomInfo.ReceiveTime.HasValue && greenPathAmi.OccurrenceTime.HasValue && rescueRoomInfo.ReceiveTime.Value < greenPathAmi.OccurrenceTime.Value)
                ModelState.AddModelError("OccurrenceTime", "发病时间不可晚于接诊时间。");
            //5-首次心电图时间不能早于接诊时间。
            //if (rescueRoomInfo.ReceiveTime.HasValue && greenPathAmi.EcgFirstTime.HasValue && rescueRoomInfo.ReceiveTime.Value > greenPathAmi.EcgFirstTime.Value)
            //    ModelState.AddModelError("EcgFirstTime", "首次心电图时间不能早于接诊时间。");
            //6-再次心电图时间不能晚于完成通道时间。
            if (greenPathAmi.FinishPathTime.HasValue && greenPathAmi.EcgSecondTime.HasValue && greenPathAmi.FinishPathTime.Value < greenPathAmi.EcgSecondTime.Value)
                ModelState.AddModelError("EcgSecondTime", "再次心电图时间不能晚于完成通道时间。");
            //7-完成通道时间不能早于接诊时间。
            if (rescueRoomInfo.ReceiveTime.HasValue && greenPathAmi.FinishPathTime.HasValue && rescueRoomInfo.ReceiveTime.Value > greenPathAmi.FinishPathTime.Value)
                ModelState.AddModelError("EcgFirstTime", "完成通道时间不能早于接诊时间。");

            if (ModelState.IsValid)
            {
                var target = db.GreenPathAmis.Find(greenPathAmi.GreenPathAmiId);
                if (target == null)
                    return HttpNotFound();

                target.OccurrenceTime = greenPathAmi.OccurrenceTime;
                target.EcgFirstTime = greenPathAmi.EcgFirstTime;
                target.EcgSecondTime = greenPathAmi.EcgSecondTime;
                target.Remarks = greenPathAmi.Remarks;
                target.Problem = greenPathAmi.Problem;
                target.FinishPathTime = greenPathAmi.FinishPathTime;
                target.IsHeldUp = greenPathAmi.IsHeldUp;

                target.TimeStamp = greenPathAmi.TimeStamp;
                target.UpdateTime = DateTime.Now;

                db.SaveChanges();

                return RedirectToAction("DetailsAmi", new { id = target.GreenPathAmiId });
            }

            return View(greenPathAmi);
        }

        #endregion
    }
}