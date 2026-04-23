
namespace _5_Dependency_Inversion_principle.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Action { get; set; }
        public string Level { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
