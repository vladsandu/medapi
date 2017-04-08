using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Drug
{
    [Table("ActiveIngredient", Schema = "Drug")]
    public class ActiveIngredient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ActiveIngredientType ActiveIngredientType { get; set; }
    }
}
