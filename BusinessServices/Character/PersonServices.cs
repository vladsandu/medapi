using System.Collections.Generic;
using AutoMapper;
using BusinessEntities.Character;
using DataAccess.Entities.Character;
using DataAccess.UnitOfWork;

namespace BusinessServices.Character {
    public class PersonServices : IPersonServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PersonEntity GetPersonByCnp(string cnp)
        {
            var person = _unitOfWork.PersonRepository.Get(newPerson => newPerson.Cnp.Equals(cnp));
            if (person != null)
            {
                var personEntity = Mapper.Map<Person, PersonEntity>(person);
                return personEntity;
            }
            return null;
        }

        public PersonEntity GetItemById(int itemId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PersonEntity> GetAllItems()
        {
            throw new System.NotImplementedException();
        }

        public int CreateItem(PersonEntity item)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateItem(int itemId, PersonEntity newItem)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteItem(int itemId)
        {
            throw new System.NotImplementedException();
        }
    }
}