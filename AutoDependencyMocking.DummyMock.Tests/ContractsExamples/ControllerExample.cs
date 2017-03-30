using System.Collections.Generic;

namespace AutoDependencyMocking.DummyMock.Tests.ContractsExamples
{
    public class ControllerExample
    {
        private readonly IService service;

        public ControllerExample(IService service)
        {
            this.service = service;
        }

        public IList<ServiceDataContract> GetResult()
        {
            return service.ServiceMethod1("14453564");
        }
    }
}
