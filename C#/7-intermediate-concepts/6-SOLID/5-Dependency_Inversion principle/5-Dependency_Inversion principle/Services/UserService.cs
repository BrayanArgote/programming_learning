using _5_Dependency_Inversion_principle.Entities;
using _5_Dependency_Inversion_principle.Repositories;

namespace _5_Dependency_Inversion_principle.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IAppLogger _iAppLogger;

        public UserService(UserRepository userRepository, IAppLogger iAppLogger)
        {
            _userRepository = userRepository;
            _iAppLogger = iAppLogger;
        }

        public bool Add(string fullName, int age)
        {
            bool operationStatus;
            int? userId = null;

            if (string.IsNullOrEmpty(fullName) || fullName.Length > 50 || age > 100 || age < 18) { operationStatus = false; }

            else
            {
                userId = _userRepository.Add(new User { FullName = fullName, Age = age });
                operationStatus = userId > 0;
            }

            _iAppLogger.Add(userId, "ADD", operationStatus ? "INFO" : "ERROR");

            return operationStatus;
        }
        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public bool Disable(int userId)
        {
            bool operationStatus;

            if (userId <= 0) { operationStatus = false; }
            else { operationStatus = _userRepository.Disable(userId); }

            _iAppLogger.Add(userId, "DISABLE", operationStatus ? "INFO" : "ERROR");

            return operationStatus;
        }

        public bool UserIsActiveAndExists(int userId)
        {
            if (userId <= 0) return false;
            return _userRepository.UserIsActiveAndExists(userId);
        }
    }
}
