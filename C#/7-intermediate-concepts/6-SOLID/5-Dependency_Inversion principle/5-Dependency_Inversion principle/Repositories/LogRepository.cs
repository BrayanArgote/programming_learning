using _5_Dependency_Inversion_principle.DataBase;
using _5_Dependency_Inversion_principle.Entities;

namespace _5_Dependency_Inversion_principle.Repositories
{
    public class LogRepository
    {
        private AppDbContext _appDbContext;

        public LogRepository(AppDbContext appDbContext){
            _appDbContext = appDbContext;
        }

        public bool Add(Log log)
        {
            _appDbContext.Add(log);
            return _appDbContext.SaveChanges() > 0;
        }

        public List<Log> GetAll()
        {
            return _appDbContext.Logs.ToList();
        }
     
    }
}
