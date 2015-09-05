using System;
using System.Collections.Generic;
using System.Linq;
using Codurance.Data.Infrastructure;
using Codurance.Data.Model;
using Codurance.Infrastructure;

namespace Codurance.Data.Repository
{
    public class MessageRepository : Repository, IMessageRepository
    {

        public MessageRepository(IContentContext contentContext) : base(contentContext)
        {
            
        }

        public void CreateMessage(User user, string text, IDateTimeHelper dateTime)
        {
            ContentContext.DbSet<Message>().Add(new Message
            {
                Text = text,
                CreatedBy = user,
                CreatedDate = dateTime.CurrentDateTime
            });
            ContentContext.SaveChanges();
        }

        public IEnumerable<Message> GetMessages(User user)
        {
            return ContentContext.DbSet<Message>().Where(m => m.CreatedBy == user);
        }

        public IEnumerable<Message> GetMessages(IEnumerable<User> subscribedUsers)
        {
            return ContentContext.DbSet<Message>().Where(m => subscribedUsers.Contains(m.CreatedBy));
        }
    }
}
