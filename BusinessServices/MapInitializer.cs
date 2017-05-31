using AutoMapper;
using BusinessEntities.Character;
using BusinessEntities.Diagnosis;
using BusinessEntities.Examination;
using BusinessEntities.Prescription;
using BusinessEntities.Staff;
using DataAccess.Entities.Center;
using DataAccess.Entities.Character;
using DataAccess.Entities.Examination;
using DataAccess.Entities.Staff;

namespace BusinessServices {
    public class MapInitializer {
        public void Initialize()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Person, PersonEntity>();
                cfg.CreateMap<Patient, PatientEntity>();
                cfg.CreateMap<DataAccess.Entities.Staff.Staff, StaffEntity>();
                cfg.CreateMap<StaffType, StaffTypeEntity>();
                cfg.CreateMap<DataAccess.Entities.Examination.Examination, ExaminationEntity>();
                cfg.CreateMap<ExaminationType, ExaminationTypeEntity>();
                cfg.CreateMap<DataAccess.Entities.Diagnosis.Condition, ConditionEntity>();
                cfg.CreateMap<DataAccess.Entities.Diagnosis.ConditionCategory, ConditionCategoryEntity>();
                cfg.CreateMap<DataAccess.Entities.Diagnosis.DiagnosisType, DiagnosisTypeEntity>();
                cfg.CreateMap<DataAccess.Entities.Prescription.Prescription, PrescriptionEntity>();
                cfg.CreateMap<DataAccess.Entities.Diagnosis.Diagnosis, DiagnosisEntity>();
                cfg.CreateMap<Physician, PhysicianEntity>();
                cfg.CreateMap<MedicalCenter, MedicalCenterEntity>();
            });
        }
    }
}