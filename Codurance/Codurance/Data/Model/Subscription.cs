
using Codurance.Data.Infrastructure;

namespace Codurance.Data.Model
{
    public class Subscription : Entity
    {
        public User Follower { get; set; }
        public User Followee { get; set; }
    }
}
