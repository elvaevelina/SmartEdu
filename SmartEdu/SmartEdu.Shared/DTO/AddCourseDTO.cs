using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdu.Shared.DTO
{
    public class AddCourseDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DurationInHours { get; set; }
        public int TrainerId { get; set; }
    }
}
