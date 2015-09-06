using Autofac;
using Codurance.Infrastructure.Adapter;
using Codurance.Services;
using Codurance.Services.Shared;

namespace Codurance.Infrastructure.AutoFacRegister
{
    public class ServiceRegister : BaseRegister, IDiRegister
    {
        public ServiceRegister(ContainerBuilder builder) : base(builder)
        {
        }

        public void Register()
        {
            // shared service
            Builder.RegisterType<MessagePrinterService>().As<IMessagePrinterService>();
            Builder.RegisterType<UserService>().As<IUserService>();

            // domain service
            Builder.RegisterType<MessageService>().As<IMessageService>();
            Builder.RegisterType<SubscribeService>().As<ISubscribeService>();
        }
    }
}
