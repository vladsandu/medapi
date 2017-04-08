using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Staff
{
    [Table("PhysicianGrade", Schema = "Staff")]
    public class PhysicianGrade
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
