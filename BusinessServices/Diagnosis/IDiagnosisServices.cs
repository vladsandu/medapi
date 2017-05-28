using System.Collections.Generic;
using BusinessEntities.Diagnosis;

namespace BusinessServices.Diagnosis {
    public interface IDiagnosisServices {
        DiagnosisEntity AddDiagnosis(DiagnosisAddRequest diagnosisAddRequest);
        List<DiagnosisEntity> GetDiagnosticsForExamination(int examinationId);
        List<DiagnosisEntity> GetDiagnosticsForPatient(int patientId);
    }
}