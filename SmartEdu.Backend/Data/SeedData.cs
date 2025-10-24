using SmartEdu.Backend.Models;

namespace SmartEdu.Backend.Data
{
    public static class SeedData
    {
        public static void Initialize(SmartEduContext db)
        {
            if (db.Trainers.Any() || db.Courses.Any())
                return;

            // === Data Trainer ===
            var trainers = new Trainer[]
            {
                new Trainer
                {
                    IdTrainer = 1,
                    Name = "Dr. Andi Setiawan",
                    Email = "andi@smartedu.com",
                    Phone = "081234567890"
                },
                new Trainer
                {
                    IdTrainer = 2,
                    Name = "Ms. Rina Kusuma",
                    Email = "rina@smartedu.com",
                    Phone = "081278945612"
                },
                new Trainer
                {
                    IdTrainer = 3,
                    Name = "Mr. Budi Pratama",
                    Email = "budi@smartedu.com",
                    Phone = "082134679012"
                }
            };

            db.Trainers.AddRange(trainers);
            db.SaveChanges();

            // === Data Course ===
            var courses = new Course[]
            {
                new Course
                {
                    IdCourse = 1,
                    Title = "Fundamentals of Data Science",
                    Description = "Introduction to data analysis and machine learning basics.",
                    DurationInHours = 10,
                    TrainerId = 1
                },
                new Course
                {
                    IdCourse = 2,
                    Title = "Web Development with ASP.NET Core",
                    Description = "Building modern web apps using .NET 8 and Blazor.",
                    DurationInHours = 15,
                    TrainerId = 2
                },
                new Course
                {
                    IdCourse = 3,
                    Title = "Database Management Systems",
                    Description = "Design and manage relational databases using SQL.",
                    DurationInHours = 30,
                    TrainerId = 3
                },
                new Course
                {
                    IdCourse = 4,
                    Title = "Machine Learning Advanced",
                    Description = "Dive deeper into neural networks and model optimization.",
                    DurationInHours = 25,
                    TrainerId = 1
                }
            };

            db.Courses.AddRange(courses);
            db.SaveChanges();
        }
    }
}
