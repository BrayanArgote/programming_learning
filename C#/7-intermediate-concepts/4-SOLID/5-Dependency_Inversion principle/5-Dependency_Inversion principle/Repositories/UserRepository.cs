using _5_Dependency_Inversion_principle.DataBase;
using _5_Dependency_Inversion_principle.Entities;

namespace _5_Dependency_Inversion_principle.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }
        

        public int Add(User user)
        {
            if (user == null) { return 0; }

            _appDbContext.Users.Add(user);

            if(_appDbContext.SaveChanges() > 0) { return user.Id; }
            return 0;

        }
        public List<User> GetAll()
        {
            return _appDbContext.Users.ToList();
        }

        public bool Disable(int id)
        {
            var user = _appDbContext.Users.FirstOrDefault(q => q.Id == id);

            if (user == null) { return false; }

            user.IsActive = false;

            if(_appDbContext.SaveChanges() > 0)  { return true; }

            return false;
        }

        public bool UserIsActiveAndExists(int userId) {
            return _appDbContext.Users.Any(q => q.Id == userId && q.IsActive);
        }

    }
}
