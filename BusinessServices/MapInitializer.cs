using AutoMapper;
using BusinessEntities.Character;
using DataAccess.Entities.Character;

namespace BusinessServices {
    public class MapInitializer {
        public void Initialize()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Nationality, NationalityEntity>();
                cfg.CreateMap<NationalityEntity, Nationality>();
            });
        }
    }
}