using System;
using System.ComponentModel.DataAnnotations;
using DataAccess.Entities.Contact;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessEntities.Character;

namespace DataAccess.Entities.Character
{
    [Table("Person", Schema = "Character")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Cnp { get; set; }
        public Sex Sex { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }

        public virtual InsuranceStatus InsuranceStatus { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual ContactDetails ContactDetails { get; set; }
    }
}