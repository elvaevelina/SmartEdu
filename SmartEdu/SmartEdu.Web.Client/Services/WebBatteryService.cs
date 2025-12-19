using SmartEdu.Shared.Services;

namespace SmartEdu.Web.Client.Services
{
    public class WebBatteryService : IBatteryService
    {
        public double GetLevel() => 1.0; 
        public string GetState() => "Web";
        public string GetPowerSource() => "AC";
    }
}
