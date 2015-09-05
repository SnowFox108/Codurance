using System.Linq;
using Codurance.Data.Repository;
using Codurance.Services.Shared;

namespace Codurance.Services
{
    public class SubscribeService : ISubscribeService
    {
        private readonly IUserService _userService;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscribeService(IUserService userService, ISubscriptionRepository subscriptionRepository)
        {
            _userService = userService;
            _subscriptionRepository = subscriptionRepository;
        }

        public void FollowUser(string follower, string followee)
        {
            var followerUser = _userService.GetUser(follower);
            var followeeUser = _userService.GetUser(followee);

            if (_subscriptionRepository.GetSubscribers(followerUser).All(u => u != followeeUser))
                _subscriptionRepository.Subscribe(followerUser, followeeUser);
        }
    }
}
