using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyInformationSystem.Models.Domains2.Entities
{
    [Table("DrugRecordDefinitions")]
    public class DrugRecordDefinition
    {
        public DrugRecordDefinition()
        {

        }





        [Key]
        public virtual Guid DrugRecordDefinitionId { get; set; }

        [ForeignKey("GreenPathCategory")]
        public virtual Guid GreenPathCategoryId { get; set; }





        public virtual string DrugCode { get; set; }

        public virtual string DrugName { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }

        public virtual DateTime UpdateTime { get; set; }





        public virtual GreenPathCategory GreenPathCategory { get; set; }
    }
}
