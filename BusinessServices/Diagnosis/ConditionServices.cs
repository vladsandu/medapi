using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Diagnosis;
using DataAccess.UnitOfWork;

namespace BusinessServices.Diagnosis {
    public class ConditionServices : IConditionServices{
        private readonly IUnitOfWork _unitOfWork;

        public ConditionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<ConditionEntity> GetConditions()
        {
            var conditions = _unitOfWork.ConditionRepository.GetAll();
            return conditions?.Select(Mapper.Map<DataAccess.Entities.Diagnosis.Condition, ConditionEntity>).ToList();
        }
    }
}