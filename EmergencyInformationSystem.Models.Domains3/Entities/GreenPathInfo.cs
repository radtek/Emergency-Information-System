using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains3.Entities
{
    /// <summary>
    /// 绿色通道通用。
    /// </summary>
    /// <remarks>位于GeneralRoomInfo与具体绿色通道记录之间。</remarks>
    [Table("GreenPathInfos")]
    public class GreenPathInfo
    {
        public GreenPathInfo()
        {

        }





        [Key]
        public virtual Guid GreenPathInfoId { get; set; }





        [ForeignKey("GeneralRoomInfo")]
        [Index(IsUnique = true)]
        public virtual Guid GeneralRoomInfoId { get; set; }

        /// <summary>
        /// 实际记录ID。
        /// </summary>
        /// <remarks>不作为外键连接。通过GeneralRoomInfo的GreenPathCategory中的Code进行跳转。</remarks>
        [Index(IsUnique = true)]
        public virtual Guid GrennPathId { get; set; }

        /// <summary>
        /// 意义？
        /// </summary>
        [ForeignKey("GreenPathCategory")]
        public virtual Guid GreenPathCategoryId { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        public virtual GeneralRoomInfo GeneralRoomInfo { get; set; }

        public virtual GreenPathCategory GreenPathCategory { get; set; }
    }
}
