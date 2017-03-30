using AutoDependencyMocking.Components;
using AutoDependencyMocking.DummyMock.Components;
using DummyMock;
using Ninject;
using Ninject.Planning.Bindings.Resolvers;

namespace AutoDependencyMocking.DummyMock
{
    public class AutoDependencyDummyKernel : StandardKernel
    {
        protected override void AddComponents()
        {
            base.AddComponents();
            Components.Add<IMissingBindingResolver, MocksBindingResolver>();
            Components.Add<IBindingResolver, MocksBindingResolver>();
            Components.Add<IMoqRepository, MoqRepository>();
            Components.Add<IDynamicMockFactory, MoqDummyFactory>();
            Components.Add<IDynamicMockFactory, DynamicMockFactory>();
            Components.Add<IMoqNonGenericFactory, MoqNonGenericFactory>();
            Components.Add<IDummySetter, DummySetter>();
        }
    }
}
