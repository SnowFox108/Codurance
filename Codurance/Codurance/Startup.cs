using System;
using System.Collections.Generic;
using System.Linq;
using Codurance.Commands;
using Codurance.Infrastructure.Adapter;

namespace Codurance
{
    public class Startup
    {
        public Startup()
        {
            var serviceLocator = new AutoFacContainerFactory().Create();
            var commandParser = new CommandParser(serviceLocator, RegisteCommands(serviceLocator));

            while (true)
                commandParser.Parse(Console.ReadLine()).Execute();
        }

        private IEnumerable<ICommandFactory> RegisteCommands(IDiContainer serviceLocator)
        {
            var commands = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(ICommandFactory).IsAssignableFrom(t) && t.IsClass);

            return commands.Select(item => Activator.CreateInstance(item, serviceLocator) as ICommandFactory);
        }
    }
}
