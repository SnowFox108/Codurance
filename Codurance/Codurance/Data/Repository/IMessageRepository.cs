using System.Collections.Generic;
using Codurance.Data.Model;
using Codurance.Infrastructure;

namespace Codurance.Data.Repository
{
    public interface IMessageRepository
    {
        void CreateMessage(User author, string text, IDateTimeHelper dateTime);
        IEnumerable<Message> GetMessages(User user);
        IEnumerable<Message> GetMessages(IEnumerable<User> subscribedUsers);
    }
}
