using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using BusinessEntities.Character;
using DataAccess.Entities.Character;
using DataAccess.UnitOfWork;

namespace BusinessServices {
    public class NationalityServices : IGenericServices<NationalityEntity> {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Public constructor.
        /// </summary>
        public NationalityServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public NationalityEntity GetItemById(int itemId)
        {
            var nationality = _unitOfWork.NationalityRepository.GetByID(itemId);
            if (nationality != null)
            {
                var nationalityModel = Mapper.Map<Nationality, NationalityEntity>(nationality);
                return nationalityModel;
            }
            return null;
        }

        public IEnumerable<NationalityEntity> GetAllItems()
        {
            var nationalities = _unitOfWork.NationalityRepository.GetAll().ToList();
            if (nationalities.Any())
            {
                var nationalitiesModel = Mapper.Map<List<Nationality>, List<NationalityEntity>>(nationalities);
                return nationalitiesModel;
            }
            return null;
        }

        public int CreateItem(NationalityEntity item)
        {
            using (var scope = new TransactionScope())
            {
                var nationality = Mapper.Map<NationalityEntity, Nationality>(item);
                _unitOfWork.NationalityRepository.Insert(nationality);
                _unitOfWork.Save();
                scope.Complete();
                return nationality.Id;
            }
        }

        public bool UpdateItem(int itemId, NationalityEntity newItem)
        {
            var success = false;
            if (newItem != null)
            {
                using (var scope = new TransactionScope())
                {
                    var nationality = _unitOfWork.NationalityRepository.GetByID(itemId);
                    if (nationality != null)
                    {
                        nationality.Name = newItem.Name;
                        nationality.Code = newItem.Code;
                        _unitOfWork.NationalityRepository.Update(nationality);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;

        }

        public bool DeleteItem(int itemId)
        {
            var success = false;
            if (itemId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var nationality = _unitOfWork.NationalityRepository.GetByID(itemId);
                    if (nationality != null)
                    {
                        _unitOfWork.NationalityRepository.Delete(nationality);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}