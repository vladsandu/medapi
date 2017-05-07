using System.Collections.Generic;
using BusinessEntities.Character;

namespace BusinessServices.Character {
    public interface IPatientServices {
        IEnumerable<PatientEntity> GetPatients(int medicId);
    }
}