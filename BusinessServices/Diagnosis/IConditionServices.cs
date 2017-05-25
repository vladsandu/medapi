using System.Collections.Generic;
using BusinessEntities.Diagnosis;

namespace BusinessServices.Diagnosis {
    public interface IConditionServices {
        List<ConditionEntity> GetConditions();
    }
}