using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdu.Shared.Services
{
    public interface ICameraService
    {
        Task <string?> TakePhotoAsync();
        Task<string?> PickPhotoAsync();
    }
}
