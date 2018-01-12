using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// 抢救室会诊项。
    /// </summary>
    /// <remarks>表示抢救室病例的会诊信息。</remarks>
    [Table("RescueRoomConsultations")]
    public class RescueRoomConsultation
    {
        #region 构建

        /// <summary>
        /// 初始化实例<see cref="RescueRoomConsultation"/>。
        /// </summary>
        public RescueRoomConsultation()
        {
        }

        #endregion





        #region 实体属性

        /// <summary>
        /// 抢救室会诊项ID。
        /// </summary>
        [Key]
        public virtual Guid RescueRoomConsultationId { get; set; }





        /// <summary>
        /// 归属的抢救室病例ID。
        /// </summary>
        [ForeignKey("RescueRoomInfo")]
        public virtual Guid RescueRoomInfoId { get; set; }





        /// <summary>
        /// 申请时间。
        /// </summary>
        //[Display(Name = "申请时间")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public virtual DateTime RequestTime { get; set; }

        /// <summary>
        /// 到达时间。
        /// </summary>
        //[Display(Name = "到达时间")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public virtual DateTime? ArriveTime { get; set; }

        /// <summary>
        /// 会诊医师姓名。
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        //[Display(Name = "会诊医师")]
        public virtual string ConsultationDoctorName { get; set; }

        /// <summary>
        /// 会诊科室ID——去向ID。
        /// </summary>
        /// <remarks>关联“去向”。</remarks>
        [ForeignKey("ConsultationDepartment")]
        //[Display(Name = "会诊科室")]
        public virtual Guid ConsultationDepartmentId { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }

        #endregion





        #region 导航属性

        /// <summary>
        /// 归属的抢救室病例。
        /// </summary>
        public virtual RescueRoomInfo RescueRoomInfo { get; set; }

        /// <summary>
        /// 会诊科室——去向。
        /// </summary>
        public virtual Destination ConsultationDepartment { get; set; }

        #endregion




        
        #region 实例属性

        /// <summary>
        /// 会诊科室名称——去向名称。
        /// </summary>
        //[Display(Name = "会诊科室")]
        public string ConsultationDepartmentName
        {
            get
            {
                return this.ConsultationDepartment.DestinationName;
            }
        }

        /// <summary>
        /// 申请到到达会诊时长。
        /// </summary>
        //[Display(Name = "申请到到达")]
        public TimeSpan? DuringRequestToArrive
        {
            get
            {
                return this.ArriveTime - this.RequestTime;
            }
        }

        #endregion
    }
}