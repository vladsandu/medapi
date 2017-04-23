using System;

namespace BusinessEntities.Character {
    public class PersonEntity {
        public int Id { get; set; }
        public int Cnp { get; set; }
        public byte Sex { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
    }
}