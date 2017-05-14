using DataAccess.Entities.Center;
using DataAccess.Entities.Character;
using DataAccess.Entities.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Character
{
    [Table("Patient", Schema = "Character")]
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Person Person { get; set; }
        public virtual Physician Physician { get; set; }
    }
}
