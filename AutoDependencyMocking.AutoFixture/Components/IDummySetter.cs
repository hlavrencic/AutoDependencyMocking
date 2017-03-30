using Moq;
using Ninject.Components;

namespace AutoDependencyMocking.DummyMock.Components
{
    public interface IDummySetter : INinjectComponent
    {
        void SetupMethodDummies<T>(Mock<T> dynamicMock) where T : class;
    }
}
