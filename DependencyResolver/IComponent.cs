namespace DependencyResolver {
    public interface IComponent
    {
        void SetUp(IRegisterComponent registerComponent);
    }
}