using SmartEdu.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdu.Shared.DTO
{
    public class UpdateTrainerDTO
    {
        public int IdTrainer { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Course> Courses { get; set; }
    }
}
