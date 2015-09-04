using Codurance.Data.Model;

namespace Codurance.Data.Repository
{
    public interface IUserRepository
    {
        void CreateUser(string name);
        User GetUser(string name);
    }
}
