using DataAccess.Entities.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Drug
{
    [Table("Brand", Schema = "Drug")]
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ContactDetails ContactDetails { get; set; }
    }
}
