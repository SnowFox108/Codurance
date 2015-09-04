using System.Collections.Generic;
using Codurance.Data.Model;

namespace Codurance.Data.Repository
{
    public interface IMessageRepository
    {
        void CreateMessage(User author, string text);
        IEnumerable<Message> GetMessages(User user);
        IEnumerable<Message> GetMessages(IEnumerable<User> subscribedUsers);
    }
}
