using Microsoft.EntityFrameworkCore;
using SmartEdu.Backend.Models;

namespace SmartEdu.Backend.Data
{
    public class SmartEduContext: DbContext
    {
        public SmartEduContext(DbContextOptions options)
            : base(options) 
            {
            }

        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Trainer> Trainers { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Trainer)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TrainerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>().HasIndex(c => c.Title);
            modelBuilder.Entity<Trainer>().HasIndex(t => t.Name);
        }

    }
}
