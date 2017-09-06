using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Create
{
    /// <summary>
    /// 留观室记录项。
    /// </summary>
    public class ItemObserveRoomInfo
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="observeRoomInfo">源留观室记录。</param>
        /// <param name="JZID">接诊ID。</param>
        public ItemObserveRoomInfo(ObserveRoomInfo observeRoomInfo, Guid JZID)
        {
            this.ObserveRoomInfoId = observeRoomInfo.ObserveRoomInfoId;
            this.JZID = JZID;

            if (observeRoomInfo.NextRescueRoomInfo == null)
            {
                if (observeRoomInfo.Destination.IsGotoRescueRoom)
                {
                    this.IsUsable = true;
                    this.DisplayText = string.Empty;
                }
                else
                {
                    this.IsUsable = false;
                    this.DisplayText = "非去往抢救室";
                }
            }
            else
            {
                this.IsUsable = false;
                this.DisplayText = "已被其他记录关联";
            }

            this.ReceiveTime = observeRoomInfo.ReceiveTime;
            this.InDepartmentTime = observeRoomInfo.InDepartmentTime;
            this.OutDepartmentTime = observeRoomInfo.OutDepartmentTime.Value;
            this.BedNameFull = observeRoomInfo.BedNameFull;
        }





        public Guid ObserveRoomInfoId { get; set; }

        public Guid JZID { get; set; }

        public bool IsUsable { get; set; }

        public string DisplayText { get; set; }





        [Display(Name = "接诊时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? ReceiveTime { get; set; }

        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }

        [Display(Name = "离室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime OutDepartmentTime { get; set; }

        [Display(Name = "床位")]
        public string BedNameFull { get; set; }
    }
}