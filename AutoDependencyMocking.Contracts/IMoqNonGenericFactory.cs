using System;
using Moq;
using Ninject.Components;

namespace AutoDependencyMocking.Components
{
    public interface IMoqNonGenericFactory : INinjectComponent
    {
        Mock CreateMock(Type type);
    }
}