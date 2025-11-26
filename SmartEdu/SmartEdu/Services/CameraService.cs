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
                // Cek Izin Kamera (Penting untuk Android/iOS)
                var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.Camera>();
                    if (status != PermissionStatus.Granted)
                        return null; // Izin ditolak
                }

                // Menggunakan MediaPicker seperti contoh Anda
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    FileResult? photo = await MediaPicker.Default.CapturePhotoAsync();

                    if (photo != null)
                    {
                        // Simpan ke cache lokal dan kembalikan path-nya
                        var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                        using var stream = await photo.OpenReadAsync();
                        using var newStream = File.OpenWrite(newFile);
                        await stream.CopyToAsync(newStream);

                        return newFile; // Mengembalikan path file lokal
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Camera Error: {ex.Message}");
            }
            return null;
        }
    }
}
