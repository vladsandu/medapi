using DataAccess.Entities.Character;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Examination
{
    [Table("Examination", Schema = "Examination")]
    public class Examination
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual ExaminationType ExaminationType { get; set; }
    }
}
