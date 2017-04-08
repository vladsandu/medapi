using System;
using DataAccess.Entities.Contact;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities.Character
{
    [Table("InsuranceStatus", Schema = "Character")]
    public class Person
    {
        public int Id { get; set; }
        public int InsuranceStatusId { get; set; }
        public int NationalityId { get; set; }
        public int ContactDetailsId { get; set; }

        public int Cnp { get; set; }
        public byte Sex { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }

        public virtual InsuranceStatus InsuranceStatus { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual ContactDetails ContactDetails { get; set; }
    }
}