using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Create
{
    /// <summary>
    /// 留观室——新增——1。
    /// </summary>
    public class Create
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Create"/> class.
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