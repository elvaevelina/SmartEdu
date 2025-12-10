using SmartEdu.Shared.Services;

namespace SmartEdu.Web.Client.Services
{
    public class WebNetworkService : INetworkService
    {
        public bool IsConnected => true;
        public event Action<bool>? ConnectivityChanged;
    }
}
