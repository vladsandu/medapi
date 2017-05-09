using AutoMapper;
using BusinessEntities.Character;
using BusinessEntities.Staff;
using DataAccess.Entities.Character;
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
            });
        }
    }
}