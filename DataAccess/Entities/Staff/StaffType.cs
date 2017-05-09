using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Entities.Character;

namespace DataAccess.Entities.Staff {
    [Table("StaffType", Schema = "Staff")]
    public class StaffType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}