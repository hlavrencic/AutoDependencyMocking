using AutoDependencyMocking.DummyMock.Tests.ContractsExamples;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace AutoDependencyMocking.DummyMock.Tests
{
    [TestClass]
    public class DummyMockDepenciesTest
    {
        [TestMethod]
        public void MakeDummyServiceDependencies()
        {
            using (var kernel = new AutoDependencyDummyKernel())
            {
                var serviceDummie = kernel.Get<IService>();
                var controller = kernel.Get<ControllerExample>();

                var resultado = controller.GetResult();

                Assert.AreEqual(serviceDummie.ServiceMethod1(string.Empty), resultado);
            }
        }
    }
}
