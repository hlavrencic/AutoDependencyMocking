using System;
using Moq;
using Ninject;

namespace AutoDependencyMocking.Components
{
    public class MoqNonGenericFactory : IMoqNonGenericFactory
    {
        public Mock CreateMock(Type type)
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
        }

        public INinjectSettings Settings { get; set; }
    }
}
