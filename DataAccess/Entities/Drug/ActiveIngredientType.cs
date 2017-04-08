using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Drug
{
    [Table("ActiveIngredientType", Schema = "Drug")]
    public class ActiveIngredientType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
