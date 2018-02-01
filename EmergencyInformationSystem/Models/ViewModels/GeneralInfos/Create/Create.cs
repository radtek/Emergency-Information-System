using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.GeneralInfos.Create
{
    public class Create : IValidatableObject
    {
        public Create()
        {

        }





        private Guid roomId;
        public Guid RoomId
        {
            get { return this.roomId; }
            set
            {
                this.roomId = value;
                this.GetData();
            }
        }

        public string RoomName { get; set; }





        [Required(AllowEmptyStrings = false)]
        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }





        public void GetData()
        {
            var db3 = new Domains3.Entities.EiSDbContext();
            var room = db3.Rooms.Find(this.RoomId);
            this.RoomName = room.RoomName;
        }





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