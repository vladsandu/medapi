using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Diagnosis
{
    [Table("Condition", Schema = "Diagnosis")]
    public class Condition
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ConditionCategory ConditionCategory { get; set; }
        public virtual DiagnosisType Type { get; set; }
    }
}
