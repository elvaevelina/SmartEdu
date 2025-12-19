using SmartEdu.Shared.Services;

namespace SmartEdu.Web.Client.Services
{
    public class WebScreenshotService : IScreenshotService
    {
        public Task CaptureandShareAsync()
        {
            Console.WriteLine("Fitur Screenshot belum tersedia di versi Web.");
            return Task.CompletedTask;
        }
    }
}
