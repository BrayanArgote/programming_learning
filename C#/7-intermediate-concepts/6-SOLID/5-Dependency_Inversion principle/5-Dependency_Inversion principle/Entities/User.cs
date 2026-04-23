
namespace _5_Dependency_Inversion_principle.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public string FullName { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
