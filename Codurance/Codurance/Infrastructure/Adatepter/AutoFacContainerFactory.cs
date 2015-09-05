using System;
using System.Linq;
using Autofac;

namespace Codurance.Infrastructure.Adatepter
{
    public class AutoFacContainerFactory : IDiContainerFactory
    {
        public IDiContainer  Create()
        {
            var builder = new ContainerBuilder();

            var registers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(IDiRegister).IsAssignableFrom(t) && t.IsClass);

            foreach (var item in registers)
            {
                var register = Activator.CreateInstance(item, builder) as IDiRegister;
                if (register != null)
                    register.Register();
            }

            return new AutoFacContiner(builder.Build());
        }

    }
}
