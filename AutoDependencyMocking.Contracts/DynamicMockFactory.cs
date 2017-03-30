using System;
using Moq;
using Ninject;

namespace AutoDependencyMocking.Components
{
    public class DynamicMockFactory : IDynamicMockFactory
    {
        private readonly IMoqNonGenericFactory moqNonGenericFactory;
        public DynamicMockFactory(IMoqNonGenericFactory moqNonGenericFactory)
        {
            this.moqNonGenericFactory = moqNonGenericFactory;
        }

        public Mock DynamicMock(Type type)
        {
            return moqNonGenericFactory.CreateMock(type);
        }

        public void Dispose()
        {
        }

        public INinjectSettings Settings { get; set; }
    }
}
