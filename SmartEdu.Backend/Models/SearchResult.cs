namespace SmartEdu.Backend.Models
{
    public class SearchResult
    {
        public List<Course> Courses { get; set; } = new();
        public List<Trainer> Trainers { get; set; } = new();
    }
}
