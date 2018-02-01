using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains2.Entities
{
    public class GreenPathAmiInfo
    {
        public GreenPathAmiInfo()
        {

        }





        [Key]
        public virtual Guid GreenPathAmiId { get; set; }

        [ForeignKey("GeneralRoomInfo")]
        [Index(IsUnique = true)]
        public virtual Guid GeneralRoomInfoId { get; set; }





        public virtual DateTime? OccurrenceTime { get; set; }





        public virtual DateTime? EcgFirstTime { get; set; }

        public virtual DateTime? EcgSecondTime { get; set; }

        public virtual string Remarks { get; set; }





        public virtual DateTime? FinishPathTime { get; set; }

        public virtual bool IsHeldUp { get; set; }

        public virtual string Problem { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        public virtual GeneralRoomInfo GeneralRoomInfo { get; set; }





        public TimeSpan? DuringOccurrenceToInDepartment
        {
            get
            {
                if (this.OccurrenceTime.HasValue)
                    return this.GeneralRoomInfo.InDepartmentTime - this.OccurrenceTime;
                else
                    return null;
            }
        }

        public TimeSpan? DuringInDepartmentToReceive
        {
            get
            {
                if (this.GeneralRoomInfo.ReceiveTime.HasValue)
                    return this.GeneralRoomInfo.ReceiveTime - this.GeneralRoomInfo.InDepartmentTime;
                else
                    return null;
            }
        }

        public TimeSpan? DuringInDepartmentToEcgFirst
        {
            get
            {
                if (this.EcgFirstTime.HasValue)
                    return this.EcgFirstTime - this.GeneralRoomInfo.InDepartmentTime;
                else
                    return null;
            }
        }

        public TimeSpan? DuringInDepartmentToEcgSecond
        {
            get
            {
                if (this.EcgSecondTime.HasValue)
                    return this.EcgSecondTime - this.GeneralRoomInfo.InDepartmentTime;
                else
                    return null;
            }
        }

        public TimeSpan? During
        {
            get
            {
                if (this.FinishPathTime != null)
                    return this.FinishPathTime - this.GeneralRoomInfo.InDepartmentTime;
                else
                    return null;
            }
        }

        public bool IsFinished
        {
            get
            {
                return this.FinishPathTime.HasValue;
            }
        }

        public string IsHeldUpString
        {
            get
            {
                return this.IsHeldUp ? "是" : "否";
            }
        }

        public TimeSpan? DuringPathHeldUp
        {
            get
            {
                return this.GeneralRoomInfo.OutDepartmentTime - this.FinishPathTime;
            }
        }
    }
}
