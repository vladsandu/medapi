using System;

namespace BusinessEntities.Character {
    public class PatientEntity {
        public int? Id { get; set; }
        public PersonEntity Person { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}