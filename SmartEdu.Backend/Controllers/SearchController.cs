using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.Backend.Data;
using SmartEdu.Backend.Models;

namespace SmartEdu.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SmartEduContext _context;

        public SearchController(SmartEduContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Query parameter is required.");
            }
            var normalizedQuery = query.ToLower();

            var courses = _context.Courses
                .Where(c => c.Title.ToLower().Contains(normalizedQuery))
                .ToList();

            var trainers = _context.Trainers
                .Where(t => t.Name.ToLower().Contains(normalizedQuery) ||
                            t.Email.ToLower().Contains(normalizedQuery))
                .ToList();

            var result = new
            {
                Courses = courses,
                Trainers = trainers
            };
            return Ok(result);
        }

    }
}
