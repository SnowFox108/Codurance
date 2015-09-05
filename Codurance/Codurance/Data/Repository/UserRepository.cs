using System.Linq;
using Codurance.Data.Infrastructure;
using Codurance.Data.Model;

namespace Codurance.Data.Repository
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(IContentContext contentContext)
            : base(contentContext)
        {
            
        }

        public User CreateUser(string name)
        {
            var user = new User
            {
                Name = name
            };
            ContentContext.DbSet<User>().Add(user);
            ContentContext.SaveChanges();
            return user;
        }

        public User GetUser(string name)
        {
            return ContentContext.DbSet<User>().FirstOrDefault(u => u.Name == name);
        }
    }
}
