using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;

namespace AutoDependencyMocking.Example
{
    [TestClass]
    public class UsageExampleTest
    {
        private IKernel kernel;

        [TestInitialize]
        public void TestInitialize()
        {
            kernel = new AutoDependencyMockingKernel();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            kernel.Dispose();
        }

        [TestMethod]
        public void SimpleCase()
        {
            var service = kernel.Get<MyService>();
            var dependency1 = kernel.Get<IDependency1>();
            Assert.AreEqual(dependency1, service.dependency1);

            var dependencyMock = kernel.Get<Mock<IDependency1>>();

            Assert.AreEqual(dependencyMock.Object, service.dependency1);

            Assert.AreEqual(null, service.PrintName1());

            dependencyMock.Setup(s => s.GetName()).Returns("Dependency1 Name");

            Assert.AreEqual("Dependency1 Name", service.PrintName1());
        }

        [TestMethod]
        public void SomeDependencyBinded()
        {
            kernel.Bind<IDependency1>().To<Dependency1>();

            var service = kernel.Get<MyService>();

            Assert.IsInstanceOfType(service.dependency1, typeof(Dependency1));
            Assert.AreEqual("Implementation 1", service.PrintName1());

            var dependency2Mock = kernel.Get<Mock<IDependency2>>();

            Assert.AreEqual(dependency2Mock.Object, service.dependency2);
        }

        [TestMethod]
        public void BindedAfterMock()
        {
            var dependency1 = kernel.Get<IDependency1>();
            var dependency1Mock = kernel.Get<Mock<IDependency1>>();

            Assert.AreEqual(dependency1, dependency1Mock.Object);

            kernel.Bind<IDependency1>().To<Dependency1>();

            dependency1 = kernel.Get<IDependency1>();

            Assert.IsInstanceOfType(dependency1, typeof(Dependency1));
        }

        public interface IDependency1
        {
            string GetName();
        }

        public interface IDependency2
        {
            string GetName();
        }

        public class Dependency1 : IDependency1
        {
            public string GetName()
            {
                return "Implementation 1";
            }
        }

        public class MyService
        {
            public readonly IDependency1 dependency1;
            public readonly IDependency2 dependency2;

            public MyService(IDependency1 dependency1, IDependency2 dependency2)
            {
                this.dependency1 = dependency1;
                this.dependency2 = dependency2;
            }

            public string PrintName1()
            {
                return dependency1.GetName();
            }

            public string PrintName2()
            {
                return dependency2.GetName();
            }
        }
    }
}
