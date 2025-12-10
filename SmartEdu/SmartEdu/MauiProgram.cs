using Microsoft.Extensions.Logging;
using SmartEdu.Services;
using SmartEdu.Shared.Services;
using System.Net.Http;
using Microsoft.Maui.Devices.Sensors;

namespace SmartEdu
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add device-specific services used by the SmartEdu.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();
            builder.Services.AddSingleton<ICameraService, CameraService>();
            builder.Services.AddSingleton<INetworkService, MauiNetworkService>();

            builder.Services.AddSingleton<ILocationService, MauiLocationService>();
            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            builder.Services.AddSingleton<IGeocoding>(Geocoding.Default);

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            string baseUrl;

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                baseUrl = "http://10.0.2.2:5013/";
            }
            else
            {
                baseUrl = "https://localhost:7194/";
            }

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            });
            return builder.Build();
        }
    }
}
