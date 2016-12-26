﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Create
{
    public class ItemRescueRoomInfo
    {
        public ItemRescueRoomInfo(RescueRoomInfo rescueRoomInfo,string outPatientNumber, Guid JZID, Guid GHXXID, Guid BRXXID, Guid KDJID)
        {
            this.RescueRoomInfoId = rescueRoomInfo.RescueRoomInfoId;
            this.OutPatientNumber = outPatientNumber;
            this.JZID = JZID;
            this.GHXXID = GHXXID;
            this.BRXXID = BRXXID;
            this.KDJID = KDJID;
            if (rescueRoomInfo.NextObserveRoomInfo == null)
            {
                if (rescueRoomInfo.Destination.IsGotoObserveRoom)
                {
                    this.IsUsable = true;
                    this.DisplayText = string.Empty;
                }
                else
                {
                    this.IsUsable = false;
                    this.DisplayText = "非去往留观室";
                }
            }
            else
            {
                this.IsUsable = false;
                this.DisplayText = "已被其他记录关联";
            }

            this.ReceiveTime = rescueRoomInfo.ReceiveTime;
            this.InDepartmentTime = rescueRoomInfo.InDepartmentTime;
            this.OutDepartmentTime = rescueRoomInfo.OutDepartmentTime.Value;
            this.BedNameFull = rescueRoomInfo.BedNameFull;
        }





        public int RescueRoomInfoId { get; set; }

        public string OutPatientNumber { get; set; }

        public Guid JZID { get; set; }

        public Guid GHXXID { get; set; }

        public Guid BRXXID { get; set; }

        public Guid KDJID { get; set; }

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