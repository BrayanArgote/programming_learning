namespace _4_Interface_Segregation_Principle.Services.Interfaces
{
    public interface IUserQuery
    {
        bool UserExists(string userName, string password);
        bool UserNameExists(string userName);
        int GetId(string userName);
        string GetUserName(int id);
    }
}
