using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Prescription
{
    [Table("Prescription", Schema = "Prescription")]
    public class Prescription
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Days { get; set; }

        public virtual Examination.Examination Examination { get; set; }
        public virtual PrescriptionType PrescriptionType { get; set; }
        public virtual PrescriptionStatus PrescriptionStatus { get; set; }
    }
}
