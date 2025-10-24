using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.Backend.Data;
using SmartEdu.Backend.Models;

namespace SmartEdu.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourse _course;
        public CoursesController(ICourse course)
        {
            _course = course;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _course.GetCourses();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _course.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(Course course)
        {
            var newCourse = await _course.AddCourse(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = newCourse.IdCourse }, newCourse);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            if (id != course.IdCourse)
            {
                return BadRequest();
            }
            try
            {
                var updatedCourse = await _course.UpdateCourse(course);
                return Ok(updatedCourse);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _course.DeleteCourse(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
