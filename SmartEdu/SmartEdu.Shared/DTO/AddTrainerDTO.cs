using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdu.Shared.DTO
{
    public class AddTrainerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone {  get; set; }
        public string? ImageUrl { get; set; }
    }
}
