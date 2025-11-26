using SmartEdu.Shared.Services;

namespace SmartEdu.Web.Client.Services
{
    public class CameraService : ICameraService
    {
        public Task<string?> PickPhotoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string?> TakePhotoAsync()
        {
            Console.WriteLine("Camera service is not supported in WebAssembly.");
            return Task.FromResult<string?>(null);

        }
    }
}
