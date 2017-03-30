using Moq;
using Ninject.Components;

namespace AutoDependencyMocking.DummyMock.IFactories
{
    public interface IDummySetter : INinjectComponent
    {
        void SetupMethodDummies<T>(Mock<T> dynamicMock) where T : class;
    }
}
