using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdu.Shared.DTO
{
    public class UpdateCourseDTO
    {
        public int IdCourse { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationInHours { get; set; }
        public int TrainerId { get; set; }
    }
}
