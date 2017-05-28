using System;
using BusinessEntities.Examination;

namespace BusinessEntities.Prescription {
    public class PrescriptionEntity {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Days { get; set; }

        public virtual ExaminationEntity Examination { get; set; }
        public virtual PrescriptionTypeEntity PrescriptionType { get; set; }
        public virtual PrescriptionStatusEntity PrescriptionStatus { get; set; }
    }
}