using Codurance.Data.Model;

namespace Codurance.Services.Shared
{
    public interface IUserService
    {
        User GetUser(string userName);
    }
}
