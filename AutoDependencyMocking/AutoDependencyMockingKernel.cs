using AutoDependencyMocking.Components;
using Ninject;
using Ninject.Planning.Bindings.Resolvers;

namespace AutoDependencyMocking
{
    public class AutoDependencyMockingKernel : StandardKernel
    {
        protected override void AddComponents()
        {
            base.AddComponents();
            Components.Add<IMissingBindingResolver, MocksBindingResolver>();
            Components.Add<IBindingResolver, MocksBindingResolver>();
            Components.Add<IMoqRepository, MoqRepository>();
        }

    }
}
