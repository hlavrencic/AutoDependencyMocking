using DummyMock;
using Moq;
using Ninject;

namespace AutoDependencyMocking.DummyMock.Components
{
    public class DummySetter : IDummySetter
    {
        private readonly DummyMockFactory dummyMockFactory;

        public DummySetter()
        {
            dummyMockFactory = new DummyMockFactory();
        }

        public void Dispose()
        {
        }

        public INinjectSettings Settings { get; set; }
        public void SetupMethodDummies<T>(Mock<T> dynamicMock) where T : class
        {
            dummyMockFactory.SetupMethodDummies(dynamicMock);
        }
    }
}