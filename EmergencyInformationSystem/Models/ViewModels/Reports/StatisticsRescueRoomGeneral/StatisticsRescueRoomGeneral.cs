using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.Reports.StatisticsRescueRoomGeneral
{
    public class StatisticsRescueRoomGeneral
    {
        public StatisticsRescueRoomGeneral(DateTime start, DateTime end)
        {
            var db = new EiSDbContext();

            var list = db.RescueRoomInfos.Where(c => start <= c.OutDepartmentTime && c.OutDepartmentTime < end).ToList();

            this.Start = start;
            this.End = end;

            this.CountAll = list.Count();
            this.CountIsRescue = list.Count(c => c.IsRescue);

            //抢救
            this.ListRescue = new ItemRescue(start, end, 0, this.CountAll, list);

            //入室方式
            this.ListIndepartmentWay = new ItemInDepartmentWay(start, end, 0, this.CountAll, list);
        }





        public DateTime Start { get; set; }

        public DateTime End { get; set; }





        [Display(Name = "总例数")]
        public int CountAll { get; set; }

        [Display(Name = "抢救例数")]
        public int CountIsRescue { get; set; }

        [Display(Name = "绿色通道例数")]
        public int CountIsGreenPath { get; set; }

        [Display(Name = "平均停留时长")]
        public TimeSpan AverageDuring { get; set; }





        public ItemRescue ListRescue { get; set; }

        public ItemInDepartmentWay ListIndepartmentWay { get; set; }
    }
}