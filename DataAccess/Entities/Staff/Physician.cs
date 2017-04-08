using DataAccess.Entities.Character;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Staff
{
    [Table("Physician", Schema = "Staff")]
    public class Physician
    {
        [Key]
        public int Id { get; set; }

        public virtual Person Person { get; set; }
        public virtual PhysicianGrade PhysicianGrade { get; set; }
        public virtual MedicalField MedicalField { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
