using System;
using Moq;
using Ninject.Components;

namespace AutoDependencyMocking.Components
{
    public interface IDynamicMockFactory : INinjectComponent
    {
        Mock DynamicMock(Type type);
    }
}