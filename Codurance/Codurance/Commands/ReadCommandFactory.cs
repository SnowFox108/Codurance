using Codurance.Infrastructure.Adapter;
using Codurance.Services;

namespace Codurance.Commands
{
    public class ReadCommandFactory : BaseCommandFactory, ICommandFactory
    {
        public ReadCommandFactory(IDiContainer serviceLocator) : base(serviceLocator)
        {
        }

        public string CommandName
        {
            get { return string.Empty; }
        }

        public ICommand CreateCommand(string[] arguments)
        {
            var userName = arguments[0];

            return new ReadCommand(
                ServiceLocator.GetInstance<IMessageService>(),
                userName);
        }
    }
}
