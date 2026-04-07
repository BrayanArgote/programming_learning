using _4_Interface_Segregation_Principle.Entities;
using _4_Interface_Segregation_Principle.Repositories;
using _4_Interface_Segregation_Principle.Services.Interfaces;

namespace _4_Interface_Segregation_Principle.Services
{
    public class UserService : IUserQuery, IUserOperation
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepositoty)
        {
            _userRepository = userRepositoty;
        }

        public bool UserExists(string userName, string password)
        {
            return _userRepository.UserExists(userName, password);
        }

        public bool UserNameExists(string userName)
        {
            return _userRepository.UserNameExists(userName);
        }

        public int GetId(string UserName)
        {
            return _userRepository.GetId(UserName);
        }

        public string GetUserName(int id)
        {
            return _userRepository.GetUserName(id);
        }


        public bool Add(string userName, string password)
        {
            var newUser = new User
            {
                UserName = userName,
                Password = password
            };
            return _userRepository.Add(newUser);
        }
    }
}
