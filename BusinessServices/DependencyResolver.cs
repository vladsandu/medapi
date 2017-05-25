using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Character;
using BusinessServices.Character;
using BusinessServices.Diagnosis;
using BusinessServices.Examination;
using BusinessServices.Staff;
using DependencyResolver;

namespace BusinessServices
{
    [Export(typeof(IComponent))]
    class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IPersonServices, PersonServices>();
            registerComponent.RegisterType<IPatientServices, PatientServices>();
            registerComponent.RegisterType<IExaminationServices, ExaminationServices>();
            registerComponent.RegisterType<IConditionServices, ConditionServices>();
            registerComponent.RegisterType<IDiagnosisServices, DiagnosisServices>();
            registerComponent.RegisterType<IStaffServices, StaffServices>();
        }
    }
}
