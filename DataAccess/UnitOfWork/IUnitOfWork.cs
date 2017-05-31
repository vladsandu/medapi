using BusinessEntities.Diagnosis;
using DataAccess.Entities;
using DataAccess.Entities.Character;
using DataAccess.Entities.Contact;
using DataAccess.Entities.Diagnosis;
using DataAccess.Entities.Examination;
using DataAccess.Entities.Prescription;
using DataAccess.Entities.Staff;
using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Properties
        GenericRepository<Person> PersonRepository { get; }
        GenericRepository<InsuranceStatus> InsuranceStatusRepository { get; }
        GenericRepository<Nationality> NationalityRepository { get; }
        GenericRepository<Patient> PatientRepository { get; }

        GenericRepository<City> CityRepository { get; }
        GenericRepository<Country> CountryRepository { get; }
        GenericRepository<ContactDetails> ContactDetailsRepository { get; }
        GenericRepository<Examination> ExaminationRepository { get; }
        GenericRepository<Staff> StaffRepository { get; }
        GenericRepository<Physician> PhysicianRepository { get; }
        GenericRepository<ExaminationType> ExaminationTypeRepository { get; }
        GenericRepository<Diagnosis> DiagnosisRepository { get; }
        GenericRepository<Condition> ConditionRepository { get; }

        GenericRepository<Prescription> PrescriptionRepository { get; }
        GenericRepository<PrescriptionType> PrescriptionTypeRepository { get; }
        GenericRepository<PrescriptionStatus> PrescriptionStatusRepository { get; }

        #endregion

        #region Public methods
        /// <summary>
        /// Save method.
        /// </summary>
        void Save();
        #endregion 
    }
}