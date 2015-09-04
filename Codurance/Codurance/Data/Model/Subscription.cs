
namespace Codurance.Data.Model
{
    public class Subscription
    {
        public User Follower { get; set; }
        public User Followee { get; set; }
    }
}
