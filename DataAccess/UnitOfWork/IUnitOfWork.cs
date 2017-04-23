using DataAccess.Entities;
using DataAccess.Entities.Character;
using DataAccess.Entities.Contact;
using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Properties
        GenericRepository<Person> PersonRepository { get; }
        GenericRepository<InsuranceStatus> InsuranceStatusRepository { get; }
        GenericRepository<Nationality> NationalityRepository { get; }

        GenericRepository<City> CityRepository { get; }
        GenericRepository<Country> CountryRepository { get; }
        GenericRepository<ContactDetails> ContactDetailsRepository { get; }
        #endregion

        #region Public methods
        /// <summary>
        /// Save method.
        /// </summary>
        void Save();
        #endregion 
    }
}