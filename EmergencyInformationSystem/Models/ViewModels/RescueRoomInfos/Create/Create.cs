using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Create
{
    /// <summary>
    /// 抢救室——新增1。
    /// </summary>
    public class Create : IValidatableObject
    {
        /// <summary>
        /// 初始化。
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





        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            var dbTrasen = new TrasenLib.TrasenDbContext("TrasenConnection");

            if (!dbTrasen.YY_KDJB.Any(c => c.KH == this.OutPatientNumber))
                result.Add(new ValidationResult("卡号不存在", new string[] { "OutPatientNumber" }));

            return result;
        }
    }
}