using Microsoft.JSInterop;
using SmartEdu.Shared.Services;

namespace SmartEdu.Web.Client.Services
{
    public class CameraService : ICameraService
    {
        private readonly IJSRuntime _jsRuntime;

        public CameraService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

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
