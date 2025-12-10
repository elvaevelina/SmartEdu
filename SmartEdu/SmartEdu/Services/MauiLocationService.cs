using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartEdu.Shared.Services;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.ApplicationModel;

namespace SmartEdu.Services
{
    public class MauiLocationService:ILocationService
    {
        private readonly IGeolocation _geolocation;
        private readonly IGeocoding _geocoding;

        public MauiLocationService(IGeolocation geolocation, IGeocoding geocoding)
        {
            _geolocation = geolocation;
            _geocoding = geocoding;
        }

        public async Task<string?> GetCurrentAddressAsync()
        {
            try
            {
                // 1. Cek Permission
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    if (status != PermissionStatus.Granted) return "Permission denied";
                }

                // 2. Ambil Koordinat
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var location = await _geolocation.GetLocationAsync(request);

                if (location == null) return null;

                // 3. Convert ke Alamat (Geocoding)
                var placemarks = await _geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                var placemark = placemarks?.FirstOrDefault();

                if (placemark != null)
                {
                    var parts = new List<string>();
                    if (!string.IsNullOrWhiteSpace(placemark.Thoroughfare)) parts.Add(placemark.Thoroughfare);
                    if (!string.IsNullOrWhiteSpace(placemark.SubThoroughfare)) parts.Add(placemark.SubThoroughfare);
                    if (!string.IsNullOrWhiteSpace(placemark.SubLocality)) parts.Add(placemark.SubLocality);
                    if (!string.IsNullOrWhiteSpace(placemark.Locality)) parts.Add(placemark.Locality);
                    if (!string.IsNullOrWhiteSpace(placemark.AdminArea)) parts.Add(placemark.AdminArea);

                    return string.Join(", ", parts);
                }

                return $"Lat: {location.Latitude}, Long: {location.Longitude}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

    }
}
