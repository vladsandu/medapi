using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Drug
{
    [Table("AdministrationSchema", Schema = "Drug")]
    public class AdministrationSchema
    {
        [Key]
        public int Id { get; set; }
        public string Schema { get; set; }
    }
}
