using System.Collections.Generic;

namespace AutoDependencyMocking.DummyMock.Tests.ContractsExamples
{
    public interface IService
    {
        IList<ServiceDataContract> ServiceMethod1(string param1);
    }
}
