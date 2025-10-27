using SmartEdu.Backend.Models;

namespace SmartEdu.Backend.Data
{
    public interface ITrainer
    {
        Task<IEnumerable<Trainer>> GetTrainers();
        Task<Trainer?> GetTrainerById(int id);
        Task<Trainer> AddTrainer(Trainer trainer);
        Task<Trainer?> UpdateTrainer(Trainer trainer);
        Task<bool> DeleteTrainer(int id);
        Task<Trainer> GetTrainerWithCourses(int id);
        Task<IEnumerable<Trainer>> SearchTrainers(string keyword);

    }
}
