using _5_Dependency_Inversion_principle.Entities;
using _5_Dependency_Inversion_principle.Repositories;

namespace _5_Dependency_Inversion_principle.Services
{
    public class DatabaseAppLoggerImpl : IAppLogger, IAppLogReader
    {
        private readonly LogRepository _logRepository;
        public DatabaseAppLoggerImpl(LogRepository logRepository) {
            _logRepository = logRepository;
        }
        public bool Add(int? userId, string action, string level)
        {
            if(string.IsNullOrEmpty(action) || string.IsNullOrEmpty(level) || action.Length > 50 || level.Length > 50) { return false; }

            DateTime dt = DateTime.Now;

            var log = new Log { Action = action, Level = level, UserId = userId, Timestamp = dt };

            return _logRepository.Add(log);
        }

        public List<Log> GetAll()
        {
            return _logRepository.GetAll();
        }
    }
}
