namespace BusinessEntities.Diagnosis {
    public class DiagnosisAddRequest {
        public int ExaminationId { get; set; }
        public int ConditionId { get; set; }
        public string Observations { get; set; }
    }
}