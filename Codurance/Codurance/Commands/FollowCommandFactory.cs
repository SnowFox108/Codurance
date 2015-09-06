using Codurance.Infrastructure.Adapter;
using Codurance.Services;

namespace Codurance.Commands
{
    public class FollowCommandFactory : BaseCommandFactory, ICommandFactory
    {
        public FollowCommandFactory(IDiContainer serviceLocator) : base(serviceLocator)
        {
        }

        public string CommandName
        {
            get { return "follows"; }
        }
        public ICommand CreateCommand(string[] arguments)
        {
            var follower = arguments[0];
            var followee = arguments[2];

            return new FollowCommand(
                ServiceLocator.GetInstance<ISubscribeService>(),
                follower,
                followee);
        }
    }
}
