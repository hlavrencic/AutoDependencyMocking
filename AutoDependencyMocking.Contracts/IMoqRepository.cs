using System;
using System.Collections.Generic;
using Moq;
using Ninject.Components;

namespace AutoDependencyMocking.Components
{
    public interface IMoqRepository : INinjectComponent
    {
        IDictionary<Type, Mock> Mocks { get; set; }

        Mock Get(Type type);
    }
}