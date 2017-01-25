using System;
using System.Collections.Generic;
using Moq;
using Ninject;

namespace AutoDependencyMocking.Components
{
    public class MoqRepository : IMoqRepository
    {
        public IDictionary<Type, Mock> Mocks { get; set; }

        public MoqRepository()
        {
            Mocks = new Dictionary<Type, Mock>();
        }

        public Mock Get(Type type)
        {
            Mock mock;
            if (!Mocks.TryGetValue(type, out mock))
            {
                mock = DynamicMock(type);
                Mocks.Add(type, mock);
            }

            return mock;
        }

        private static Mock DynamicMock(Type type)
        {
            var constructorInfo = typeof(Mock<>).MakeGenericType(type).GetConstructor(Type.EmptyTypes);
            if (constructorInfo != null)
            {
                return (Mock)constructorInfo.Invoke(new object[] { });
            }

            throw new NotSupportedException("No se pudo obtener el contructor de Mock");
        }

        public void Dispose()
        {
            Mocks.Clear();
        }

        public INinjectSettings Settings { get; set; }
    }
}