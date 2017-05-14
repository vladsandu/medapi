using BusinessEntities.Character;

namespace BusinessServices.Character {
    public interface IPersonServices : IGenericServices<PersonEntity> {
        PersonEntity GetPersonByCnp(string cnp);
    }
}