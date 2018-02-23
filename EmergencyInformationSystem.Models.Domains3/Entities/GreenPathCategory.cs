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
    /// 绿色通道类型。
    /// </summary>
    [Table("GreenPathCategories")]
    public class GreenPathCategory
    {
        public GreenPathCategory()
        {

        }





        [Key]
        public virtual Guid GreenPathCategoryId { get; set; }





        [Required(AllowEmptyStrings = false)]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public virtual string GreenPathCategoryName { get; set; }

        public virtual int Priority { get; set; }





        public virtual bool IsHasAdditionalInfo { get; set; }

        /// <summary>
        /// 是否拥有独立表格。
        /// </summary>
        public virtual bool IsHasForm { get; set; }





        /// <summary>
        /// 编码名称。
        /// </summary>
        /// <remarks>程序内使用。</remarks>
        public virtual string CodeName { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }
    }
}