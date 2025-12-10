using SmartEdu.Shared.Services;

namespace SmartEdu.Web.Client.Services
{
    public class WebLocationService:ILocationService
    {
        public Task<string?> GetCurrentAddressAsync()
        {
            return Task.FromResult<string?>("Location not supported on Web yet");
        }
    }
}
