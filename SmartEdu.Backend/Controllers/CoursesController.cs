using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.Backend.Data;
using SmartEdu.Backend.Models;
using SmartEdu.Shared.DTO;
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
        public async Task<IActionResult> AddCourse(AddCourseDTO dto)
        {
            var newCourse = new Course
            {
                Title = dto.Title,
                Description = dto.Description,
                DurationInHours = dto.DurationInHours,
                TrainerId = dto.TrainerId
                };
            var createdCourse = await _course.AddCourse(newCourse);
            return CreatedAtAction(nameof(GetCourseById),
                new { id = createdCourse.IdCourse }, createdCourse);
            
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
