using System;
using AutoDependencyMocking.Components;
using Moq;
using Ninject;

namespace AutoDependencyMocking.DummyMock.Components
{
    public class MoqDummyFactory : IDynamicMockFactory
    {
        private readonly IDummySetter dummySetter;
        private readonly IMoqNonGenericFactory moqFactory;

        public MoqDummyFactory(IDummySetter dummySetter, IMoqNonGenericFactory moqFactory)
        {
            this.dummySetter = dummySetter;
            this.moqFactory = moqFactory;
        }

        public Mock DynamicMock(Type type)
        {
            var mock = moqFactory.CreateMock(type);
            var methodInfo = typeof (IDummySetter).GetMethod("SetupMethodDummies");
            methodInfo = methodInfo.MakeGenericMethod(type);
            methodInfo.Invoke(dummySetter, new object[] {mock});
            return mock;
        }

        public void Dispose()
        {
        }

        public INinjectSettings Settings { get; set; }
    }
}
