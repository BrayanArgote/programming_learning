using _4_Interface_Segregation_Principle.DataBase;
using _4_Interface_Segregation_Principle.Entities;

namespace _4_Interface_Segregation_Principle.Repositories
{
    public class ActivityRepository
    {
        private readonly AppDbContext _appDbContext;

        public ActivityRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool Add(int userId, string title, string? description, DateOnly dueDate)
        {
            var newActivity = new Activity
            {
                IdUser = userId,
                Title = title,
                Description = description,
                DueDate = dueDate,
            };
            _appDbContext.Activity.Add(newActivity);

            if ( _appDbContext.SaveChanges() > 0) { return true; }
            return false;
        }

        public bool MarkAsComplete(int id, int idUser){
            var activity = _appDbContext.Activity.FirstOrDefault(q => q.Id == id && q.IdUser == idUser);

            if (activity == null) {  return false; }
            activity.IsCompleted = true;

            if (_appDbContext.SaveChanges() > 0) {  return true; }
            return false;
        }

        public Activity GetByIdAndUser(int id, int idUser)
        {
            return _appDbContext.Activity.FirstOrDefault(q => q.Id == id && q.IdUser == idUser);
        }
        public async Task <List<Activity>> GetAll(int idUser) {
            await Task.Delay(3000);
            return _appDbContext.Activity.Where(q => q.IdUser == idUser).ToList();
        }

        public async Task<List<Activity>> GetNotCompleted(int idUser)
        {
            await Task.Delay(2000);

            return _appDbContext.Activity
                .Where (q => q.IdUser == idUser && q.IsCompleted == false)
                .ToList();
        }
    }
}


