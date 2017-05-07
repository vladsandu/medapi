using System;

namespace BusinessEntities.Character {
    public class PersonEntity {
        public string Cnp { get; set; }
        public Sex Sex { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string InsuranceStatus { get; set; }
        public string Nationality { get; set; }
    }
}