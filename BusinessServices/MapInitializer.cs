using AutoMapper;
using BusinessEntities.Character;
using BusinessEntities.Examination;
using BusinessEntities.Staff;
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
            });
        }
    }
}