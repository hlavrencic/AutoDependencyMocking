using System;
using Ninject.Activation;

namespace AutoDependencyMocking.Components.Providers
{
    internal class MockProvider : IProvider
    {
        private readonly IMoqRepository mockRepository;

        public Type Type { get; private set; }

        public MockProvider(Type type, IMoqRepository mockRepository)
        {
            Type = type;
            this.mockRepository = mockRepository;
        }

        public object Create(IContext context)
        {
            return mockRepository.Get(Type);
        }
    }
}