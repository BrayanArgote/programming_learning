using _4_Interface_Segregation_Principle.DataBase;
using _4_Interface_Segregation_Principle.Entities;

namespace _4_Interface_Segregation_Principle.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool Add(User user)
        {
             _appDbContext.Add(user);
            if (_appDbContext.SaveChanges() > 0) { return true; }

            return false;
        }

        public bool UserExists(string userName, string password)
        {
            return _appDbContext.User.Any(q => q.UserName == userName && q.Password == password);
        }

        public bool UserNameExists(string userName)
        {
            return _appDbContext.User.Any(q => q.UserName == userName);
        }

        public int GetId(string userName)
        {
            return _appDbContext.User
                .Where(q => q.UserName == userName)
                .Select(q => q.Id)
                .FirstOrDefault();
        }

        public string GetUserName(int id)
        {
            return _appDbContext.User
                .Where(q => q.Id == id)
                .Select(q => q.UserName)
                .FirstOrDefault();
        }
    }
}
