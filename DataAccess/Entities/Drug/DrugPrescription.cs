using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Drug
{
    [Table("DrugPrescription", Schema = "Drug")]
    public class DrugPrescription
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int CostCoveragePercentage { get; set; }

        public virtual Drug Drug { get; set; }
        public virtual Prescription.Prescription Prescription { get; set; }
        public virtual Diagnosis.Diagnosis Diagnosis { get; set; }
        public virtual AdministrationSchema AdministrationSchema { get; set; }
    }
}
