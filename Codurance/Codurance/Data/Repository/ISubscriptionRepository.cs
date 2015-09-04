using System.Collections.Generic;
using Codurance.Data.Model;

namespace Codurance.Data.Repository
{
    public interface ISubscriptionRepository
    {
        void Subscribe(User follower, User followee);
        IEnumerable<User> GetSubscribers(User user);
    }
}
