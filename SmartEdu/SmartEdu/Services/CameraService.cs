using SmartEdu.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdu.Services
{
    public class CameraService : ICameraService
    {
        public Task<string?> PickPhotoAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string?> TakePhotoAsync()
        {
            try
            {
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    FileResult? photo = await MediaPicker.Default.CapturePhotoAsync();
                    if (photo == null)
                    {
                        return null;
                    }
                    var newFile = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                    using (var stream = await photo.OpenReadAsync())
                    using (var newStream = File.OpenWrite(newFile))
                    {
                        await stream.CopyToAsync(newStream);
                    }
                    return newFile;
                }
            }

            catch(Exception Ex)
            {
                Console.WriteLine($"Camera error : {Ex.Message}");
            }
            return null;
        }
    }
}
