using BusinessEntities.Character;

namespace BusinessServices.Character {
    public interface IPersonServices {
        PersonEntity GetPersonByCnp(string cnp);
    }
}