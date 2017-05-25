using System;
using BusinessEntities.Examination;

namespace BusinessEntities.Diagnosis {
    public class DiagnosisEntity {
        public int Id { get; set; }
        public DateTime? EndDate { get; set; }
        public string Observations { get; set; }
        public virtual ConditionEntity Condition { get; set; }
        public virtual ExaminationEntity Examination { get; set; }
    }
}