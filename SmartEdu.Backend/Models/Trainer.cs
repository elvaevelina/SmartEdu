using System.ComponentModel.DataAnnotations;

namespace SmartEdu.Backend.Models
{
    public class Trainer
    {
        [Key]
        public int IdTrainer { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? ImageUrl { get; set; }
        public List<Course> Courses { get; set; }
    }
}
