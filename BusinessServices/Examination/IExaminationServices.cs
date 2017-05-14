using System.Collections.Generic;
using BusinessEntities.Examination;

namespace BusinessServices.Examination {
    public interface IExaminationServices {
        List<ExaminationEntity> GetExaminationsForPatient(int patientId);
        List<ExaminationEntity> GetExaminationsForMedic(int medicId);
        List<ExaminationTypeEntity> GetExaminationTypes();
        ExaminationEntity AddExaminationForPatient(int patientId, string examinationTypeName);
    }
}