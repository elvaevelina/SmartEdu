using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdu.Shared.Models
{
    public class SearchResult
    {
        public List<Course> Courses { get; set; } = new();
        public List<Trainer> Trainers { get; set; } = new();

    }
}
