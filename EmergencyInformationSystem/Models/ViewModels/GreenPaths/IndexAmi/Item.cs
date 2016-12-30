using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.GreenPaths.IndexAmi
{
    public class Item
    {
        public Item(GreenPathAmi origin)
        {
            this.GreenPathAmiId = origin.GreenPathAmiId;
            this.RescueRoomInfoId = origin.RescueRoomInfoId;
            this.IsLeave = origin.RescueRoomInfo.IsLeave;

            this.PatientName = origin.RescueRoomInfo.PatientName;
            this.OutPatientNumber = origin.RescueRoomInfo.OutPatientNumber;
            this.InDepartmentTime = origin.RescueRoomInfo.InDepartmentTime;

            this.OccurrenceTime = origin.OccurrenceTime;

            this.EcgFirstTime = origin.EcgFirstTime;
            this.EcgSecondTime = origin.EcgSecondTime;
            this.Remarks = origin.Remarks;

            this.FinishPathTime = origin.FinishPathTime;
            this.OutDepartmentTime = origin.RescueRoomInfo.OutDepartmentTime;
            this.IsHeldUp = origin.IsHeldUp;
            this.Problem = origin.Problem;
        }





        public Guid GreenPathAmiId { get; set; }

        public int RescueRoomInfoId { get; set; }

        public bool IsLeave { get; set; }





        /// <summary>
        /// 患者姓名。
        /// </summary>
        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        /// <summary>
        /// 卡号。
        /// </summary>
        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        /// <summary>
        /// 入室时间。
        /// </summary>        
        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }





        [Display(Name = "发病时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? OccurrenceTime { get; set; }





        /// <summary>
        /// 首次心电图时间。
        /// </summary>
        [Display(Name = "首次心电图时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? EcgFirstTime { get; set; }

        /// <summary>
        /// 再次心电图时间。
        /// </summary>
        [Display(Name = "再次心电图时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? EcgSecondTime { get; set; }

        /// <summary>
        /// 备注。
        /// </summary>
        [Display(Name = "备注")]
        public string Remarks { get; set; }





        /// <summary>
        /// 完成通道时间。
        /// </summary>
        [Display(Name = "完成通道时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? FinishPathTime { get; set; }

        /// <summary>
        /// 离室时间。
        /// </summary>
        [Display(Name = "离室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]

        public DateTime? OutDepartmentTime { get; set; }
        /// <summary>
        /// 是否滞留。
        /// </summary>
        [Display(Name = "滞留")]
        public bool IsHeldUp { get; set; }

        /// <summary>
        /// 存在问题。
        /// </summary>
        [Display(Name = "存在问题")]
        public string Problem { get; set; }
    }
}