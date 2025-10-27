using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartEdu.Backend.Data;
using SmartEdu.Backend.Models;
using SmartEdu.Shared.DTO;


namespace SmartEdu.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainer _trainer;
        public TrainersController(ITrainer trainer)
        {
            _trainer = trainer;
        }
        [HttpGet]
        public async Task<IActionResult> GetTrainers()
        {
            var trainers = await _trainer.GetTrainers();
            return Ok(trainers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainerById(int id)
        {
            var trainer = await _trainer.GetTrainerWithCourses(id);
            if (trainer == null)
                return NotFound();
            return Ok(trainer);
        }
        [HttpPost]
        public async Task<IActionResult> AddTrainer(AddTrainerDTO dto)
        {
            var newTrainer = new Trainer
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };
            
            var createdTrainer = await _trainer.AddTrainer(newTrainer);
            return CreatedAtAction(nameof(GetTrainerById),
                new { id = createdTrainer.IdTrainer }, createdTrainer);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainer(int id, [FromBody] AddTrainerDTO dto)
        {
            var trainer = await _trainer.GetTrainerById(id);
            if (trainer == null)
            {
                return NotFound();
            }
            trainer.Name = dto.Name;
            trainer.Email = dto.Email;
            trainer.Phone = dto.Phone;

            await _trainer.UpdateTrainer(trainer);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var deleted = await _trainer.DeleteTrainer(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchTrainers([FromQuery] string keyword)
        {
            var trainers = await _trainer.SearchTrainers(keyword);
            return Ok(trainers);
        }
    }
}
