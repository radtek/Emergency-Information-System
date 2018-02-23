using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos2.Details
{
    public class Details
    {
        public Details(Guid id)
        {
            var db3 = new Domains3.Entities.EiSDbContext();
            var target = db3.GeneralRoomInfos.Find(id);
            this.Initial(target);
        }

        public Details(Domains3.Entities.GeneralRoomInfo target)
        {
            this.Initial(target);
        }

        private void Initial(Domains3.Entities.GeneralRoomInfo target)
        {
            this.GeneralRoomInfoId = target.GeneralRoomInfoId;
            this.IsTransferRoom = target.IsTransferRoom;
            this.GreenPathId = target.GreenPathInfos.FirstOrDefault()?.GrennPathId;
            this.IsGreenPathHasForm = target.GreenPathCategory == null ? false : target.GreenPathCategory.IsHasForm;

            this.InDepartmentTime = target.InDepartmentTime;
            this.BedNameFull = target.BedNameFull;
            this.FirstNurseName = target.FirstNurseName;
            this.InRoomWayNameFull = target.InRoomWayNameFull;
            this.AdditionalDiagnosis = target.AdditionalDiagnosis;

            this.CriticalLevelName = target.CriticalLevel?.CriticalLevelName;
            this.RescueResultNameFull = target.RescueResultNameFull;
            this.GreenPathCategoryNameFull = target.GreenPathCategoryNameFull;
            this.Antibiotic = target.Antibiotic;
            this.Remarks = target.Remarks;

            this.DestinationFirstName = target.DestinationFirst?.DestinationName;
            this.DestinationFirstTime = target.DestinationFirstTime;
            this.DestinationFirstContact = target.DestinationFirstContact;
            this.DestinationSecondName = target.DestinationSecond?.DestinationName;

            this.OutDepartmentTime = target.OutDepartmentTime;
            this.During = target.During;
            this.DuringDetained = target.DuringDetained;
            this.DestinationNameFull = target.DestinationNameFull;
            this.HandleNurse = target.HandleNurse;
            this.DiagnosisName = target.DiagnosisName;
            this.IsLeaveName = target.IsLeaveName;
        }





        public Guid GeneralRoomInfoId { get; set; }

        public bool IsTransferRoom { get; set; }

        /// <summary>
        /// 绿色通道实际记录ID。
        /// </summary>
        public Guid? GreenPathId { get; set; }

        /// <summary>
        /// 是否存在专用绿色通道表单。
        /// </summary>
        public bool IsGreenPathHasForm { get; set; }





        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }

        [Display(Name = "床位")]
        public string BedNameFull { get; set; }

        [Display(Name = "首诊护士")]
        public string FirstNurseName { get; set; }

        [Display(Name = "入室方式")]
        public string InRoomWayNameFull { get; set; }

        [Display(Name = "补充诊断")]
        public string AdditionalDiagnosis { get; set; }





        [Display(Name = "危重等级")]
        public string CriticalLevelName { get; set; }

        [Display(Name = "抢救")]
        public string RescueResultNameFull { get; set; }

        [Display(Name = "绿色通道")]
        public string GreenPathCategoryNameFull { get; set; }

        [Display(Name = "抗生素")]
        public string Antibiotic { get; set; }

        [Display(Name = "备注")]
        public string Remarks { get; set; }





        [Display(Name = "预约首选科室")]
        public string DestinationFirstName { get; set; }

        [Display(Name = "预约首选时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? DestinationFirstTime { get; set; }

        [Display(Name = "预约首选医师")]
        public string DestinationFirstContact { get; set; }

        [Display(Name = "预约次选科室")]
        public string DestinationSecondName { get; set; }





        [Display(Name = "离室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? OutDepartmentTime { get; set; }

        [Display(Name = "停留时长")]
        public TimeSpan? During { get; set; }

        [Display(Name = "连续滞留时长")]
        public TimeSpan DuringDetained { get; set; }

        [Display(Name = "去向")]
        public string DestinationNameFull { get; set; }

        [Display(Name = "经手护士")]
        public string HandleNurse { get; set; }

        [Display(Name = "离室诊断")]
        public string DiagnosisName { get; set; }

        [Display(Name = "离室")]
        public string IsLeaveName { get; set; }
    }
}