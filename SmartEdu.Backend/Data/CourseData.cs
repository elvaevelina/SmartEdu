using Microsoft.EntityFrameworkCore;
using SmartEdu.Backend.Models;

namespace SmartEdu.Backend.Data
{
    public class CourseData : ICourse
    {
        private readonly SmartEduContext _context;

        public CourseData(SmartEduContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Course>> GetCourses()
        //{
        //    return await _context.Courses.OrderByDescending(c=>c.IdCourse).ToListAsync();
        //}
        public async Task<IEnumerable<Course>> GetCourses()
        {
            //return await _context.Courses.Include(c => c.Trainer)
            //                             .OrderByDescending(c => c.IdCourse)
            //                             .ToListAsync();
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetCourseById(int id)
        {
            return await _context.Courses.Include(c => c.Trainer)
                                         .FirstOrDefaultAsync(c => c.IdCourse == id);
        }

        public async Task<Course> AddCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            var existingCourse = await _context.Courses.FindAsync(course.IdCourse);
            if (existingCourse == null)
            {
                throw new KeyNotFoundException("Course not found");
            }
            existingCourse.Title = course.Title;
            existingCourse.Description = course.Description;
            existingCourse.DurationInHours = course.DurationInHours;
            existingCourse.TrainerId = course.TrainerId;
            await _context.SaveChangesAsync();
            return existingCourse;

        }

        public async Task<bool> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return false;
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Course>> SearchCourses(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await _context.Courses.Include(c => c.Trainer).ToListAsync();

            return await _context.Courses
                .Include(c => c.Trainer)
                .Where(c => c.Title.Contains(keyword)).ToListAsync();
        }

    }
}
