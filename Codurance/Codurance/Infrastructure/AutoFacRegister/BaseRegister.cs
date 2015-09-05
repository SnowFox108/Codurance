using Autofac;

namespace Codurance.Infrastructure.AutoFacRegister
{
    public abstract class BaseRegister
    {
        protected readonly ContainerBuilder Builder;

        protected BaseRegister(ContainerBuilder builder)
        {
            Builder = builder;
        }
    }
}
