using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Codurance.Infrastructure;
using Codurance.Infrastructure.Adapter;

namespace Codurance.Commands
{
    public class CommandParser : ICommandParser
    {
        private readonly IDiContainer _serviceLocator;
        private readonly IEnumerable<ICommandFactory> _allCommands;

        public CommandParser(IDiContainer serviceLocator, IEnumerable<ICommandFactory> allCommands)
        {
            _serviceLocator = serviceLocator;
            _allCommands = allCommands;
        }

        public ICommand Parse(string input)
        {
            var regex = new Regex(@"\s+");
            var inputParts = regex.Split(input, 3);

            if (string.IsNullOrEmpty(inputParts[0]))
                return new NullCommand(_serviceLocator.GetInstance<IPrinterHelper>());

            var commandName = GetCommandName(inputParts);
            var commandFactory = GetCommandBy(commandName);

            if (commandFactory != null)
                return commandFactory.CreateCommand(inputParts);
            
            return new NullCommand(_serviceLocator.GetInstance<IPrinterHelper>());
        }

        private string GetCommandName(string[] inputParts)
        {
            var length = inputParts.Length;
            string commandName = string.Empty;
            if (length > 1)
            {
                commandName = inputParts[1];
            }
            return commandName;            
        }

        private ICommandFactory GetCommandBy(string commandName)
        {
            return _allCommands.FirstOrDefault(a => a.CommandName == commandName);
        }
    }
}
