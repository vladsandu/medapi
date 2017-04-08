using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Examination
{
    [Table("Observation", Schema = "Examination")]
    public class Observation
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }

        public virtual Examination Examination { get; set; }
        public virtual ObservationType ObservationType { get; set; }
    }
}
