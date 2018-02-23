﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos2.Create
{
    public class Create : IValidatableObject
    {
        public Create()
        {

        }





        [Required(AllowEmptyStrings = false)]
        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }





        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            var dbTrasen = new TrasenLib.TrasenDbContext("TrasenConnection");

            //1.检测卡号存在。
            if (!dbTrasen.YY_KDJB.Any(c => c.KH == this.OutPatientNumber))
                result.Add(new ValidationResult("卡号不存在", new string[] { "OutPatientNumber" }));

            return result;
        }
    }
}