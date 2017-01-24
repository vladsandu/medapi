using DataAccess.Entities;
using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Properties
        GenericRepository<Person> PersonRepository { get; }
        #endregion

        #region Public methods
        /// <summary>
        /// Save method.
        /// </summary>
        void Save();
        #endregion 
    }
}