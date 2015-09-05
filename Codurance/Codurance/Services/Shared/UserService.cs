using Codurance.Data.Model;
using Codurance.Data.Repository;

namespace Codurance.Services.Shared
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(string userName)
        {
            var user = _userRepository.GetUser(userName);
            if (null == user)
               return _userRepository.CreateUser(userName);
            return user;
        }
    }
}
