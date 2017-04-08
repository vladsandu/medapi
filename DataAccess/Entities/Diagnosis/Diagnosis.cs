using DataAccess.Entities.Character;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Diagnosis
{
    [Table("Diagnosis", Schema = "Diagnosis")]
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Observations { get; set; }

        public virtual Condition Condition { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
