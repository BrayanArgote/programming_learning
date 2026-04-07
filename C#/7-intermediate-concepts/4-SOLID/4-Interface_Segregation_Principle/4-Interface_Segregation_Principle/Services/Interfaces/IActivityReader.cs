using _4_Interface_Segregation_Principle.Entities;

namespace _4_Interface_Segregation_Principle.Services.Interfaces
{
    public interface IActivityReader
    {
        Task<List<Activity>> GetAll(int idUser);
        Task<List<Activity>> GetNotCompleted(int idUser);
        Activity GetByIdAndUser(int id, int idUser);
    }
}
  