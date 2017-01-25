using System;
using System.Collections.Generic;
using System.Linq;
using AutoDependencyMocking.Providers;
using Moq;
using Ninject;
using Ninject.Activation;
using Ninject.Infrastructure;
using Ninject.Planning.Bindings;
using Ninject.Planning.Bindings.Resolvers;

namespace AutoDependencyMocking.Components
{
    public class MocksBindingResolver : IBindingResolver, IMissingBindingResolver
    {
        private readonly IMoqRepository moqRepository;

        public MocksBindingResolver(IMoqRepository moqRepository)
        {
            this.moqRepository = moqRepository;
        }

        public void Dispose()
        {
        }

        public INinjectSettings Settings { get; set; }

        public IEnumerable<IBinding> Resolve(Multimap<Type, IBinding> bindings, Type service)
        {
            if (!typeof(Mock).IsAssignableFrom(service) || !service.GetGenericArguments().Any() || bindings.Any(b => b.Key == service && b.Value.Count > 0))
            {
                return Enumerable.Empty<IBinding>();
            }

            var type = service.GetGenericArguments()[0];
            return new IBinding[]
            {
                new Binding(service)
                {
                    ProviderCallback = context => new MockProvider(type, moqRepository),
                }
            };
        }

        public IEnumerable<IBinding> Resolve(Multimap<Type, IBinding> bindings, IRequest request)
        {
            var service = request.Service;
            return new IBinding[]
            {
                new Binding(service)
                {
                    ProviderCallback = context => new MockedObjectProvider(service, moqRepository),
                }
            };
        }
    }
}
