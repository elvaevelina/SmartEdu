using SmartEdu.Backend.Models;

namespace SmartEdu.Backend.Data
{
    public interface ICourse
    {
        Task<IEnumerable<Course>> GetCourses();
        Task<Course?> GetCourseById(int id);
        Task<Course> AddCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task<bool> DeleteCourse(int id);
        Task<IEnumerable<Course>> SearchCourses(string keyword);
    }
}
