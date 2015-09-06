using Codurance.Infrastructure.Adapter;
using Codurance.Services;

namespace Codurance.Commands
{
    public class WallCommandFacotry: BaseCommandFactory, ICommandFactory
    {
        public WallCommandFacotry(IDiContainer serviceLocator) : base(serviceLocator)
        {
        }

        public string CommandName
        {
            get { return "wall"; }
        }
        public ICommand CreateCommand(string[] arguments)
        {
            var userName = arguments[0];

            return new WallCommand(
                ServiceLocator.GetInstance<IMessageService>(),
                userName);
        }
    }
}
