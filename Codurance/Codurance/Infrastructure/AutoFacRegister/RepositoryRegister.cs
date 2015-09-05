using Autofac;
using Codurance.Data.Infrastructure;
using Codurance.Data.Repository;
using Codurance.Infrastructure.Adatepter;

namespace Codurance.Infrastructure.AutoFacRegister
{
    public class RepositoryRegister : BaseRegister, IDiRegister
    {
        public RepositoryRegister(ContainerBuilder builder) : base(builder)
        {
        }

        public void Register()
        {
            // mock data infrastructure
            Builder.RegisterType<MockContentContext>().As<IContentContext>().SingleInstance();

            // repositories
            Builder.RegisterType<MessageRepository>().As<IMessageRepository>();
            Builder.RegisterType<SubscriptionRepository>().As<ISubscriptionRepository>();
            Builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
