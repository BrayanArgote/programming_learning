namespace _4_Interface_Segregation_Principle.Services.Interfaces
{
    public interface IActivityWriter
    {
        bool Add(int userId, string title, string? description, DateOnly dueDate);
        bool MarkAsCompleted(int id, int idUser);
    }
}
