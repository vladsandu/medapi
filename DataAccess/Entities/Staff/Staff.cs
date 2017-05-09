using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Entities.Character;

namespace DataAccess.Entities.Staff {
    [Table("Staff", Schema = "Staff")]
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public int ReferenceId { get; set; }
        public virtual StaffType StaffType { get; set; }
    }
}