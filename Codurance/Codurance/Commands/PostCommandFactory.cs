using Codurance.Infrastructure;
using Codurance.Infrastructure.Adatepter;
using Codurance.Services;

namespace Codurance.Commands
{
    public class PostCommandFactory : BaseCommandFactory, ICommandFactory
    {
        public PostCommandFactory(IDiContainer serviceLocator) : base(serviceLocator)
        {
        }

        public string CommandName
        {
            get { return "->"; }
        }
        public ICommand CreateCommand(string[] arguments)
        {
            var userName = arguments[0];
            var text = arguments[2];

            return new PostCommand(
                ServiceLocator.GetInstance<IMessageService>(),
                userName, 
                text,
                ServiceLocator.GetInstance<IDateTimeHelper>());
        }
    }
}
