using System.Collections.Generic;
using System.Linq;
using Codurance.Data.Infrastructure;
using Codurance.Data.Model;

namespace Codurance.Data.Repository
{
    public class SubscriptionRepository : Repository, ISubscriptionRepository
    {
        public SubscriptionRepository(IContentContext contentContext) : base(contentContext)
        {
        }

        public void Subscribe(User follower, User followee)
        {
            ContentContext.DbSet<Subscription>().Add(new Subscription
            {
                Follower = follower,
                Followee = followee
            });
            ContentContext.SaveChanges();
        }

        public IEnumerable<User> GetSubscribers(User user)
        {
            return ContentContext.DbSet<Subscription>().Where(s => s.Follower == user).Select(s => s.Followee);
        }
    }
}
