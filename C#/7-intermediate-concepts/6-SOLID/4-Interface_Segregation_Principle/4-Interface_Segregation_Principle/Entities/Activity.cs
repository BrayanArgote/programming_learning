using System.ComponentModel.DataAnnotations;

namespace _4_Interface_Segregation_Principle.Entities
{
    public class Activity
    {
        public int Id { get; set; }

        public int IdUser{ get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(40)]
        public string Description { get; set; }
        public DateOnly DueDate { get; set; }
        public bool IsCompleted { get; set; }   
    }
}
