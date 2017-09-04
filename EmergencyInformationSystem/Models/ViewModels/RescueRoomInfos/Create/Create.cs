using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Create
{
    /// <summary>
    /// 抢救室——新增1。
    /// </summary>
    public class Create
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        public Create()
        {

        }





        /// <summary>
        /// 卡号。
        /// </summary>
        [Required]
        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }
    }
}