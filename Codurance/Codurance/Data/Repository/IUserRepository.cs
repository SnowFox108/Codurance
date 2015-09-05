using Codurance.Data.Model;

namespace Codurance.Data.Repository
{
    public interface IUserRepository
    {
        User CreateUser(string name);
        User GetUser(string name);
    }
}
