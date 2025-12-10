using Microsoft.EntityFrameworkCore;
using SmartEdu.Backend.Models;

namespace SmartEdu.Backend.Data
{
    public class TrainerData : ITrainer
    {
        private readonly SmartEduContext _context;

        public TrainerData(SmartEduContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trainer>> GetTrainers()
        {
            return await _context.Trainers.Include(t => t.Courses)
                                          .OrderByDescending(t => t.IdTrainer)
                                          .ToListAsync();
            //return await _context.Trainers.ToListAsync();
        }

        public async Task<Trainer?>GetTrainerById(int id)
        {
            return await _context.Trainers.Include(t => t.Courses)
                                          .FirstOrDefaultAsync(t => t.IdTrainer == id);
        }

        public async Task<Trainer> AddTrainer(Trainer trainer)
        {
            _context.Trainers.Add(trainer);
            await _context.SaveChangesAsync();
            return trainer;
        }

        public async Task<Trainer?> UpdateTrainer(Trainer trainer)
        {
            var existingTrainer = await _context.Trainers.FindAsync(trainer.IdTrainer);
            if (existingTrainer == null)
            {
                throw new KeyNotFoundException("Trainer not found");
            }
            existingTrainer.Name = trainer.Name;
            existingTrainer.Email = trainer.Email;
            existingTrainer.Phone = trainer.Phone;
            existingTrainer.Address = trainer.Address;
            await _context.SaveChangesAsync();
            return existingTrainer;
        }
        public async Task<bool> DeleteTrainer(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return false;
            }
            _context.Trainers.Remove(trainer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Trainer>> SearchTrainers(string keyword)
        {
            if(string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.Trainers.Include(t => t.Courses).ToListAsync();
            }
            return await _context.Trainers.Where(t => t.Name.Contains(keyword) || t.Email.Contains(keyword)).ToListAsync();
        }

        public Task<Trainer> GetTrainerWithCourses(int id)
        {
            return _context.Trainers.Include(t => t.Courses)
                                    .FirstOrDefaultAsync(t => t.IdTrainer == id)!;
        }
    }
}
