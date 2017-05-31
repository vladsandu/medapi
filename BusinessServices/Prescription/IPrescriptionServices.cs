using BusinessEntities.Prescription;

namespace BusinessServices.Prescription {
    public interface IPrescriptionServices {
        PrescriptionEntity AddPrescriptionForExamination(PrescriptionAddRequest prescriptionRequest);
    }
}