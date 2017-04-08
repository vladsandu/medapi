using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Drug
{
    [Table("Drug", Schema = "Drug")]
    public class Drug
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dose { get; set; }
        public bool Fractionable { get; set; }
        public double Cost { get; set; }
        public int CostCoveragePercentage { get; set; }

        public virtual ActiveIngredient ActiveIngredient { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual AdministrationType AdministrationType { get; set; }
    }
}
