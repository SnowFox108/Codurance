using Codurance.Services;

namespace Codurance.Commands
{
    public class FollowCommand : ICommand
    {
        private readonly ISubscribeService _subscribeService;
        private readonly string _follower;
        private readonly string _followee;

        public FollowCommand(ISubscribeService subscribeService, string follower, string followee)
        {
            _subscribeService = subscribeService;
            _follower = follower;
            _followee = followee;
        }

        public void Execute()
        {
            _subscribeService.FollowUser(_follower, _followee);
        }
    }
}
