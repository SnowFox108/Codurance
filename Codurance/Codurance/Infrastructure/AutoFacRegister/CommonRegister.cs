using Autofac;
using Codurance.Infrastructure.Adapter;

namespace Codurance.Infrastructure.AutoFacRegister
{
    public class CommonRegister : BaseRegister, IDiRegister
    {
        public CommonRegister(ContainerBuilder builder)
            : base(builder)
        {
        }

        public void Register()
        {
            Builder.RegisterType<DateTimeHelper>().As<IDateTimeHelper>();
            Builder.RegisterType<PrinterHelper>().As<IPrinterHelper>();
        }
    }

}
