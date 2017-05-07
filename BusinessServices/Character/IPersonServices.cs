using BusinessEntities.Character;

namespace BusinessServices.Character {
    public interface IPersonServices : IGenericServices<PersonEntity> {
        PersonEntity GetItemByCnp(string cnp);
    }
}