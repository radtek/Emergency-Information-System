using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.GreenPaths.DetailsAmiPrint
{
    public class DetailsAmiPrint
    {
        public DetailsAmiPrint(Models.Domains.Entities.GreenPathAmi target)
        {
            this.GreenPathAmiId = target.GreenPathAmiId;
            this.RescueRoomInfoId = target.RescueRoomInfoId;
            this.IsHeldUp = target.IsHeldUp;

            this.PatientName = target.RescueRoomInfo.PatientName;
            this.OutPatientNumber = target.RescueRoomInfo.OutPatientNumber;
            this.Sex = target.RescueRoomInfo.Sex;
            this.ReceiveAgeName = target.RescueRoomInfo.ReceiveAgeName;
            this.ReceiveTime = target.RescueRoomInfo.ReceiveTime;
            this.FirstDoctorName = target.RescueRoomInfo.FirstDoctorName;
            this.DiagnosisNameOrigin = target.RescueRoomInfo.DiagnosisNameOrigin;

            this.OccurrenceTime = target.OccurrenceTime;
            this.InDepartmentTime = target.RescueRoomInfo.InDepartmentTime;
            this.BedNameFull = target.RescueRoomInfo.BedNameFull;
            this.InRescueRoomWayNameFull = target.RescueRoomInfo.InRescueRoomWayNameFull;
            this.DuringOccurrenceToInDepartment = target.DuringOccurrenceToInDepartment;
            this.DuringInDepartmentToReceive = target.DuringInDepartmentToReceive;
            this.FirstNurseName = target.RescueRoomInfo.FirstNurseName;

            this.CriticalLevelName = target.RescueRoomInfo.CriticalLevel.CriticalLevelName;
            this.RescueResultNameFull = target.RescueRoomInfo.RescueResultNameFull;
            this.EcgFirstTime = target.EcgFirstTime;
            this.EcgSecondTime = target.EcgSecondTime;
            this.DuringInDepartmentToEcgFirst = target.DuringInDepartmentToEcgFirst;
            this.DuringInDepartmentToEcgSecond = target.DuringInDepartmentToEcgSecond;

            this.FinishPathTime = target.FinishPathTime;
            this.OutDepartmentTime = target.RescueRoomInfo.OutDepartmentTime;
            this.IsHeldUpString = target.IsHeldUpString;
            this.DuringPathHeldUp = target.DuringPathHeldUp;
            this.During = target.During;
            this.DuringOfRescueRoom = target.RescueRoomInfo.During;
            this.DuringDetained = target.RescueRoomInfo.DuringDetained;
            this.DestinationNameFull = target.RescueRoomInfo.DestinationNameFull;
            this.Problem = target.Problem;
            this.Remarks = target.Remarks;

            this.ListRescueRoomImageRecord = target.RescueRoomInfo.RescueRoomImageRecords.Select(c => new ItemRescueRoomImageRecord(c)).OrderBy(c => c.BookTime).ThenBy(c => c.RescueRoomImageRecordId).ToList();
            this.ListRescueRoomConsultation = target.RescueRoomInfo.RescueRoomConsultations.Select(c => new ItemRescueRoomConsultation(c)).OrderBy(c => c.RequestTime).ThenBy(c => c.RescueRoomConsultationId).ToList();
            this.ListRescueRoomDrugRecord = target.RescueRoomInfo.RescueRoomDrugRecords.Select(c => new ItemRescueRoomDrugRecord(c)).OrderBy(c => c.PrescriptionTime).ThenBy(c => c.RescueRoomDrugRecordId).ToList();
            this.ListRescueRoomTreatmentRecord = target.RescueRoomInfo.RescueRoomTreatmentRecords.Select(c => new ItemRescueRoomTreatmentRecord(c)).OrderBy(c => c.PrescriptionTime).ThenBy(c => c.RescueRoomTreatmentRecordId).ToList();
        }





        public Guid GreenPathAmiId { get; set; }

        public int RescueRoomInfoId { get; set; }

        public bool IsHeldUp { get; set; }





        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }

        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        [Display(Name = "性别")]
        public string Sex { get; set; }

        [Display(Name = "就诊年龄")]
        public string ReceiveAgeName { get; set; }

        [Display(Name = "接诊时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? ReceiveTime { get; set; }

        [Display(Name = "首诊医师")]
        public string FirstDoctorName { get; set; }

        [Display(Name = "入室诊断")]
        public string DiagnosisNameOrigin { get; set; }





        [Display(Name = "发病时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? OccurrenceTime { get; set; }

        [Display(Name = "入室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InDepartmentTime { get; set; }

        [Display(Name = "床位")]
        public string BedNameFull { get; set; }

        [Display(Name = "入室方式")]
        public string InRescueRoomWayNameFull { get; set; }

        [Display(Name = "发病到入室")]
        public TimeSpan? DuringOccurrenceToInDepartment { get; set; }

        [Display(Name = "入室到接诊")]
        public TimeSpan? DuringInDepartmentToReceive { get; set; }

        [Display(Name = "首诊护士")]
        public string FirstNurseName { get; set; }





        [Display(Name = "危重等级")]
        public string CriticalLevelName { get; set; }

        [Display(Name = "抢救")]
        public string RescueResultNameFull { get; set; }

        [Display(Name = "首次心电图时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? EcgFirstTime { get; set; }

        [Display(Name = "再次心电图时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? EcgSecondTime { get; set; }

        [Display(Name = "入室到首次心电图")]
        public TimeSpan? DuringInDepartmentToEcgFirst { get; set; }

        [Display(Name = "入室到再次心电图")]
        public TimeSpan? DuringInDepartmentToEcgSecond { get; set; }





        [Display(Name = "完成通道时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? FinishPathTime { get; set; }

        [Display(Name = "离室时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? OutDepartmentTime { get; set; }

        [Display(Name = "滞留")]
        public string IsHeldUpString { get; set; }

        [Display(Name = "通道滞留时长")]
        public TimeSpan? DuringPathHeldUp { get; set; }

        [Display(Name = "通道停留时长")]
        public TimeSpan? During { get; set; }

        [Display(Name = "抢救室停留时长")]
        public TimeSpan? DuringOfRescueRoom { get; set; }

        [Display(Name = "连续滞留时长")]
        public TimeSpan DuringDetained { get; set; }

        [Display(Name = "去向")]
        public string DestinationNameFull { get; set; }

        [Display(Name = "存在问题")]
        public string Problem { get; set; }

        [Display(Name = "备注")]
        public string Remarks { get; set; }





        public List<ItemRescueRoomImageRecord> ListRescueRoomImageRecord { get; set; }

        public List<ItemRescueRoomConsultation> ListRescueRoomConsultation { get; set; }

        public List<ItemRescueRoomDrugRecord> ListRescueRoomDrugRecord { get; set; }

        public List<ItemRescueRoomTreatmentRecord> ListRescueRoomTreatmentRecord { get; set; }
    }
}