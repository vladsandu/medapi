namespace BusinessEntities.Prescription {
    public class PrescriptionAddRequest {
        public int Days { get; set; }
        public int ExaminationId { get; set; }
        public string PrescriptionType { get; set; }
        public string PrescriptionStatus { get; set; }
    }
}