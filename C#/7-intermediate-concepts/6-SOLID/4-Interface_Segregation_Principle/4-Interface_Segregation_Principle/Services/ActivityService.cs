using _4_Interface_Segregation_Principle.Entities;
using _4_Interface_Segregation_Principle.Repositories;
using _4_Interface_Segregation_Principle.Services.Interfaces;

namespace _4_Interface_Segregation_Principle.Services
{
    public class ActivityService : IActivityWriter, IActivityReader
    {
        private readonly ActivityRepository _activityRepository;
        public ActivityService(ActivityRepository activityRepository) {
            _activityRepository = activityRepository;
        }

        public bool Add(int userId, string title, string description, DateOnly dueDate)
        {
            description??= "no description";
            if (userId <= 0 || string.IsNullOrEmpty(title) || title.Length > 30 || description.Length > 40) { return false; }

            return _activityRepository.Add(userId, title, description, dueDate);

        }

        public async Task <List<Activity>> GetAll(int userId)
        {
            return await _activityRepository.GetAll(userId);
        }

        public async Task<List<Activity>> GetNotCompleted(int idUser) {
            return await _activityRepository.GetNotCompleted(idUser);
        }

        public Activity GetByIdAndUser(int id, int idUser)
        {
            return _activityRepository.GetByIdAndUser(id, idUser);
        }

        public bool MarkAsCompleted(int id, int idUser) { return _activityRepository.MarkAsComplete(id, idUser); }

    }
}
