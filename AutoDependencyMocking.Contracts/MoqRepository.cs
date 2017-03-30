using System;
using System.Collections.Generic;
using Moq;
using Ninject;

namespace AutoDependencyMocking.Components
{
    public class MoqRepository : IMoqRepository
    {
        private readonly IDynamicMockFactory moqFactory;
        public IDictionary<Type, Mock> Mocks { get; set; }

        public MoqRepository(IDynamicMockFactory moqFactory)
        {
            this.moqFactory = moqFactory;
            Mocks = new Dictionary<Type, Mock>();
        }

        public Mock Get(Type type)
        {
            Mock mock;
            if (!Mocks.TryGetValue(type, out mock))
            {
                mock = moqFactory.DynamicMock(type);
                Mocks.Add(type, mock);
            }

            return mock;
        }

        public void Dispose()
        {
            Mocks.Clear();
        }

        public INinjectSettings Settings { get; set; }
    }
}