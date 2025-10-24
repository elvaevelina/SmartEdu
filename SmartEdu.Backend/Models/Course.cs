using System.ComponentModel.DataAnnotations;

namespace SmartEdu.Backend.Models
{
    public class Course
    {
        [Key]
        public int IdCourse { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationInHours { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }
}
