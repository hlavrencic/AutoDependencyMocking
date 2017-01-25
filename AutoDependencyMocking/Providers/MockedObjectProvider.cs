using System;
using AutoDependencyMocking.Components;
using Ninject.Activation;

namespace AutoDependencyMocking.Providers
{
    public class MockedObjectProvider : IProvider
    {
        private readonly IMoqRepository mockRepository;

        public Type Type { get; private set; }

        public MockedObjectProvider(Type type, IMoqRepository mockRepository)
        {
            Type = type;
            this.mockRepository = mockRepository;
        }

        public object Create(IContext context)
        {
            return mockRepository.Get(Type).Object;
        }
    }
}