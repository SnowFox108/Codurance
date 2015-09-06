using Autofac;

namespace Codurance.Infrastructure.Adapter
{
    public class AutoFacContiner : IDiContainer
    {
        private readonly IContainer _container;

        public AutoFacContiner(IContainer container)
        {
            _container = container;
        }

        public TService GetInstance<TService>() where TService : class
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                return scope.Resolve<TService>();
            }
        }
    }
}
