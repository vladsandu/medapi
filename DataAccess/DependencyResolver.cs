using System.ComponentModel.Composition;
using DataAccess.UnitOfWork;
using DependencyResolver;

namespace DataAccess
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}