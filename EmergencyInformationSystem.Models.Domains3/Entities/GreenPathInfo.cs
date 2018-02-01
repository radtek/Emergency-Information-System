using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains3.Entities
{
    [Table("GreenPathInfos")]
    public class GreenPathInfo
    {
        public GreenPathInfo()
        {

        }





        [Key]
        public virtual Guid GreenPathInfoId { get; set; }





        [Index(IsUnique = true)]
        public virtual Guid GeneralRoomInfoId { get; set; }

        /// <summary>
        /// 实际记录ID。
        /// </summary>
        [Index(IsUnique = true)]
        public virtual Guid GrennPathId { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        public virtual GeneralRoomInfo GeneralRoomInfo { get; set; }
    }
}
