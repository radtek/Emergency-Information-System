using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomImageRecords.IndexPartial
{
    public class Item
    {
        public Item(Domains.Entities.RescueRoomImageRecord target)
        {
            this.RescueRoomImageRecordId = target.RescueRoomImageRecordId;

            this.BookTime = target.BookTime;
            this.CheckTime = target.CheckTime;
            this.ReportTime = target.ReportTime;
            this.Part = target.Part;
            this.Category = target.Category;
            this.ImageCategoryName = target.ImageCategory.ImageCategoryName;
        }





        public Guid RescueRoomImageRecordId { get; set; }





        [Display(Name = "登记时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? BookTime { get; set; }

        [Display(Name = "检查时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? CheckTime { get; set; }

        [Display(Name = "报告时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? ReportTime { get; set; }

        [Display(Name = "检查部位")]
        public string Part { get; set; }

        [Display(Name = "检查项目")]
        public string Category { get; set; }

        [Display(Name = "检查类别")]
        public string ImageCategoryName { get; set; }
    }
}