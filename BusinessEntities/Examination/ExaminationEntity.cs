using System;
using BusinessEntities.Character;

namespace BusinessEntities.Examination
{
    public class ExaminationEntity {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public PatientEntity Patient { get; set; }
        public ExaminationTypeEntity ExaminationType { get; set; }
    }
}